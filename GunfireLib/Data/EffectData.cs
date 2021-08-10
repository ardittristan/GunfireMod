using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class EffectData
    {
        public static Dictionary<string, effectdataclass> effectList;

        public static System.Collections.Generic.Dictionary<string, Classes.EffectDataClass> parsedEffectList =
            new System.Collections.Generic.Dictionary<string, Classes.EffectDataClass>();

        internal static void Setup()
        {
            effectList = effectdata.GetData();
            foreach (KeyValuePair<string, effectdataclass> effect in effectList)
            {
                parsedEffectList.Add(effect.Key, new Classes.EffectDataClass(effect.Key, effectList));
            }
        }
    }
}