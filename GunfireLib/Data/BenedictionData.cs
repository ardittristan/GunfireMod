using DataHelper;
using Il2CppSystem.Collections.Generic;

namespace GunfireLib.Data
{
    public static class BenedictionData
    {
        public static Dictionary<string, benedictiondataclass> benedictionList;

        public static System.Collections.Generic.Dictionary<string, Classes.BenedictionDataClass>
            parsedBenedictionList = new System.Collections.Generic.Dictionary<string, Classes.BenedictionDataClass>();

        internal static void Setup()
        {
            benedictionList = benedictiondata.GetData();
            foreach (KeyValuePair<string, benedictiondataclass> benediction in benedictionList)
            {
                parsedBenedictionList.Add(benediction.Key, new Classes.BenedictionDataClass(benediction.Key, benedictionList));
            }
        }
    }
}
