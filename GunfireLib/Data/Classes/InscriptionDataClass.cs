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
        private readonly string key;
        private readonly Dictionary<string, inscriptiondataclass> inscriptionList;

        public InscriptionDataClass(string key, Dictionary<string, inscriptiondataclass> inscriptionList)
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
