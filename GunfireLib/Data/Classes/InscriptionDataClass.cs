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
        public static string GetEnglishName(this inscriptiondataclass baseClass) =>
            Classes.InscriptionDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this inscriptiondataclass baseClass) =>
            Classes.InscriptionDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class InscriptionDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, inscriptiondataclass> inscriptionList;

        public InscriptionDataClass(int key, Dictionary<int, inscriptiondataclass> inscriptionList)
        {
            this.key = key;
            this.inscriptionList = inscriptionList;
        }

        public string Desc
        {
            get => inscriptionList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(inscriptionList[key].Desc);
        }

        public List<int> DetailLabel
        {
            get => inscriptionList[key].DetailLabel;
        }

        public string HurtType
        {
            get => inscriptionList[key].HurtType;
        }

        public int ItemType
        {
            get => inscriptionList[key].ItemType;
        }

        public List<int> LimitWeapon
        {
            get => inscriptionList[key].LimitWeapon;
        }

        public string Name
        {
            get => inscriptionList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(inscriptionList[key].Name);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return InscriptionNames[name];
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
                return InscriptionDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary InscriptionNames = new StringDictionary()
        {

        };

        public static RStringDictionary InscriptionDescriptions = new StringDictionary()
        {

        };
    }
}
