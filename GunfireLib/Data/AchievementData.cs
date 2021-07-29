using System;
using System.Collections.Generic;
using DataHelper;
using UnhollowerBaseLib;

namespace GunfireLib.Data
{
    public static partial class Extensions
    {
        public static string GetEnglishName(this achievementdataclass baseClass) => AchievementData.MODachievementdataclass.GetEnglishName(baseClass.Name);
        public static string GetEnglishDesc(this achievementdataclass baseClass) => AchievementData.MODachievementdataclass.GetEnglishDesc(baseClass.Desc);
    }

    public static class AchievementData
    {
        public static Il2CppSystem.Collections.Generic.Dictionary<string, achievementdataclass> achievementList;
        public static Dictionary<string, MODachievementdataclass> parsedAchievementList = new Dictionary<string, MODachievementdataclass>();

        internal static void Setup()
        {
            achievementList = achievementdata.GetData();
            foreach (Il2CppSystem.Collections.Generic.KeyValuePair<string, achievementdataclass> achievement in achievementList)
            {
                parsedAchievementList.Add(achievement.Key, new MODachievementdataclass(achievement.Key));
            }
        }

        public class MODachievementdataclass
        {
            private readonly string key;
            public MODachievementdataclass(string key) { this.key = key; }

            public string Desc { get => achievementList[key].Desc; }
            public string EnglishDesc { get => GetEnglishDesc(achievementList[key].Desc); }
            public int IconID { get => achievementList[key].IconID; }
            public string Name { get => achievementList[key].Name; }
            public string EnglishName { get => GetEnglishName(achievementList[key].Name); }

            internal static string GetEnglishName(string name)
            {
                if (string.IsNullOrWhiteSpace(name)) return "";
                try { return AchievementNames[name]; }
                catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException) { return name; }
            }

            internal static string GetEnglishDesc(string desc)
            {
                if (string.IsNullOrWhiteSpace(desc)) return "";
                try { return AchievementDescriptions[desc]; }
                catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException) { return desc; }
            }
        }

        public static IReadOnlyDictionary<string, string> AchievementNames = new Dictionary<string, string>()
        {
            
        };

        public static IReadOnlyDictionary<string, string> AchievementDescriptions = new Dictionary<string, string>()
        {
            
        };
    }
}
