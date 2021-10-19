using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class EleabNormalData
    {
        public static Dictionary<int, eleabnormaldataclass> eleabList;

        public static System.Collections.Generic.Dictionary<int, Classes.EleabNormalDataClass> parsedEleabList =
            new System.Collections.Generic.Dictionary<int, Classes.EleabNormalDataClass>();

        internal static void Setup()
        {
            eleabList = eleabnormaldata.GetData();
            foreach (KeyValuePair<int, eleabnormaldataclass> eleab in eleabList)
            {
                parsedEleabList.Add(eleab.Key, new Classes.EleabNormalDataClass(eleab.Key, eleabList));
            }
        }
    }
}