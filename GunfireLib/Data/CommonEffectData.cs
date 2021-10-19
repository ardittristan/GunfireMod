using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class CommonEffectData
    {
        public static Dictionary<int, commoneffectdataclass> effectList;

        public static System.Collections.Generic.Dictionary<int, Classes.CommonEffectDataClass> parsedEffectList =
            new System.Collections.Generic.Dictionary<int, Classes.CommonEffectDataClass>();

        internal static void Setup()
        {
            effectList = commoneffectdata.GetData();
            foreach (KeyValuePair<int, commoneffectdataclass> effect in effectList)
            {
                parsedEffectList.Add(effect.Key, new Classes.CommonEffectDataClass(effect.Key, effectList));
            }
        }
    }
}