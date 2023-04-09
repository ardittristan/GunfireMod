using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class HeroData
    {
        public static Dictionary<int, herodataclass> heroList;

        public static System.Collections.Generic.Dictionary<int, Classes.HeroDataClass> parsedHeroList =
            new System.Collections.Generic.Dictionary<int, Classes.HeroDataClass>();

        internal static void Setup()
        {
            heroList = herodata.GetData();
            foreach (KeyValuePair<int, herodataclass> hero in heroList)
            {
                parsedHeroList.Add(hero.Key, new Classes.HeroDataClass(hero.Key, heroList));
            }
        }
    }
}
