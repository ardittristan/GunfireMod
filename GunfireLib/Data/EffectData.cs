using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class EffectData
    {
        public static Dictionary<int, effectdataclass> effectList;

        public static System.Collections.Generic.Dictionary<int, Classes.EffectDataClass> parsedEffectList =
            new System.Collections.Generic.Dictionary<int, Classes.EffectDataClass>();

        internal static void Setup()
        {
            effectList = effectdata.GetData();
            foreach (KeyValuePair<int, effectdataclass> effect in effectList)
            {
                parsedEffectList.Add(effect.Key, new Classes.EffectDataClass(effect.Key, effectList));
            }
        }
    }
}