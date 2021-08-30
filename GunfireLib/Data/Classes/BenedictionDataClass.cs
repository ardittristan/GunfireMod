﻿// ReSharper disable InconsistentNaming
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
        public static string GetEnglishName(this benedictiondataclass baseClass) =>
            Classes.BenedictionDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this benedictiondataclass baseClass) =>
            Classes.BenedictionDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class BenedictionDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, benedictiondataclass> benedictionList;

        public BenedictionDataClass(string key, Dictionary<string, benedictiondataclass> benedictionList)
        {
            this.key = key;
            this.benedictionList = benedictionList;
        }

        public string Desc
        {
            get => benedictionList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(benedictionList[key].Desc);
        }

        public int IconID
        {
            get => benedictionList[key].IconID;
        }

        public int ID
        {
            get => benedictionList[key].ID;
        }

        public string Name
        {
            get => benedictionList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(benedictionList[key].Name);
        }

        public int Price
        {
            get => benedictionList[key].Price;
        }

        public int UseHero
        {
            get => benedictionList[key].UseHero;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return BenedictionNames[name];
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
                return BenedictionDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
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