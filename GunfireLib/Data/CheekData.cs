using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class CheekData
    {
        public static Dictionary<int, cheekdataclass> cheekList;

        public static System.Collections.Generic.Dictionary<int, Classes.CheekDataClass> parsedCheekList =
            new System.Collections.Generic.Dictionary<int, Classes.CheekDataClass>();

        internal static void Setup()
        {
            cheekList = cheekdata.GetData();
            foreach (KeyValuePair<int, cheekdataclass> cheek in cheekList)
            {
                parsedCheekList.Add(cheek.Key, new Classes.CheekDataClass(cheek.Key, cheekList));
            }
        }
    }
}
