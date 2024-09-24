using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EnumCollection;

namespace TextRPG
{
    internal class TextRPG
    {
        static void Main()
        {
            GameManager gameManager = new GameManager();
            //OutputManager outputManager = new OutputManager();

            //outputManager.OutputMessage(outputManager.GameStart);

            gameManager.GameStart();
        }
    }

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

    class GameManager
    {
        Shop shop = new Shop();
        IOManager ioManager = new IOManager();
        GameCharacter playerCharacter = new GameCharacter();

        Scene scene = 0;

        string name = "";

        public void GameStart()
        {
            ioManager.OutputMessage(ioManager.GameStart);

            while (true)
            {
                ioManager.OutputMessage(ioManager.PlzInputName);
                ioManager.InputString = Console.ReadLine().ToString();
                if (ioManager.OutputMessageWithNumber(ioManager.SaveOrCancel) == 1)
                {
                    break;
                }
            }

            playerCharacter.name = ioManager.InputString; // 이름 저장

            Console.Clear();
            ioManager.OutputMessage(ioManager.PlzInputJob);
            ioManager.OutputMessageWithNumber(ioManager.Jobs);
            playerCharacter.job = (Job)ioManager.inputNumber;
            Game();
        }

        public void Game()
        {
            Activity();
        }

        public void Activity()
        {
            switch (ioManager.OutputMessageWithNumber(ioManager.Activity, true))
            {
                case 1:
                    ioManager.OutputMessage(playerCharacter.GetCharacterInfo(), true);
                    if (ioManager.OutputMessageWithNumber(ioManager.InputZeroForExit, false) == 1)
                    {
                        Activity();
                    }
                    break;

                case 3:
                    ioManager.OutputMessage(shop.GetShopItemsIntro(playerCharacter.gold), true);
                    ioManager.OutputMessage(shop.GetShopItemList(), false);
                    //ioManager.OutputMessageWithNumber(ioManager.BuyOrExit);
                    if (ioManager.OutputMessageWithNumber(ioManager.BuyOrExit) == 1)
                    {
                        ioManager.OutputMessage(shop.GetShopItemsIntro(playerCharacter.gold), true);
                        ioManager.OutputMessageWithNumber(shop.GetShopItemList(), false);
                        ioManager.OutputMessageWithNumber(ioManager.InputZeroForExit);
                    }
                    break;
            }
        }

    }

    class IOManager
    {
        public int inputNumber;
        string inputString = "";
        public string InputString
        {
            get { return inputString; }
            set { inputString = value; }
        }

        public readonly string[] GameStart = {"스파르타 마을에 오신 여러분 환영합니다.",
            "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다."};
        public string[] PlzInputName = { "원하시는 이름을 입력해주세요.\n" };
        public string[] PlzInputJob = { "원하시는  직업을 선택해주세요." }; 


        public string[] InputZeroForExit = { "나가기" };
        public string[] Jobs = { "전사", "도적" };
        public string[] SaveOrCancel = { "저장", "취소" };
        public string[] Activity = { "상태 보기", "인벤토리", "상점" };
        public string[] BuyOrExit = { "아이템 구매", "나가기" };

        public void OutputMessage(string[] message, bool Clear = false)
        {
            if (Clear)
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine();
            }

            foreach (var item in message)
            {
                Console.WriteLine(item);
            }
        }

        public int OutputMessageWithNumber(string[] message , bool Clear = false)
        {
            int selectNumber = -1;

            if (Clear)
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine();
            }

            while (true)
            {
                for (int i = 0; i < message.Length; i++)
                {
                    string printmessage = string.Format("{0}. {1}", i + 1, message[i]);
                    Console.WriteLine(printmessage);
                }

                Console.WriteLine("\n원하는 행동을 입력해주세요 : \n");

                try
                {
                    selectNumber = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    //Console.Write(ex.ToString());
                    Console.WriteLine("잘못된 입력입니다\n");
                }

                if (!(0 < selectNumber && selectNumber <= message.Length))
                {
                    selectNumber = -1;
                    Console.WriteLine("\n잘못된 숫자 입력입니다\n");
                }
                else
                {
                    break;
                }
            }

            inputNumber = selectNumber;
            return selectNumber;
        }

        public void PrintItemList(List<Item> itemList)
        {

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

    class GameCharacter
    {
        public Job job;
        public string name = "";
        public int level = 1;
        public int attackDamage = 10;
        public int armor = 5;
        public int maxHP = 100;
        public int currentHP = 100;
        public int gold = 1500;

        public List<Item> itemList = new List<Item>();

        public string[] GetCharacterInfo()
        {
            string jobName = job switch
            {
                Job.Warrior => "전사",
                Job.Thief => "도적",
            };

            string[] characterInfo = new string[]
            {
                "상태 보기",
                "캐릭터의 정보가 표시됩니다. \n",
                $"{name}",
                $"Lv. {level.ToString("00")}",
                $"Chad ( {jobName} )",
                $"공격력 : {attackDamage}",
                $"방어력 : {armor}",
                $"체 력 : {currentHP} / {maxHP}",
                $"Gold : {gold} G"
            };

            return characterInfo;
        }

        public string[] GetInventoryInfo()
        {
            string[] inventoryInfo = new string[]
            {
                "인벤토리",
                "보유 중인 아이템을 관리할 수 있습니다.\n",
                "[아이템 목록]",
            };

            foreach (var item in itemList)
            {
                string temp = item.isPlayerEquip ? "[E]" : "";
            }
            //
            return inventoryInfo;
        }

        /*public string[] GetItemString()
        {
            string []
        }*/
    }

    class Shop
    {
        public ItemManager itemManager = new ItemManager();

        public string[] GetShopItemsIntro(int playerGold)
        {
            List<string> shopList = new List<string>()
            {
                "상점",
                "필요한 아이템을 얻을 수 있는 상점입니다.\n",
                "[보유 골드]",
                $"{playerGold} G\n",
                "[아이템 목록]\n",
            };

            /*foreach (var item in itemManager.items)
            {
                shopList.Add(item.GetItemInfo());
            }*/

            return shopList.ToArray();
        }

        public string[] GetShopItemList()
        {
            List<String> shopItemList = new List<string>();

            foreach (var item in itemManager.items)
            {
                shopItemList.Add(item.GetItemInfo());
            }

            return shopItemList.ToArray();
        }

        public void BuyItem(int itemNumber)
        {

        }
    }
}
