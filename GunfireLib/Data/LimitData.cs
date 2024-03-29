﻿using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class LimitData
    {
        public static Dictionary<int, limitdataclass> limitList;

        public static System.Collections.Generic.Dictionary<int, Classes.LimitDataClass> parsedLimitList =
            new System.Collections.Generic.Dictionary<int, Classes.LimitDataClass>();

        internal static void Setup()
        {
            limitList = limitdata.GetData();
            foreach (KeyValuePair<int, limitdataclass> limit in limitList)
            {
                parsedLimitList.Add(limit.Key, new Classes.LimitDataClass(limit.Key, limitList));
            }
        }
    }
}