using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class DamageNumberData
    {
        public static Dictionary<int, damagenumberdataclass> damageNumberList;

        public static System.Collections.Generic.Dictionary<int, Classes.DamageNumberDataClass> parsedDamageNumberList =
            new System.Collections.Generic.Dictionary<int, Classes.DamageNumberDataClass>();

        internal static void Setup()
        {
            damageNumberList = damagenumberdata.GetData();
            foreach (KeyValuePair<int, damagenumberdataclass> damageNumber in damageNumberList)
            {
                parsedDamageNumberList.Add(damageNumber.Key,
                    new Classes.DamageNumberDataClass(damageNumber.Key, damageNumberList));
            }
        }
    }
}