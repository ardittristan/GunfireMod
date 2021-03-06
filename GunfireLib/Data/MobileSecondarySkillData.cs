using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileSecondarySkillData
    {
        public static Dictionary<int, attackdataclass> attackList;

        public static System.Collections.Generic.Dictionary<int, Classes.AttackDataClass> parsedAttackList =
            new System.Collections.Generic.Dictionary<int, Classes.AttackDataClass>();

        internal static void Setup()
        {
            attackList = mobilesecondaryskilldata.GetData();
            foreach (KeyValuePair<int, attackdataclass> attack in attackList)
            {
                parsedAttackList.Add(attack.Key, new Classes.AttackDataClass(attack.Key, attackList));
            }
        }
    }
}