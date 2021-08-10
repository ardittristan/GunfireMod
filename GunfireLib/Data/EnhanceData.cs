using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class EnhanceData
    {
        public static Dictionary<string, enhancedataclass> enhanceList;

        public static System.Collections.Generic.Dictionary<string, Classes.EnhanceDataClass> parsedEnhanceList =
            new System.Collections.Generic.Dictionary<string, Classes.EnhanceDataClass>();

        internal static void Setup()
        {
            enhanceList = enhancedata.GetData();
            foreach (KeyValuePair<string, enhancedataclass> enhance in enhanceList)
            {
                parsedEnhanceList.Add(enhance.Key, new Classes.EnhanceDataClass(enhance.Key, enhanceList));
            }
        }
    }
}