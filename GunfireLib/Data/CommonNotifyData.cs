using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class CommonNotifyData
    {
        public static Dictionary<int, commonnotifydataclass> notifyList;

        public static System.Collections.Generic.Dictionary<int, Classes.CommonNotifyDataClass> parsedNotifyList =
            new System.Collections.Generic.Dictionary<int, Classes.CommonNotifyDataClass>();

        internal static void Setup()
        {
            notifyList = commonnotifydata.GetData();
            foreach (KeyValuePair<int, commonnotifydataclass> notify in notifyList)
            {
                parsedNotifyList.Add(notify.Key, new Classes.CommonNotifyDataClass(notify.Key, notifyList));
            }
        }
    }
}