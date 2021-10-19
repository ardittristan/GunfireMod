using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class HeroGradePfData
    {
        public static Dictionary<int, herogradepfdataclass> heroGradeList;

        public static System.Collections.Generic.Dictionary<int, Classes.HeroGradePfDataClass> parsedHeroGradePfList =
            new System.Collections.Generic.Dictionary<int, Classes.HeroGradePfDataClass>();

        internal static void Setup()
        {
            heroGradeList = herogradepfdata.GetData();
            foreach (KeyValuePair<int, herogradepfdataclass> heroGrade in heroGradeList)
            {
                parsedHeroGradePfList.Add(heroGrade.Key, new Classes.HeroGradePfDataClass(heroGrade.Key, heroGradeList));
            }
        }
    }
}