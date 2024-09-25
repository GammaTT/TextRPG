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

        public string[] GetShopItemList()
        {
            List<String> shopItemList = new List<string>();

            foreach (var item in itemManager.items)
            {
                shopItemList.Add(item.GetItemInfo());
            }

            return shopItemList.ToArray();
        }

        public bool BuyItem(GameCharacter player, int itemNumber)
        {
            Item selectedItem = itemManager.items[itemNumber - 1];

            if (player.gold >= selectedItem.price)
            {
                player.gold -= selectedItem.price;
                player.itemList.Add(selectedItem);

                return true;
            }
            else
            {
                return false;
            }

        }
    }

}
