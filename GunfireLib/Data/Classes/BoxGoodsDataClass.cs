// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using System;
using Il2CppSystem.Collections.Generic;
using DataHelper;
using UnhollowerBaseLib;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;
using StringDictionary = System.Collections.Generic.Dictionary<string, string>;
using RStringDictionary = System.Collections.Generic.IReadOnlyDictionary<string, string>;

namespace GunfireLib.Data.Extensions
{
    public static partial class Extensions
    {
        public static string GetEnglishName(this boxgoodsdataclass baseClass) =>
            Classes.BoxGoodsDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this boxgoodsdataclass baseClass) =>
            Classes.BoxGoodsDataClass.GetEnglishDesc(baseClass.Desc);

        public static string GetItemQuality(this boxgoodsdataclass baseClass) =>
            Classes.BoxGoodsDataClass.GetEnglishItemQuality(baseClass.ItemQuality);
    }
}

namespace GunfireLib.Data.Classes
{
    public class BoxGoodsDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, boxgoodsdataclass> goodsList;

        public BoxGoodsDataClass(int key, Dictionary<int, boxgoodsdataclass> goodsList)
        {
            this.key = key;
            this.goodsList = goodsList;
        }

        public int CanGold
        {
            get => goodsList[key].CanGold;
        }

        public string Desc
        {
            get => goodsList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(goodsList[key].Desc);
        }

        // TODO:
        public SGiftReward GiftReward
        {
            get => goodsList[key].GiftReward;
        }

        public int Gold
        {
            get => goodsList[key].Gold;
        }

        public int GoldPrice
        {
            get => goodsList[key].GoldPrice;
        }

        public int IconID
        {
            get => goodsList[key].IconID;
        }

        public string ItemQuality
        {
            get => goodsList[key].ItemQuality;
        }

        public string EnglishItemQuality
        {
            get => GetEnglishItemQuality(goodsList[key].ItemQuality);
        }

        public string Name
        {
            get => goodsList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(goodsList[key].Name);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return BoxGoodsNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        internal static string GetEnglishDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return BoxGoodsDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        internal static string GetEnglishItemQuality(string quality)
        {
            if (string.IsNullOrWhiteSpace(quality)) return "";
            try
            {
                return BoxGoodsQualities[quality];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return quality;
            }
        }

        public static RStringDictionary BoxGoodsNames = new StringDictionary()
        {

        };

        public static RStringDictionary BoxGoodsDescriptions = new StringDictionary()
        {

        };

        public static RStringDictionary BoxGoodsQualities = new StringDictionary()
        {

        };
    }
}
