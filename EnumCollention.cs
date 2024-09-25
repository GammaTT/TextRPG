using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumCollection
{
    public enum Scene
    {
        InitScene = 0,
    }

    public enum Job
    {
        Warrior = 1,
        Thief
    }

    public enum ItemType
    {
        Armor = 1,
        Weapon = 2,
    }

    public enum ItemStateForShop
    {
        None = 0,
        ShowPrice,
        Purchased,
        ShowSellPrice
    }

    public enum ShopMode
    {
        ShowPrice = 0,
        ShowSellPrice
    }
}
