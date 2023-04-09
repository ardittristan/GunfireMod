using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class RelicData
    {
        public static Dictionary<int, itemdataclass> relicList;

        public static System.Collections.Generic.Dictionary<int, Classes.ItemDataClass> parsedRelicList =
            new System.Collections.Generic.Dictionary<int, Classes.ItemDataClass>();

        internal static void Setup()
        {
            relicList = relicdata.GetData();
            foreach (KeyValuePair<int, itemdataclass> relic in relicList)
            {
                parsedRelicList.Add(relic.Key, new Classes.ItemDataClass(relic.Key, relicList));
            }
        }
    }
}