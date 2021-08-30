using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MusicEffectData
    {
        public static Dictionary<string, musiceffectdataclass> effectList;

        public static System.Collections.Generic.Dictionary<string, Classes.MusicEffectDataClass> parsedEffectList =
            new System.Collections.Generic.Dictionary<string, Classes.MusicEffectDataClass>();

        internal static void Setup()
        {
            effectList = musiceffectdata.GetData();
            foreach (KeyValuePair<string, musiceffectdataclass> effect in effectList)
            {
                parsedEffectList.Add(effect.Key, new Classes.MusicEffectDataClass(effect.Key, effectList));
            }
        }
    }
}