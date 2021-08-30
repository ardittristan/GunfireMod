using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileStateData
    {
        public static Dictionary<string, statedataclass> stateList;

        public static System.Collections.Generic.Dictionary<string, Classes.StateDataClass> parsedStateList =
            new System.Collections.Generic.Dictionary<string, Classes.StateDataClass>();

        internal static void Setup()
        {
            stateList = mobilestatedata.GetData();
            foreach (KeyValuePair<string, statedataclass> state in stateList)
            {
                parsedStateList.Add(state.Key, new Classes.StateDataClass(state.Key, stateList));
            }
        }
    }
}