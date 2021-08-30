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
        public static string GetEnglishName(this musiceffectdataclass baseClass) =>
            Classes.MusicEffectDataClass.GetEnglishName(baseClass.Name);
    }
}

namespace GunfireLib.Data.Classes
{
    public class MusicEffectDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, musiceffectdataclass> effectList;

        public MusicEffectDataClass(string key, Dictionary<string, musiceffectdataclass> effectList)
        {
            this.key = key;
            this.effectList = effectList;
        }

        public int ID
        {
            get => effectList[key].ID;
        }

        public string ModelFile
        {
            get => effectList[key].ModelFile;
        }

        public string Name
        {
            get => effectList[key].Name;
        }

        public string EnglishName
        {
            get => effectList[key].Name;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return MusicNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        public static RStringDictionary MusicNames = new StringDictionary()
        {

        };
    }
}
