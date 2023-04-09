// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using System;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;
using Il2CppInterop.Runtime;
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
        private readonly int key;
        private readonly Dictionary<int, musiceffectdataclass> effectList;

        public MusicEffectDataClass(int key, Dictionary<int, musiceffectdataclass> effectList)
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
