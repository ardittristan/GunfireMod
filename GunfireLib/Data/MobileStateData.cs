using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileStateData
    {
        public static Dictionary<int, statedataclass> stateList;

        public static System.Collections.Generic.Dictionary<int, Classes.StateDataClass> parsedStateList =
            new System.Collections.Generic.Dictionary<int, Classes.StateDataClass>();

        internal static void Setup()
        {
            stateList = mobilestatedata.GetData();
            foreach (KeyValuePair<int, statedataclass> state in stateList)
            {
                parsedStateList.Add(state.Key, new Classes.StateDataClass(state.Key, stateList));
            }
        }
    }
}