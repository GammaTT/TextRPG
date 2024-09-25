using EnumCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{
    public struct Item
    {
        public ItemType type;

        public int armor;
        public int price;
        public int attackDamage;
        public bool isPlayerEquip;
        public string name;
        public string itemDescription;

        public Item(ItemType type, int armor, int price, int attackDamage,
            bool isPlayerEquip, string name, string itemDescription)
        {
            this.type = type;
            this.armor = armor;
            this.price = price;
            this.attackDamage = attackDamage;
            this.isPlayerEquip = isPlayerEquip;
            this.name = name;
            this.itemDescription = itemDescription;
        }

        public string GetItemInfo()
        {
            string itemInfo = "";

            //itemInfo += "- ";

            /*if (isPlayerEquip)
            {
                itemInfo += "[E]";
            }*/

            itemInfo += $"{name}\t";

            if (type == ItemType.Armor)
            {
                itemInfo += $"| 방어력 +{armor}  | ";
            }
            else if (type == ItemType.Weapon)
            {
                itemInfo += $"| 공격력 +{attackDamage}  | ";
            }

            itemInfo += $"{itemDescription}";

            return itemInfo;
        }
    }

    class ItemManager
    {
        public List<Item> items = new List<Item>();

        #region // 아이템 생성 리스트

        public ItemManager()
        {
            // 아이템 리스트 추가
            items.Add(new Item(
                type: ItemType.Armor,
                armor: 5,
                price: 1000,
                attackDamage: 0,
                isPlayerEquip: false,
                name: "수련자 갑옷",
                itemDescription: "수련에 도움을 주는 갑옷입니다."
            ));

            items.Add(new Item(
                type: ItemType.Armor,
                armor: 9,
                price: 1500,
                attackDamage: 0,
                isPlayerEquip: false,
                name: "무쇠갑옷",
                itemDescription: "무쇠로 만들어져 튼튼한 갑옷입니다."
            ));

            items.Add(new Item(
                type: ItemType.Armor,
                armor: 15,
                price: 3500,
                attackDamage: 0,
                isPlayerEquip: false,
                name: "스파르타의 갑옷",
                itemDescription: "스파르타의 전사들이 사용했다는 전설의 갑옷입니다."
            ));

            items.Add(new Item(
                type: ItemType.Weapon,
                armor: 0,
                price: 600,
                attackDamage: 2,
                isPlayerEquip: false,
                name: "낡은 검",
                itemDescription: "쉽게 볼 수 있는 낡은 검입니다."
            ));

            items.Add(new Item(
                type: ItemType.Weapon,
                armor: 0,
                price: 1500,
                attackDamage: 5,
                isPlayerEquip: false,
                name: "청동 도끼",
                itemDescription: "어디선가 사용됐던 거 같은 도끼입니다."
            ));

            items.Add(new Item(
                type: ItemType.Weapon,
                armor: 0,
                price: 5000,
                attackDamage: 7,
                isPlayerEquip: false,
                name: "스파르타의 창",
                itemDescription: "스파르타의 전사들이 사용했다는 전설의 창입니다."
            ));
        }

        #endregion


    }
}
