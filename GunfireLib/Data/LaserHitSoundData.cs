using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class LaserHitSoundData
    {
        public static Dictionary<int, laserhitsounddataclass> hitSoundList;

        public static System.Collections.Generic.Dictionary<int, Classes.LaserHitSoundDataClass> parsedHitSoundList =
            new System.Collections.Generic.Dictionary<int, Classes.LaserHitSoundDataClass>();

        internal static void Setup()
        {
            hitSoundList = laserhitsounddata.GetData();
            foreach (KeyValuePair<int, laserhitsounddataclass> hitSound in hitSoundList)
            {
                parsedHitSoundList.Add(hitSound.Key, new Classes.LaserHitSoundDataClass(hitSound.Key, hitSoundList));
            }
        }
    }
}