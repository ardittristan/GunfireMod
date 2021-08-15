using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class LimitData
    {
        public static Dictionary<string, limitdataclass> limitList;

        public static System.Collections.Generic.Dictionary<string, Classes.LimitDataClass> parsedLimitList =
            new System.Collections.Generic.Dictionary<string, Classes.LimitDataClass>();

        internal static void Setup()
        {
            limitList = limitdata.GetData();
            foreach (KeyValuePair<string, limitdataclass> limit in limitList)
            {
                parsedLimitList.Add(limit.Key, new Classes.LimitDataClass(limit.Key, limitList));
            }
        }
    }
}