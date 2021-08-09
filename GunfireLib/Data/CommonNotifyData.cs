using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class CommonNotifyData
    {
        public static Dictionary<string, commonnotifydataclass> notifyList;

        public static System.Collections.Generic.Dictionary<string, Classes.CommonNotifyDataClass> parsedNotifyList =
            new System.Collections.Generic.Dictionary<string, Classes.CommonNotifyDataClass>();

        internal static void Setup()
        {
            notifyList = commonnotifydata.GetData();
            foreach (KeyValuePair<string, commonnotifydataclass> notify in notifyList)
            {
                parsedNotifyList.Add(notify.Key, new Classes.CommonNotifyDataClass(notify.Key, notifyList));
            }
        }
    }
}