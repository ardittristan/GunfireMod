using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileRelicData
    {
        public static Dictionary<string, itemdataclass> itemList;

        public static System.Collections.Generic.Dictionary<string, Classes.ItemDataClass> parsedItemList =
            new System.Collections.Generic.Dictionary<string, Classes.ItemDataClass>();

        internal static void Setup()
        {
            itemList = mobilerelicdata.GetData();
            foreach (KeyValuePair<string, itemdataclass> item in itemList)
            {
                parsedItemList.Add(item.Key, new Classes.ItemDataClass(item.Key, itemList));
            }
        }
    }
}