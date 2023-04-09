using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class EnhanceData
    {
        public static Dictionary<int, enhancedataclass> enhanceList;

        public static System.Collections.Generic.Dictionary<int, Classes.EnhanceDataClass> parsedEnhanceList =
            new System.Collections.Generic.Dictionary<int, Classes.EnhanceDataClass>();

        internal static void Setup()
        {
            enhanceList = enhancedata.GetData();
            foreach (KeyValuePair<int, enhancedataclass> enhance in enhanceList)
            {
                parsedEnhanceList.Add(enhance.Key, new Classes.EnhanceDataClass(enhance.Key, enhanceList));
            }
        }
    }
}