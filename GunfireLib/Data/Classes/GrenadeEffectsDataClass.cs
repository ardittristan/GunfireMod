// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data.Classes
{
    public class GrenadeEffectsDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, grenadeeffectsdataclass> effectList;

        public GrenadeEffectsDataClass(int key, Dictionary<int, grenadeeffectsdataclass> effectList)
        {
            this.key = key;
            this.effectList = effectList;
        }

        public int AttID
        {
            get => effectList[key].AttID;
        }

        public int BoomEffectID
        {
            get => effectList[key].BoomEffectID;
        }

        public int BoomHitEffectID
        {
            get => effectList[key].BoomHitEffectID;
        }

        public string BoomSound
        {
            get => effectList[key].BoomSound;
        }

        public int BulletEffectID
        {
            get => effectList[key].BulletEffectID;
        }

        public int ElementID
        {
            get => effectList[key].ElementID;
        }

        public int ModelID
        {
            get => effectList[key].ModelID;
        }

        public string MuzzleSound
        {
            get => effectList[key].MuzzleSound;
        }

        public int SpringHitEffectID
        {
            get => effectList[key].SpringHitEffectID;
        }

        public string SpringHitSound
        {
            get => effectList[key].SpringHitSound;
        }
    }
}
