using Il2Cpp;
using Il2CppDataHelper;
using Il2CppSystem.Collections.Generic;

namespace GunfireLib.Data
{
    public static class AchievementData
    {
        public static Dictionary<string, achievementdataclass> achievementList;

        public static System.Collections.Generic.Dictionary<string, Classes.AchievementDataClass>
            parsedAchievementList = new System.Collections.Generic.Dictionary<string, Classes.AchievementDataClass>();

        internal static void Setup()
        {
            achievementList = achievementdata.GetData();
            foreach (KeyValuePair<string, achievementdataclass> achievement in achievementList)
            {
                parsedAchievementList.Add(achievement.Key,
                    new Classes.AchievementDataClass(achievement.Key, achievementList));
            }
        }

        
    }
}
