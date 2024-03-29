﻿// ReSharper disable InconsistentNaming
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
        public static string GetEnglishDesc(this loadingtipsdataclass baseClass) =>
            Classes.LoadingTipsDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class LoadingTipsDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, loadingtipsdataclass> loadingTipsList;

        public LoadingTipsDataClass(int key, Dictionary<int, loadingtipsdataclass> loadingTipsList)
        {
            this.key = key;
            this.loadingTipsList = loadingTipsList;
        }

        public string Desc
        {
            get => loadingTipsList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(loadingTipsList[key].Desc);
        }

        public int MaxCnt
        {
            get => loadingTipsList[key].MaxCnt;
        }

        internal static string GetEnglishDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return LoadingTipsDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary LoadingTipsDescriptions = new StringDictionary()
        {

        };
    }
}
