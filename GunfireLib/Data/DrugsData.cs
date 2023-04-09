using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class DrugData
    {
        public static Dictionary<int, itemdataclass> drugList;

        public static System.Collections.Generic.Dictionary<int, Classes.ItemDataClass> parsedDrugList =
            new System.Collections.Generic.Dictionary<int, Classes.ItemDataClass>();

        internal static void Setup()
        {
            drugList = drugdata.GetData();
            foreach (KeyValuePair<int, itemdataclass> drug in drugList)
            {
                parsedDrugList.Add(drug.Key, new Classes.ItemDataClass(drug.Key, drugList));
            }
        }
    }
}