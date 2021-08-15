using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class HeroData
    {
        public static Dictionary<string, herodataclass> heroList;

        public static System.Collections.Generic.Dictionary<string, Classes.HeroDataClass> parsedHeroList =
            new System.Collections.Generic.Dictionary<string, Classes.HeroDataClass>();

        internal static void Setup()
        {
            heroList = herodata.GetData();
            foreach (KeyValuePair<string, herodataclass> hero in heroList)
            {
                parsedHeroList.Add(hero.Key, new Classes.HeroDataClass(hero.Key, heroList));
            }
        }
    }
}
