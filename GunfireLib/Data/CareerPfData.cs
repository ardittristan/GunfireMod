using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class CareerPfData
    {
        public static Dictionary<int, attackdataclass> attackList;

        public static System.Collections.Generic.Dictionary<int, Classes.AttackDataClass> parsedAttackList =
            new System.Collections.Generic.Dictionary<int, Classes.AttackDataClass>();

        internal static void Setup()
        {
            attackList = careerpfdata.GetData();
            foreach (KeyValuePair<int, attackdataclass> attack in attackList)
            {
                parsedAttackList.Add(attack.Key, new Classes.AttackDataClass(attack.Key, attackList));
            }
        }
    }
}