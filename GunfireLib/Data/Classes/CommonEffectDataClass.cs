﻿// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data.Classes
{
    public class CommonEffectDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, commoneffectdataclass> effectList;

        public CommonEffectDataClass(int key, Dictionary<int, commoneffectdataclass> effectList)
        {
            this.key = key;
            this.effectList = effectList;
        }

        public int AttID
        {
            get => effectList[key].AttID;
        }

        public int BulletEffectID
        {
            get => effectList[key].BulletEffectID;
        }

        // TODO:
        public Dictionary<string, BulletElementSoundInfo> BulletElementSound
        {
            get => effectList[key].BulletElementSound;
        }

        public int ElementID
        {
            get => effectList[key].ElementID;
        }

        // TODO:
        public Dictionary<string, OneInfo> HurtInfo
        {
            get => effectList[key].HurtInfo;
        }

        public int MuzzleEffectID
        {
            get => effectList[key].MuzzleEffectID;
        }

        public string MuzzleSound
        {
            get => effectList[key].MuzzleSound;
        }

        public string ReloadSound
        {
            get => effectList[key].ReloadSound;
        }
    }
}
