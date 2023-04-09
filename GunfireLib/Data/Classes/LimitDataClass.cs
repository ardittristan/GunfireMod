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
        public static string GetEnglishForbidName(this limitdataclass baseClass) =>
            Classes.LimitDataClass.GetEnglishForbidName(baseClass.ForbidName);
    }
}

namespace GunfireLib.Data.Classes
{
    public class LimitDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, limitdataclass> limitList;

        public LimitDataClass(int key, Dictionary<int, limitdataclass> limitList)
        {
            this.key = key;
            this.limitList = limitList;
        }

        public List<int> ForbidList
        {
            get => limitList[key].ForbidList;
        }

        public string ForbidName
        {
            get => limitList[key].ForbidName;
        }

        public string EnglishForbidName
        {
            get => limitList[key].ForbidName;
        }

        public int ID
        {
            get => limitList[key].ID;
        }

        internal static string GetEnglishForbidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return ForbidNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        public static RStringDictionary ForbidNames = new StringDictionary()
        {

        };
    }
}
