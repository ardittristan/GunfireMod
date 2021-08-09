using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class ClientCustomRulesData
    {
        public static Dictionary<string, clientcustomrulesdataclass> ruleList;

        public static System.Collections.Generic.Dictionary<string, Classes.ClientCustomRulesDataClass> parsedRuleList =
            new System.Collections.Generic.Dictionary<string, Classes.ClientCustomRulesDataClass>();

        internal static void Setup()
        {
            ruleList = clientcustomrulesdata.GetData();
            foreach (KeyValuePair<string, clientcustomrulesdataclass> rule in ruleList)
            {
                parsedRuleList.Add(rule.Key, new Classes.ClientCustomRulesDataClass(rule.Key, ruleList));
            }
        }
    }
}
