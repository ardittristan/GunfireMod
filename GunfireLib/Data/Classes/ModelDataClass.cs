﻿// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using System;
using Il2CppSystem.Collections.Generic;
using DataHelper;
using UnhollowerBaseLib;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;
using StringDictionary = System.Collections.Generic.Dictionary<string, string>;
using RStringDictionary = System.Collections.Generic.IReadOnlyDictionary<string, string>;

namespace GunfireLib.Data.Extensions
{
    public static partial class Extensions
    {
        public static string GetEnglishName(this modeldataclass baseClass) =>
            Classes.ModelDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this modeldataclass baseClass) =>
            Classes.ModelDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class ModelDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, modeldataclass> modelList;

        public ModelDataClass(string key, Dictionary<string, modeldataclass> modelList)
        {
            this.key = key;
            this.modelList = modelList;
        }

        public int AdsorbRange
        {
            get => modelList[key].AdsorbRange;
        }

        public int BornEffectID
        {
            get => modelList[key].BornEffectID;
        }

        public string DeadModelFile
        {
            get => modelList[key].DeadModelFile;
        }

        public string Desc
        {
            get => modelList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(modelList[key].Desc);
        }

        // TODO:
        public Dictionary<string, SDieInfoSub> DieInfo
        {
            get => modelList[key].DieInfo;
        }

        public int DisappearEffectID
        {
            get => modelList[key].DisappearEffectID;
        }

        public string DisappearSound
        {
            get => modelList[key].DisappearSound;
        }

        public float FixedTopHeight
        {
            get => modelList[key].FixedTopHight;
        }

        public string GalleryModelFile
        {
            get => modelList[key].GalleryModelFile;
        }

        public string HandModelFile
        {
            get => modelList[key].HandModelFile;
        }

        public string HandSkinModelFile
        {
            get => modelList[key].HandSkinModelFile;
        }

        public int IconID
        {
            get => modelList[key].IconID;
        }

        // TODO:
        public Dictionary<string, SJumpInfoSub> JumpInfo
        {
            get => modelList[key].JumpInfo;
        }

        public string ModelFile
        {
            get => modelList[key].ModelFile;
        }

        public float ModelHeight
        {
            get => modelList[key].ModelHight;
        }

        public string ModelMetal
        {
            get => modelList[key].ModelMetal;
        }

        public string MovementSound
        {
            get => modelList[key].MovementSound;
        }

        public string Name
        {
            get => modelList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(modelList[key].Name);
        }

        public string Path
        {
            get => modelList[key].Path;
        }

        public int RagdollTime
        {
            get => modelList[key].RagdollTime;
        }

        public int Showable
        {
            get => modelList[key].Showable;
        }

        // TODO:
        public Dictionary<string, SoundEffectInfoSub> SoundEffectInfo
        {
            get => modelList[key].SoundEffectInfo;
        }

        public string TeamModelFile
        {
            get => modelList[key].TeamModelFile;
        }

        public int WalkEffectID
        {
            get => modelList[key].WalkEffectID;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return ModelNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        internal static string GetEnglishDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return ModelDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary ModelNames = new StringDictionary()
        {

        };

        public static RStringDictionary ModelDescriptions = new StringDictionary()
        {

        };
    }
}
