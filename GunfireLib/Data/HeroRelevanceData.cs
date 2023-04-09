using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class HeroRelevanceData
    {
        public static Dictionary<int, herorelevancedataclass> relevanceList;

        public static System.Collections.Generic.Dictionary<int, Classes.HeroRelevanceDataClass> parsedAttackList =
            new System.Collections.Generic.Dictionary<int, Classes.HeroRelevanceDataClass>();

        internal static void Setup()
        {
            relevanceList = herorelevancedata.GetData();
            foreach (KeyValuePair<int, herorelevancedataclass> relevance in relevanceList)
            {
                parsedAttackList.Add(relevance.Key, new Classes.HeroRelevanceDataClass(relevance.Key, relevanceList));
            }
        }
    }
}