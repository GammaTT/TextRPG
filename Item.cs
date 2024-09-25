using EnumCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{
    public class Item
    {
        public ItemType type;
        public ItemStateForShop shopItemState;

        public int armor;
        public int price;
        public int attackDamage;
        public bool isPlayerBuy;
        public bool isPlayerEquip;
        public string name;
        public string itemDescription;

        public Item(ItemType type, ItemStateForShop shopItemState, int armor, int price, int attackDamage,
            bool isPlayerBuy ,bool isPlayerEquip, string name, string itemDescription)
        {
            this.type = type;
            this.shopItemState = shopItemState;
            this.armor = armor;
            this.price = price;
            this.attackDamage = attackDamage;
            this.isPlayerBuy = isPlayerBuy;
            this.isPlayerEquip = isPlayerEquip;
            this.name = name;
            this.itemDescription = itemDescription;
        }

        public string GetItemInfo(bool shopMode)
        {
            string itemInfo = "";

            //itemInfo += "- ";

            if (isPlayerEquip)
            {
                itemInfo += " [E] ";
            }

            itemInfo += $"{name}\t";

            if (type == ItemType.Armor)
            {
                itemInfo += $"| 방어력 +{armor}  | ";
            }
            else if (type == ItemType.Weapon)
            {
                itemInfo += $"| 공격력 +{attackDamage}  | ";
            }

            itemInfo += $"{itemDescription} | ";

            if(shopMode)
            {
                switch (this.shopItemState)
                {
                    case ItemStateForShop.ShowPrice:
                        itemInfo += $"{price} G";
                        break;

                    case ItemStateForShop.Purchased:
                        itemInfo += $"구매완료";
                        break;
                    case ItemStateForShop.ShowSellPrice:
                        itemInfo += $"{(int)(price * 0.85f)} G";
                        break;
                }
            }

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
                shopItemState: ItemStateForShop.ShowPrice,
                armor: 5,
                price: 1000,
                attackDamage: 0,
                isPlayerBuy: false,
                isPlayerEquip: false,
                name: "수련자 갑옷",
                itemDescription: "수련에 도움을 주는 갑옷입니다."
            ));

            items.Add(new Item(
                type: ItemType.Armor,
                shopItemState: ItemStateForShop.ShowPrice,
                armor: 9,
                price: 1500,
                attackDamage: 0,
                isPlayerBuy: false,
                isPlayerEquip: false,
                name: "무쇠갑옷",
                itemDescription: "무쇠로 만들어져 튼튼한 갑옷입니다."
            ));

            items.Add(new Item(
                type: ItemType.Armor,
                shopItemState: ItemStateForShop.ShowPrice,
                armor: 15,
                price: 3500,
                attackDamage: 0,
                isPlayerBuy: false,
                isPlayerEquip: false,
                name: "스파르타의 갑옷",
                itemDescription: "스파르타의 전사들이 사용했다는 전설의 갑옷입니다."
            ));

            items.Add(new Item(
                type: ItemType.Armor,
                shopItemState: ItemStateForShop.ShowPrice,
                armor: 25,
                price: 6666,
                attackDamage: 0,
                isPlayerBuy: false,
                isPlayerEquip: false,
                name: "악마의 갑옷",
                itemDescription: "고대의 악마가 착용했다는 갑옷입니다."
            ));

            items.Add(new Item(
                type: ItemType.Weapon,
                shopItemState: ItemStateForShop.ShowPrice,
                armor: 0,
                price: 600,
                attackDamage: 2,
                isPlayerBuy: false,
                isPlayerEquip: false,
                name: "낡은 검",
                itemDescription: "쉽게 볼 수 있는 낡은 검입니다."
            ));

            items.Add(new Item(
                type: ItemType.Weapon,
                shopItemState: ItemStateForShop.ShowPrice,
                armor: 0,
                price: 1500,
                attackDamage: 5,
                isPlayerBuy: false,
                isPlayerEquip: false,
                name: "청동 도끼",
                itemDescription: "어디선가 사용됐던 거 같은 도끼입니다."
            ));

            items.Add(new Item(
                type: ItemType.Weapon,
                shopItemState: ItemStateForShop.ShowPrice,
                armor: 0,
                price: 5000,
                attackDamage: 7,
                isPlayerBuy: false,
                isPlayerEquip: false,
                name: "스파르타의 창",
                itemDescription: "스파르타의 전사들이 사용했다는 전설의 창입니다."
            ));
        }

        #endregion


    }
}
