using StringList = System.Collections.Generic.List<string>;
using System.IO;
using DataHelper;
using GunfireLib.Utils;
using Il2CppSystem.Collections.Generic;

namespace GunfireLib.Stores
{
    internal static class AchievementDataStore
    {
        private static readonly StringList AchievementList = new StringList();

        internal static void LateSetup()
        {
            Dictionary<string, achievementdataclass> achievements = achievementdata.GetData();

            GunfireEvents.QuitEvent += SaveAchievementStore;

            foreach (KeyValuePair<string, achievementdataclass> item in achievements)
            {
                HandleAchievementStore(item.Value.Name,
                    string.IsNullOrWhiteSpace(item.Value.Desc) ? "" : item.Value.Desc);
            }
        }

        private static void SaveAchievementStore()
        {
            if (AchievementList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.LibConfigDirectory, "achievementList.txt"), AchievementList);
            }
        }

        private static void HandleAchievementStore(string name, string desc)
        {
            name = "[" + name + " | " + desc + "]";
            if (!AchievementList.Contains(name))
            {
                AchievementList.Add(name);
            }
        }
    }
}
