using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileCareerPfData
    {
        public static Dictionary<string, attackdataclass> attackList;

        public static System.Collections.Generic.Dictionary<string, Classes.AttackDataClass> parsedAttackList =
            new System.Collections.Generic.Dictionary<string, Classes.AttackDataClass>();

        internal static void Setup()
        {
            attackList = mobilecareerpfdata.GetData();
            foreach (KeyValuePair<string, attackdataclass> attack in attackList)
            {
                parsedAttackList.Add(attack.Key, new Classes.AttackDataClass(attack.Key, attackList));
            }
        }
    }
}