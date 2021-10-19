using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class GraphPaperData
    {
        public static Dictionary<int, graphpaperdataclass> graphPaperList;

        public static System.Collections.Generic.Dictionary<int, Classes.GraphPaperDataClass> parsedGraphPaperList =
            new System.Collections.Generic.Dictionary<int, Classes.GraphPaperDataClass>();

        internal static void Setup()
        {
            graphPaperList = graphpaperdata.GetData();
            foreach (KeyValuePair<int, graphpaperdataclass> graphPaper in graphPaperList)
            {
                parsedGraphPaperList.Add(graphPaper.Key, new Classes.GraphPaperDataClass(graphPaper.Key, graphPaperList));
            }
        }
    }
}