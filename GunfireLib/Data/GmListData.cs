using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class GmListData
    {
        public static Dictionary<string, gmlistdataclass> gmList;

        public static System.Collections.Generic.Dictionary<string, Classes.GmListDataClass> parsedGmList =
            new System.Collections.Generic.Dictionary<string, Classes.GmListDataClass>();

        internal static void Setup()
        {
            gmList = gmlistdata.GetData();
            foreach (KeyValuePair<string, gmlistdataclass> gm in gmList)
            {
                parsedGmList.Add(gm.Key, new Classes.GmListDataClass(gm.Key, gmList));
            }
        }
    }
}