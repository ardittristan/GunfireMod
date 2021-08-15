using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class HeroRelevanceData
    {
        public static Dictionary<string, herorelevancedataclass> relevanceList;

        public static System.Collections.Generic.Dictionary<string, Classes.HeroRelevanceDataClass> parsedAttackList =
            new System.Collections.Generic.Dictionary<string, Classes.HeroRelevanceDataClass>();

        internal static void Setup()
        {
            relevanceList = herorelevancedata.GetData();
            foreach (KeyValuePair<string, herorelevancedataclass> relevance in relevanceList)
            {
                parsedAttackList.Add(relevance.Key, new Classes.HeroRelevanceDataClass(relevance.Key, relevanceList));
            }
        }
    }
}