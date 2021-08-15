using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class HeroGradePfData
    {
        public static Dictionary<string, herogradepfdataclass> heroGradeList;

        public static System.Collections.Generic.Dictionary<string, Classes.HeroGradePfDataClass> parsedHeroGradePfList =
            new System.Collections.Generic.Dictionary<string, Classes.HeroGradePfDataClass>();

        internal static void Setup()
        {
            heroGradeList = herogradepfdata.GetData();
            foreach (KeyValuePair<string, herogradepfdataclass> heroGrade in heroGradeList)
            {
                parsedHeroGradePfList.Add(heroGrade.Key, new Classes.HeroGradePfDataClass(heroGrade.Key, heroGradeList));
            }
        }
    }
}