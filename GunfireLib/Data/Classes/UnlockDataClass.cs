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
        public static string GetEnglishUnlockDesc(this unlockdataclass baseClass) =>
            Classes.UnlockDataClass.GetEnglishUnlockDesc(baseClass.UnlockDesc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class UnlockDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, unlockdataclass> unlockList;

        public UnlockDataClass(int key, Dictionary<int, unlockdataclass> unlockList)
        {
            this.key = key;
            this.unlockList = unlockList;
        }

        public int Type
        {
            get => unlockList[key].Type;
        }

        public string UnlockDesc
        {
            get => unlockList[key].UnlockDesc;
        }

        public string EnglishUnlockDesc
        {
            get => GetEnglishUnlockDesc(unlockList[key].UnlockDesc);
        }

        // TODO:
        public Dictionary<int, CUnlockInfo> UnlockInfo
        {
            get => unlockList[key].UnlockInfo;
        }

        internal static string GetEnglishUnlockDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return UnlockDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary UnlockDescriptions = new StringDictionary()
        {

        };
    }
}
