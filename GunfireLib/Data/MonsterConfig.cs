using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MonsterConfig
    {
        public static Dictionary<string, monsterconfigclass> configList;

        public static System.Collections.Generic.Dictionary<string, Classes.MonsterConfigClass> parsedConfigList =
            new System.Collections.Generic.Dictionary<string, Classes.MonsterConfigClass>();

        internal static void Setup()
        {
            configList = monsterconfig_16.GetData();
            foreach (KeyValuePair<string, monsterconfigclass> config in configList)
            {
                parsedConfigList.Add(config.Key, new Classes.MonsterConfigClass(config.Key, configList));
            }
        }
    }
}