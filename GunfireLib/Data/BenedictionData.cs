using DataHelper;
using Il2CppSystem.Collections.Generic;

namespace GunfireLib.Data
{
    public static class BenedictionData
    {
        public static Dictionary<int, benedictiondataclass> benedictionList;

        public static System.Collections.Generic.Dictionary<int, Classes.BenedictionDataClass>
            parsedBenedictionList = new System.Collections.Generic.Dictionary<int, Classes.BenedictionDataClass>();

        internal static void Setup()
        {
            benedictionList = benedictiondata.GetData();
            foreach (KeyValuePair<int, benedictiondataclass> benediction in benedictionList)
            {
                parsedBenedictionList.Add(benediction.Key,
                    new Classes.BenedictionDataClass(benediction.Key, benedictionList));
            }
        }
    }
}
