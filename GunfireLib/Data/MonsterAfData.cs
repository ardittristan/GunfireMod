using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MonsterAfData
    {
        public static Dictionary<string, monsterafdataclass> monsterList;

        public static System.Collections.Generic.Dictionary<string, Classes.MonsterAfDataClass> parsedMonsterList =
            new System.Collections.Generic.Dictionary<string, Classes.MonsterAfDataClass>();

        internal static void Setup()
        {
            monsterList = monsterafdata.GetData();
            foreach (KeyValuePair<string, monsterafdataclass> monster in monsterList)
            {
                parsedMonsterList.Add(monster.Key, new Classes.MonsterAfDataClass(monster.Key, monsterList));
            }
        }
    }
}