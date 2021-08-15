using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class KeyItemData
    {
        public static Dictionary<string, itemdataclass> keyItemList;

        public static System.Collections.Generic.Dictionary<string, Classes.ItemDataClass> parsedKeyItemList =
            new System.Collections.Generic.Dictionary<string, Classes.ItemDataClass>();

        internal static void Setup()
        {
            keyItemList = keyitemdata.GetData();
            foreach (KeyValuePair<string, itemdataclass> keyItem in keyItemList)
            {
                parsedKeyItemList.Add(keyItem.Key, new Classes.ItemDataClass(keyItem.Key, keyItemList));
            }
        }
    }
}