using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class DrugData
    {
        public static Dictionary<string, itemdataclass> drugList;

        public static System.Collections.Generic.Dictionary<string, Classes.ItemDataClass> parsedDrugList =
            new System.Collections.Generic.Dictionary<string, Classes.ItemDataClass>();

        internal static void Setup()
        {
            drugList = drugdata.GetData();
            foreach (KeyValuePair<string, itemdataclass> drug in drugList)
            {
                parsedDrugList.Add(drug.Key, new Classes.ItemDataClass(drug.Key, drugList));
            }
        }
    }
}