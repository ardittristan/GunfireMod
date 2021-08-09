using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    class CheekData
    {
        public static Dictionary<string, cheekdataclass> cheekList;

        public static System.Collections.Generic.Dictionary<string, Classes.CheekDataClass> parsedCheekList =
            new System.Collections.Generic.Dictionary<string, Classes.CheekDataClass>();

        internal static void Setup()
        {
            cheekList = cheekdata.GetData();
            foreach (KeyValuePair<string, cheekdataclass> cheek in cheekList)
            {
                parsedCheekList.Add(cheek.Key, new Classes.CheekDataClass(cheek.Key, cheekList));
            }
        }
    }
}
