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
        public static string GetEnglishName(this cheekdataclass baseClass) =>
            Classes.CheekDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this cheekdataclass baseClass) =>
            Classes.CheekDataClass.GetEnglishDesc(baseClass.Desc);

        public static string GetEnglishUnlockDesc(this cheekdataclass baseClass) =>
            Classes.CheekDataClass.GetEnglishUnlockDesc(baseClass.UnLockDesc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class CheekDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, cheekdataclass> cheekList;

        public CheekDataClass(int key, Dictionary<int, cheekdataclass> cheekList)
        {
            this.key = key;
            this.cheekList = cheekList;
        }

        public string Desc
        {
            get => cheekList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(cheekList[key].Desc);
        }

        public int IconID
        {
            get => cheekList[key].IconID;
        }

        //public int LockState
        //{
        //    get => cheekList[key].LockState;
        //}

        public string Name
        {
            get => cheekList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(cheekList[key].Name);
        }

        public string Path
        {
            get => cheekList[key].Path;
        }

        public string UnlockDesc
        {
            get => cheekList[key].UnLockDesc;
        }

        public string EnglishUnlockDesc
        {
            get => GetEnglishUnlockDesc(cheekList[key].UnLockDesc);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return CheekNames[name];
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
                return CheekDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        internal static string GetEnglishUnlockDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return CheekUnlockDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary CheekNames = new StringDictionary()
        {

        };

        public static RStringDictionary CheekDescriptions = new StringDictionary()
        {

        };

        public static RStringDictionary CheekUnlockDescriptions = new StringDictionary()
        {

        };
    }
}
