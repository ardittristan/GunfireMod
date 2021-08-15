using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class LaserHitSoundData
    {
        public static Dictionary<string, laserhitsounddataclass> hitSoundList;

        public static System.Collections.Generic.Dictionary<string, Classes.LaserHitSoundDataClass> parsedHitSoundList =
            new System.Collections.Generic.Dictionary<string, Classes.LaserHitSoundDataClass>();

        internal static void Setup()
        {
            hitSoundList = laserhitsounddata.GetData();
            foreach (KeyValuePair<string, laserhitsounddataclass> hitSound in hitSoundList)
            {
                parsedHitSoundList.Add(hitSound.Key, new Classes.LaserHitSoundDataClass(hitSound.Key, hitSoundList));
            }
        }
    }
}