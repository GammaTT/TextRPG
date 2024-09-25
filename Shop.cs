using EnumCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{
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

        public string[] GetShopItemsIntroForBuy(int playerGold)
        {
            List<string> shopList = new List<string>()
            {
                "상점",
                "필요한 아이템을 얻을 수 있는 상점입니다.\n",
                "[보유 골드]",
                $"{playerGold} G\n",
                "[아이템 목록 | 원하는 아이템 구매]\n",
            };

            /*foreach (var item in itemManager.items)
            {
                shopList.Add(item.GetItemInfo());
            }*/

            return shopList.ToArray();
        }

        public string[] GetShopItemsIntroForSell(int playerGold)
        {
            List<string> shopList = new List<string>()
            {
                "상점",
                "필요한 아이템을 얻을 수 있는 상점입니다.\n",
                "[보유 골드]",
                $"{playerGold} G\n",
                "[아이템 목록 | 원하는 아이템 판매]\n",
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
                shopItemList.Add(item.GetItemInfo(true));
            }

            return shopItemList.ToArray();
        }

        public string[] GetShopItemListForSell()
        {
            List<String> shopItemList = new List<string>();

            foreach (var item in itemManager.items)
            {
                ItemStateForShop state = item.shopItemState;
                item.shopItemState = ItemStateForShop.ShowSellPrice;
                shopItemList.Add(item.GetItemInfo(true));
                item.shopItemState = state;

            }

            return shopItemList.ToArray();
        }

        public bool BuyItem(GameCharacter player, int itemNumber)
        {
            Item selectedItem = itemManager.items[itemNumber - 1];

            //이미 구매한거면 리턴 false
            if (selectedItem.isPlayerBuy == true)
            {
                return false;
            }

            if (player.gold >= selectedItem.price)
            {
                player.gold -= selectedItem.price;
                player.itemList.Add(selectedItem);
                selectedItem.isPlayerBuy = true;
                selectedItem.shopItemState = ItemStateForShop.Purchased;

                return true;
            }
            else
            {
                return false;
            }
        }

        public void SellItem(GameCharacter player, int selectItemNumber)
        {
            Item selectedItem = player.itemList[selectItemNumber - 1];

            player.gold += (int)(selectedItem.price * 0.85f);

            Console.WriteLine("아이템을 판매하여 {0} G 획득", (int)(selectedItem.price * 0.85f));
            Console.ReadLine();

            if (player.equipWeapon == selectedItem)
            {
                player.attackDamage -= player.equipWeapon.attackDamage;
                player.equipWeapon = null;
            }

            if (player.equipArmor == selectedItem)
            {
                player.armor -= player.equipArmor.armor;
                player.equipArmor = null;
            }

            selectedItem.shopItemState = ItemStateForShop.ShowPrice;
            selectedItem.isPlayerBuy = false;
            selectedItem.isPlayerEquip = false;
            player.itemList.Remove(selectedItem);

        }
    }

}
