using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public class MapEffectData
    {
        public static Dictionary<string, mapeffectdataclass> effectList;

        public static System.Collections.Generic.Dictionary<string, Classes.MapEffectDataClass> parsedEffectList =
            new System.Collections.Generic.Dictionary<string, Classes.MapEffectDataClass>();

        internal static void Setup()
        {
            effectList = mapeffectdata.GetData();
            foreach (KeyValuePair<string, mapeffectdataclass> effect in effectList)
            {
                parsedEffectList.Add(effect.Key, new Classes.MapEffectDataClass(effect.Key, effectList));
            }
        }
    }
}
