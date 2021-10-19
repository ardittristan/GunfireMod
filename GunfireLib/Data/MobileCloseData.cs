using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileCloseData
    {
        public static Dictionary<int, closedataclass> closeList;

        public static System.Collections.Generic.Dictionary<int, Classes.CloseDataClass> parsedCloseList =
            new System.Collections.Generic.Dictionary<int, Classes.CloseDataClass>();

        internal static void Setup()
        {
            closeList = mobileclosedata.GetData();
            foreach (KeyValuePair<int, closedataclass> close in closeList)
            {
                parsedCloseList.Add(close.Key, new Classes.CloseDataClass(close.Key, closeList));
            }
        }
    }
}