using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class KeyItemData
    {
        public static Dictionary<int, itemdataclass> keyItemList;

        public static System.Collections.Generic.Dictionary<int, Classes.ItemDataClass> parsedKeyItemList =
            new System.Collections.Generic.Dictionary<int, Classes.ItemDataClass>();

        internal static void Setup()
        {
            keyItemList = keyitemdata.GetData();
            foreach (KeyValuePair<int, itemdataclass> keyItem in keyItemList)
            {
                parsedKeyItemList.Add(keyItem.Key, new Classes.ItemDataClass(keyItem.Key, keyItemList));
            }
        }
    }
}