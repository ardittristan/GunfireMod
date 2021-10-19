using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class GrenadeEffectsData
    {
        public static Dictionary<int, grenadeeffectsdataclass> grenadeEffectsList;

        public static System.Collections.Generic.Dictionary<int, Classes.GrenadeEffectsDataClass>
            parsedGrenadeEffectsList =
                new System.Collections.Generic.Dictionary<int, Classes.GrenadeEffectsDataClass>();

        internal static void Setup()
        {
            grenadeEffectsList = grenadeeffectsdata.GetData();
            foreach (KeyValuePair<int, grenadeeffectsdataclass> grenadeEffects in grenadeEffectsList)
            {
                parsedGrenadeEffectsList.Add(grenadeEffects.Key, new Classes.GrenadeEffectsDataClass(grenadeEffects.Key, grenadeEffectsList));
            }
        }
    }
}