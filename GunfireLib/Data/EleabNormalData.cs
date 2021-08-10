using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class EleabNormalData
    {
        public static Dictionary<string, eleabnormaldataclass> eleabList;

        public static System.Collections.Generic.Dictionary<string, Classes.EleabNormalDataClass> parsedEleabList =
            new System.Collections.Generic.Dictionary<string, Classes.EleabNormalDataClass>();

        internal static void Setup()
        {
            eleabList = eleabnormaldata.GetData();
            foreach (KeyValuePair<string, eleabnormaldataclass> eleab in eleabList)
            {
                parsedEleabList.Add(eleab.Key, new Classes.EleabNormalDataClass(eleab.Key, eleabList));
            }
        }
    }
}