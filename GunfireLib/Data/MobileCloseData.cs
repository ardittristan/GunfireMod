using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileCloseData
    {
        public static Dictionary<string, closedataclass> closeList;

        public static System.Collections.Generic.Dictionary<string, Classes.CloseDataClass> parsedCloseList =
            new System.Collections.Generic.Dictionary<string, Classes.CloseDataClass>();

        internal static void Setup()
        {
            closeList = mobileclosedata.GetData();
            foreach (KeyValuePair<string, closedataclass> close in closeList)
            {
                parsedCloseList.Add(close.Key, new Classes.CloseDataClass(close.Key, closeList));
            }
        }
    }
}