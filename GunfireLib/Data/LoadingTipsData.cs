using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public class LoadingTipsData
    {
        public static Dictionary<int, loadingtipsdataclass> loadingTipsList;

        public static System.Collections.Generic.Dictionary<int, Classes.LoadingTipsDataClass> parsedLoadingTipsList =
            new System.Collections.Generic.Dictionary<int, Classes.LoadingTipsDataClass>();

        internal static void Setup()
        {
            loadingTipsList = loadingtipsdata.GetData();
            foreach (KeyValuePair<int, loadingtipsdataclass> loadingTips in loadingTipsList)
            {
                parsedLoadingTipsList.Add(loadingTips.Key, new Classes.LoadingTipsDataClass(loadingTips.Key, loadingTipsList));
            }
        }
    }
}
