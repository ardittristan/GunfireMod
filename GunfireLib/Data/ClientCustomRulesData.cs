using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class ClientCustomRulesData
    {
        public static Dictionary<int, clientcustomrulesdataclass> ruleList;

        public static System.Collections.Generic.Dictionary<int, Classes.ClientCustomRulesDataClass> parsedRuleList =
            new System.Collections.Generic.Dictionary<int, Classes.ClientCustomRulesDataClass>();

        internal static void Setup()
        {
            ruleList = clientcustomrulesdata.GetData();
            foreach (KeyValuePair<int, clientcustomrulesdataclass> rule in ruleList)
            {
                parsedRuleList.Add(rule.Key, new Classes.ClientCustomRulesDataClass(rule.Key, ruleList));
            }
        }
    }
}
