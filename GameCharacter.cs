using EnumCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{
    class GameCharacter
    {
        int dungeonClearCount = 0;
        int ToLevelUpCount = 1;

        public Job job;
        public string name = "";
        public int level = 1;
        public float attackDamage = 10;
        public int armor = 5;
        public int maxHP = 100;
        public int currentHP = 100;
        public int exp = 0;
        public int maxEXP = 100;
        public int gold = 30000;
        //public bool equipArmor = false;
        //public bool equipWeapon = false;


        public Item? equipArmor;
        public Item? equipWeapon;

        public List<Item> itemList = new List<Item>();

        public GameCharacter()
        {
            currentHP = maxHP;
        }

        public string[] GetCharacterInfo()
        {
            string jobName = "";

            switch(job)
            {
                case Job.Warrior:
                    jobName = "전사";
                    break;

                case Job.Thief:
                    jobName = "도적";
                    break;
            };

            string[] characterInfo = new string[]
            {
                "상태 보기",
                "캐릭터의 정보가 표시됩니다. \n",
                $"{name}",
                $"Lv. {level.ToString("00")}",
                $"Chad ( {jobName} )",
                // 공격력 계산
                $"공격력 : {(equipWeapon != null ? attackDamage + equipWeapon.attackDamage : attackDamage)} (+{(equipWeapon != null ? equipWeapon.attackDamage : 0)})",
                // 방어력 계산
                $"방어력 : {(equipArmor != null ? armor + equipArmor.armor : armor)} (+{(equipArmor != null ? equipArmor.armor : 0)})",
                $"체력 : {currentHP} / {maxHP}",
                $"Gold : {gold} G"
            };

            return characterInfo;
        }

        public string[] GetInventoryInfoIntro()
        {
            List<string> inventoryInfo = new List<string>()
            {
                "인벤토리",
                "보유 중인 아이템을 관리할 수 있습니다.\n",
                "[아이템 목록]",
            };

            return inventoryInfo.ToArray();
        }

        public string[] GetInventoryInfoIntroForEquip()
        {
            List<string> inventoryInfo = new List<string>()
            {
                "인벤토리",
                "보유 중인 아이템을 관리할 수 있습니다.\n",
                "[아이템 목록 | 원하는 아이템 장착]",
            };

            return inventoryInfo.ToArray();
        }

        public string[] GetInventoryInfo()
        {
            List<String> inventoryInfo = new List<String>();

            foreach (var item in itemList)
            {
                inventoryInfo.Add(item.GetItemInfo(false));
            }

            return inventoryInfo.ToArray();
        }

        public string[] GetInventoryInfoForSell()
        {
            List<String> inventoryInfo = new List<String>();

            foreach (var item in itemList)
            {
                ItemStateForShop state = item.shopItemState;
                item.shopItemState = ItemStateForShop.ShowSellPrice;
                inventoryInfo.Add(item.GetItemInfo(true));
                item.shopItemState = state;
            }

            return inventoryInfo.ToArray();
        }

        public void EquipItem(int select)
        {
            Item item = itemList[select - 1];

            //이미 장착되어 있는 아이템 장착 해제
            if (item.isPlayerEquip)
            {
                if (item == equipWeapon)
                {
                    item.isPlayerEquip = false;
                    //attackDamage -= equipWeapon.attackDamage;
                    equipWeapon = null;
                }
                else if (item == equipArmor)
                {
                    item.isPlayerEquip = false;
                    //armor -= equipArmor.armor;
                    equipArmor = null;
                }
            }
            //아이템 장착
            else
            {
                item.isPlayerEquip = true;

                //아이템 타입에 따라
                switch (item.type)
                {
                    case ItemType.Armor:
                        //이미 방어구 끼고 있을 경우
                        if (equipArmor != null)
                        {
                            equipArmor.isPlayerEquip = false;
                            //armor -= equipArmor.armor;
                        }
                        //armor += item.armor;

                        equipArmor = item;

                        break;

                    case ItemType.Weapon:
                        //이미 무기를 끼고 있을 경우
                        if (equipWeapon != null)
                        {
                            equipWeapon.isPlayerEquip = false;
                            //attackDamage -= equipWeapon.attackDamage;
                        }

                        equipWeapon = item;
                        //attackDamage += item.attackDamage;

                        break;
                }

            }
        }

        public void DungeonClear()
        {
            dungeonClearCount++;

            if (dungeonClearCount >= ToLevelUpCount)
            {
                LevelUp();
            }
        }
        public void LevelUp()
        {
            attackDamage += 0.5f;
            armor += 1;

            dungeonClearCount = 0;
            ToLevelUpCount++;
        }
    }
}
