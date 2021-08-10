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
        public static string GetEnglishName(this enhancedataclass baseClass) =>
            Classes.EnhanceDataClass.GetEnglishName(baseClass.Name);
    }
}

namespace GunfireLib.Data.Classes
{
    public class EnhanceDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, enhancedataclass> enhanceList;

        public EnhanceDataClass(string key, Dictionary<string, enhancedataclass> enhanceList)
        {
            this.key = key;
            this.enhanceList = enhanceList;
        }

        public List<int> EntryIDs
        {
            get => enhanceList[key].EntryIDs;
        }

        public string Name
        {
            get => enhanceList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(enhanceList[key].Name);
        }

        // TODO:
        public Dictionary<string, PropertyEnhance> PropertyEnhance
        {
            get => enhanceList[key].PropertyEnhance;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return EnhanceNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        public static RStringDictionary EnhanceNames = new StringDictionary()
        {

        };
    }
}
