using System;
using DataHelper;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;
using RStringDictionary = System.Collections.Generic.IReadOnlyDictionary<string, string>;
using StringDictionary = System.Collections.Generic.Dictionary<string, string>;

namespace GunfireLib.Data
{
    public static partial class Extensions
    {
        public static string GetEnglishName(this benedictiondataclass baseClass) => BenedictionData.MODbenedictiondataclass.GetEnglishName(baseClass.Name);
        public static string GetEnglishDesc(this benedictiondataclass baseClass) => BenedictionData.MODbenedictiondataclass.GetEnglishDesc(baseClass.Desc);
    }

    public static class BenedictionData
    {
        public static Dictionary<string, benedictiondataclass> benedictionList;
        public static System.Collections.Generic.Dictionary<string, MODbenedictiondataclass> parsedBenedictionList = new System.Collections.Generic.Dictionary<string, MODbenedictiondataclass>();

        internal static void Setup()
        {
            benedictionList = benedictiondata.GetData();
            foreach (KeyValuePair<string, benedictiondataclass> benediction in benedictionList)
            {
                parsedBenedictionList.Add(benediction.Key, new MODbenedictiondataclass(benediction.Key));
            }
        }

        public class MODbenedictiondataclass
        {
            private readonly string key;
            public MODbenedictiondataclass(string key) { this.key = key; }

            public string Desc { get => benedictionList[key].Desc; }
            public string EnglishDesc { get => GetEnglishDesc(benedictionList[key].Desc); }
            public int IconID { get => benedictionList[key].IconID; }
            public int ID { get => benedictionList[key].ID; }
            public string Name { get => benedictionList[key].Name; }
            public string EnglishName { get => GetEnglishName(benedictionList[key].Name); }
            public int Price { get => benedictionList[key].Price; }
            public int UseHero { get => benedictionList[key].UseHero; }

            internal static string GetEnglishName(string name)
            {
                if (string.IsNullOrWhiteSpace(name)) return "";
                try { return BenedictionNames[name]; }
                catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException) { return name; }
            }

            internal static string GetEnglishDesc(string desc)
            {
                if (string.IsNullOrWhiteSpace(desc)) return "";
                try { return BenedictionDescriptions[desc]; }
                catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException) { return desc; }
            }
        }

        public static RStringDictionary BenedictionNames = new StringDictionary()
        {

        };

        public static RStringDictionary BenedictionDescriptions = new StringDictionary()
        {

        };
    }
}
