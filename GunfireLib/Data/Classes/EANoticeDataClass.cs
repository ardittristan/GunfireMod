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
        public static string GetEnglishDesc(this eanoticedataclass baseClass) =>
            Classes.EANoticeDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class EANoticeDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, eanoticedataclass> noticeList;

        public EANoticeDataClass(string key, Dictionary<string, eanoticedataclass> noticeList)
        {
            this.key = key;
            this.noticeList = noticeList;
        }

        public string Desc
        {
            get => noticeList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(noticeList[key].Desc);
        }

        internal static string GetEnglishDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return NoticeDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary NoticeDescriptions = new StringDictionary()
        {

        };
    }
}
