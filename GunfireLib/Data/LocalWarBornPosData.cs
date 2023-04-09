using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public class LocalWarBornPosData
    {
        public static Dictionary<int, localwarbornposdataclass> posList;

        public static System.Collections.Generic.Dictionary<int, Classes.LocalWarBornPosDataClass> parsedPosList =
            new System.Collections.Generic.Dictionary<int, Classes.LocalWarBornPosDataClass>();

        internal static void Setup()
        {
            posList = localwarbornposdata.GetData();
            foreach (KeyValuePair<int, localwarbornposdataclass> pos in posList)
            {
                parsedPosList.Add(pos.Key, new Classes.LocalWarBornPosDataClass(pos.Key, posList));
            }
        }
    }
}
