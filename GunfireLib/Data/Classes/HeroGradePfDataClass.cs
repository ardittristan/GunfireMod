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
        public static string GetEnglishName(this herogradepfdataclass baseClass) =>
            Classes.HeroGradePfDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this herogradepfdataclass baseClass) =>
            Classes.HeroGradePfDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class HeroGradePfDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, herogradepfdataclass> heroGradeList;

        public HeroGradePfDataClass(string key, Dictionary<string, herogradepfdataclass> heroGradeList)
        {
            this.key = key;
            this.heroGradeList = heroGradeList;
        }

        public string Desc
        {
            get => heroGradeList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(heroGradeList[key].Desc);
        }

        public int GraphPaperID
        {
            get => heroGradeList[key].GraphPaperID;
        }

        public string Name
        {
            get => heroGradeList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(heroGradeList[key].Name);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return HeroGradeNames[name];
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
                return HeroGradeDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary HeroGradeNames = new StringDictionary()
        {

        };

        public static RStringDictionary HeroGradeDescriptions = new StringDictionary()
        {

        };
    }
}
