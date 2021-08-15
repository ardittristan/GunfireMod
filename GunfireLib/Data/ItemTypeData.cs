using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class ItemTypeData
    {
        public static Dictionary<string, itemdataclass> typeList;

        public static System.Collections.Generic.Dictionary<string, Classes.ItemDataClass> parsedTypeList =
            new System.Collections.Generic.Dictionary<string, Classes.ItemDataClass>();

        internal static void Setup()
        {
            typeList = itemtypedata.GetData();
            foreach (KeyValuePair<string, itemdataclass> type in typeList)
            {
                parsedTypeList.Add(type.Key, new Classes.ItemDataClass(type.Key, typeList));
            }
        }
    }
}