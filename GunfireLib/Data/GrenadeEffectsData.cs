using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class GrenadeEffectsData
    {
        public static Dictionary<string, grenadeeffectsdataclass> grenadeEffectsList;

        public static System.Collections.Generic.Dictionary<string, Classes.GrenadeEffectsDataClass>
            parsedGrenadeEffectsList =
                new System.Collections.Generic.Dictionary<string, Classes.GrenadeEffectsDataClass>();

        internal static void Setup()
        {
            grenadeEffectsList = grenadeeffectsdata.GetData();
            foreach (KeyValuePair<string, grenadeeffectsdataclass> grenadeEffects in grenadeEffectsList)
            {
                parsedGrenadeEffectsList.Add(grenadeEffects.Key, new Classes.GrenadeEffectsDataClass(grenadeEffects.Key, grenadeEffectsList));
            }
        }
    }
}