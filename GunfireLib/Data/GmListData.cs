using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class GmListData
    {
        public static Dictionary<int, gmlistdataclass> gmList;

        public static System.Collections.Generic.Dictionary<int, Classes.GmListDataClass> parsedGmList =
            new System.Collections.Generic.Dictionary<int, Classes.GmListDataClass>();

        internal static void Setup()
        {
            gmList = gmlistdata.GetData();
            foreach (KeyValuePair<int, gmlistdataclass> gm in gmList)
            {
                parsedGmList.Add(gm.Key, new Classes.GmListDataClass(gm.Key, gmList));
            }
        }
    }
}