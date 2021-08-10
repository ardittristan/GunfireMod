using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class EANoticeData
    {
        public static Dictionary<string, eanoticedataclass> noticeList;

        public static System.Collections.Generic.Dictionary<string, Classes.EANoticeDataClass> parsedNoticeList =
            new System.Collections.Generic.Dictionary<string, Classes.EANoticeDataClass>();

        internal static void Setup()
        {
            noticeList = eanoticedata.GetData();
            foreach (KeyValuePair<string, eanoticedataclass> notice in noticeList)
            {
                parsedNoticeList.Add(notice.Key, new Classes.EANoticeDataClass(notice.Key, noticeList));
            }
        }
    }
}