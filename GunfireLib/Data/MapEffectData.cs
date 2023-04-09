using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public class MapEffectData
    {
        public static Dictionary<int, mapeffectdataclass> effectList;

        public static System.Collections.Generic.Dictionary<int, Classes.MapEffectDataClass> parsedEffectList =
            new System.Collections.Generic.Dictionary<int, Classes.MapEffectDataClass>();

        internal static void Setup()
        {
            effectList = mapeffectdata.GetData();
            foreach (KeyValuePair<int, mapeffectdataclass> effect in effectList)
            {
                parsedEffectList.Add(effect.Key, new Classes.MapEffectDataClass(effect.Key, effectList));
            }
        }
    }
}
