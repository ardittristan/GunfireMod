using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public class LocalWarBornPosData
    {
        public static Dictionary<string, localwarbornposdataclass> posList;

        public static System.Collections.Generic.Dictionary<string, Classes.LocalWarBornPosDataClass> parsedPosList =
            new System.Collections.Generic.Dictionary<string, Classes.LocalWarBornPosDataClass>();

        internal static void Setup()
        {
            posList = localwarbornposdata.GetData();
            foreach (KeyValuePair<string, localwarbornposdataclass> pos in posList)
            {
                parsedPosList.Add(pos.Key, new Classes.LocalWarBornPosDataClass(pos.Key, posList));
            }
        }
    }
}
