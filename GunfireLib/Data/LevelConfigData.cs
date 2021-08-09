using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class LevelConfigData
    {
        public static Dictionary<string, levelconfigdataclass> levelList;

        public static System.Collections.Generic.Dictionary<string, Classes.LevelConfigDataClass> parsedLevelList =
            new System.Collections.Generic.Dictionary<string, Classes.LevelConfigDataClass>();

        internal static void Setup()
        {
            levelList = levelconfigdata.GetData();
            foreach (KeyValuePair<string, levelconfigdataclass> level in levelList)
            {
                parsedLevelList.Add(level.Key, new Classes.LevelConfigDataClass(level.Key, levelList));
            }
        }
    }
}
