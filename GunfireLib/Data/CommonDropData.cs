using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class CommonDropData
    {
        public static Dictionary<int, itemdataclass> dropList;

        public static System.Collections.Generic.Dictionary<int, Classes.ItemDataClass> parsedDropList =
            new System.Collections.Generic.Dictionary<int, Classes.ItemDataClass>();

        internal static void Setup()
        {
            dropList = commondropdata.GetData();
            foreach (KeyValuePair<int, itemdataclass> drop in dropList)
            {
                parsedDropList.Add(drop.Key, new Classes.ItemDataClass(drop.Key, dropList));
            }
        }
    }
}