using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class GraphPaperData
    {
        public static Dictionary<string, graphpaperdataclass> graphPaperList;

        public static System.Collections.Generic.Dictionary<string, Classes.GraphPaperDataClass> parsedGraphPaperList =
            new System.Collections.Generic.Dictionary<string, Classes.GraphPaperDataClass>();

        internal static void Setup()
        {
            graphPaperList = graphpaperdata.GetData();
            foreach (KeyValuePair<string, graphpaperdataclass> graphPaper in graphPaperList)
            {
                parsedGraphPaperList.Add(graphPaper.Key, new Classes.GraphPaperDataClass(graphPaper.Key, graphPaperList));
            }
        }
    }
}