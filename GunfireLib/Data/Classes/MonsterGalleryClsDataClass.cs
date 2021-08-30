// ReSharper disable InconsistentNaming
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
        public static string GetEnglishName(this monstergalleryclsdataclass baseClass) =>
            Classes.MonsterGalleryClsDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this monstergalleryclsdataclass baseClass) =>
            Classes.MonsterGalleryClsDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class MonsterGalleryClsDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, monstergalleryclsdataclass> galleryList;

        public MonsterGalleryClsDataClass(string key, Dictionary<string, monstergalleryclsdataclass> galleryList)
        {
            this.key = key;
            this.galleryList = galleryList;
        }

        public int DefaultLock
        {
            get => galleryList[key].DefaultLock;
        }

        public string Desc
        {
            get => galleryList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(galleryList[key].Desc);
        }

        public int IconID
        {
            get => galleryList[key].IconID;
        }

        public int ID
        {
            get => galleryList[key].ID;
        }

        public int MonsterGalleryID
        {
            get => galleryList[key].MonsterGalleryID;
        }

        public string MonsterType
        {
            get => galleryList[key].MonsterType;
        }

        public string MovementSound
        {
            get => galleryList[key].MovementSound;
        }

        public string Name
        {
            get => galleryList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(galleryList[key].Name);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return GalleryNames[name];
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
                return GalleryDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary GalleryNames = new StringDictionary()
        {

        };

        public static RStringDictionary GalleryDescriptions = new StringDictionary()
        {

        };
    }
}
