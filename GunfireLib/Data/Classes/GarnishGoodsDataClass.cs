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
        public static string GetEnglishName(this garnishgoodsdataclass baseClass) =>
            Classes.GarnishGoodsDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this garnishgoodsdataclass baseClass) =>
            Classes.GarnishGoodsDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class GarnishGoodsDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, garnishgoodsdataclass> goodsList;

        public GarnishGoodsDataClass(string key, Dictionary<string, garnishgoodsdataclass> goodsList)
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

        public int ID
        {
            get => goodsList[key].ID;
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
                return GoodsNames[name];
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
                return GoodsDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary GoodsNames = new StringDictionary()
        {

        };

        public static RStringDictionary GoodsDescriptions = new StringDictionary()
        {

        };
    }
}
