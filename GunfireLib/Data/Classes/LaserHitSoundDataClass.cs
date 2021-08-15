// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data.Classes
{
    public class LaserHitSoundDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, laserhitsounddataclass> hitSoundList;

        public LaserHitSoundDataClass(string key, Dictionary<string, laserhitsounddataclass> hitSoundList)
        {
            this.key = key;
            this.hitSoundList = hitSoundList;
        }

        public int AttID
        {
            get => hitSoundList[key].AttID;
        }

        // TODO:
        public Dictionary<string, OneInfo> HurtInfo
        {
            get => hitSoundList[key].HurtInfo;
        }
    }
}
