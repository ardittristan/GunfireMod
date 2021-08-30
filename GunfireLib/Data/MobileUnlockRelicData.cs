using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileUnlockRelicData
    {
        public static Dictionary<string, unlockdataclass> unlockList;

        public static System.Collections.Generic.Dictionary<string, Classes.UnlockDataClass> parsedUnlockList =
            new System.Collections.Generic.Dictionary<string, Classes.UnlockDataClass>();

        internal static void Setup()
        {
            unlockList = mobileunlockrelicdata.GetData();
            foreach (KeyValuePair<string, unlockdataclass> unlock in unlockList)
            {
                parsedUnlockList.Add(unlock.Key, new Classes.UnlockDataClass(unlock.Key, unlockList));
            }
        }
    }
}