using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class LevelConfigData
    {
        public static Dictionary<int, levelconfigdataclass> levelList;

        public static System.Collections.Generic.Dictionary<int, Classes.LevelConfigDataClass> parsedLevelList =
            new System.Collections.Generic.Dictionary<int, Classes.LevelConfigDataClass>();

        internal static void Setup()
        {
            levelList = levelconfigdata.GetData();
            foreach (KeyValuePair<int, levelconfigdataclass> level in levelList)
            {
                parsedLevelList.Add(level.Key, new Classes.LevelConfigDataClass(level.Key, levelList));
            }
        }
    }
}
