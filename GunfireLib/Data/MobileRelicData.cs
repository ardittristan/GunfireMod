using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileRelicData
    {
        public static Dictionary<int, itemdataclass> itemList;

        public static System.Collections.Generic.Dictionary<int, Classes.ItemDataClass> parsedItemList =
            new System.Collections.Generic.Dictionary<int, Classes.ItemDataClass>();

        internal static void Setup()
        {
            itemList = mobilerelicdata.GetData();
            foreach (KeyValuePair<int, itemdataclass> item in itemList)
            {
                parsedItemList.Add(item.Key, new Classes.ItemDataClass(item.Key, itemList));
            }
        }
    }
}