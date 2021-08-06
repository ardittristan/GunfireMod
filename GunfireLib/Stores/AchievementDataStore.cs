using StringList = System.Collections.Generic.List<string>;
using System.IO;
using DataHelper;
using GunfireLib.Utils;
using Il2CppSystem.Collections.Generic;

namespace GunfireLib.Stores
{
    internal static class AchievementDataStore
    {
        private static readonly StringList achievementList = new StringList();

        internal static void LateSetup()
        {
            Dictionary<string, achievementdataclass> achievements = achievementdata.GetData();

            GunfireEvents.QuitEvent += SaveAchievementStore;

            foreach (KeyValuePair<string, achievementdataclass> item in achievements)
            {
                HandleAchievementStore(item.Value.Name, string.IsNullOrWhiteSpace(item.Value.Desc) ? "" : item.Value.Desc);
            }
        }

        private static void SaveAchievementStore()
        {
            if (achievementList.Count > 0)
            {
                File.WriteAllLines(Path.Combine(GunfireLib.libConfigDirectory, "achievementList.txt"), achievementList);
            }
        }

        private static void HandleAchievementStore(string name, string desc)
        {
            name = "[" + name + " | " + desc + "]";
            if (!achievementList.Contains(name))
            {
                achievementList.Add(name);
            }
        }
    }
}
