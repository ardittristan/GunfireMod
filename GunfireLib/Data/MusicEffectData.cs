using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MusicEffectData
    {
        public static Dictionary<int, musiceffectdataclass> effectList;

        public static System.Collections.Generic.Dictionary<int, Classes.MusicEffectDataClass> parsedEffectList =
            new System.Collections.Generic.Dictionary<int, Classes.MusicEffectDataClass>();

        internal static void Setup()
        {
            effectList = musiceffectdata.GetData();
            foreach (KeyValuePair<int, musiceffectdataclass> effect in effectList)
            {
                parsedEffectList.Add(effect.Key, new Classes.MusicEffectDataClass(effect.Key, effectList));
            }
        }
    }
}