using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class EANoticeData
    {
        public static Dictionary<int, eanoticedataclass> noticeList;

        public static System.Collections.Generic.Dictionary<int, Classes.EANoticeDataClass> parsedNoticeList =
            new System.Collections.Generic.Dictionary<int, Classes.EANoticeDataClass>();

        internal static void Setup()
        {
            noticeList = eanoticedata.GetData();
            foreach (KeyValuePair<int, eanoticedataclass> notice in noticeList)
            {
                parsedNoticeList.Add(notice.Key, new Classes.EANoticeDataClass(notice.Key, noticeList));
            }
        }
    }
}