using AchievementListDictionary = Il2CppSystem.Collections.Generic.Dictionary<string, DataHelper.achievementdataclass>;
using System.Collections.Generic;

namespace GunfireLib.Data
{
    public static class AchievementData
    {
        public static AchievementListDictionary achievementList;

        internal static void Setup()
        {
            achievementList = achievementdata.GetData();
        }

        public static IReadOnlyDictionary<string, string> AchievementNames = new Dictionary<string, string>()
        {
            
        };

        public static IReadOnlyDictionary<string, string> AchievementDescriptions = new Dictionary<string, string>()
        {
            
        };
    }
}
