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
        public static string GetEnglishName(this achievementdataclass baseClass) =>
            Classes.AchievementDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this achievementdataclass baseClass) =>
            Classes.AchievementDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class AchievementDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, achievementdataclass> achievementList;

        public AchievementDataClass(string key, Dictionary<string, achievementdataclass> achievementList)
        {
            this.key = key;
            this.achievementList = achievementList;
        }

        public string Desc
        {
            get => achievementList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(achievementList[key].Desc);
        }

        public int IconID
        {
            get => achievementList[key].IconID;
        }

        public string Name
        {
            get => achievementList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(achievementList[key].Name);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return AchievementNames[name];
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
                return AchievementDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary AchievementNames = new StringDictionary()
        {

        };

        public static RStringDictionary AchievementDescriptions = new StringDictionary()
        {

        };
    }
}
