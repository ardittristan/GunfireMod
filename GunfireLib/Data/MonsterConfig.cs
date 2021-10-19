using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MonsterConfig
    {
        public static Dictionary<int, monsterconfigclass> configList;

        public static System.Collections.Generic.Dictionary<int, Classes.MonsterConfigClass> parsedConfigList =
            new System.Collections.Generic.Dictionary<int, Classes.MonsterConfigClass>();

        internal static void Setup()
        {
            configList = monsterconfig_16.GetData();
            foreach (KeyValuePair<int, monsterconfigclass> config in configList)
            {
                parsedConfigList.Add(config.Key, new Classes.MonsterConfigClass(config.Key, configList));
            }
        }
    }
}