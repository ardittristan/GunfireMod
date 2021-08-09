using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class CommonEffectData
    {
        public static Dictionary<string, commoneffectdataclass> effectList;

        public static System.Collections.Generic.Dictionary<string, Classes.CommonEffectDataClass> parsedEffectList =
            new System.Collections.Generic.Dictionary<string, Classes.CommonEffectDataClass>();

        internal static void Setup()
        {
            effectList = commoneffectdata.GetData();
            foreach (KeyValuePair<string, commoneffectdataclass> effect in effectList)
            {
                parsedEffectList.Add(effect.Key, new Classes.CommonEffectDataClass(effect.Key, effectList));
            }
        }
    }
}