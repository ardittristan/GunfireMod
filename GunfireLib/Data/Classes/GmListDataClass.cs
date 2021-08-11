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
        public static string GetEnglishName(this gmlistdataclass baseClass) =>
            Classes.GmListDataClass.GetEnglishName(baseClass.Name);
    }
}

namespace GunfireLib.Data.Classes
{
    public class GmListDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, gmlistdataclass> gmList;

        public GmListDataClass(string key, Dictionary<string, gmlistdataclass> gmList)
        {
            this.key = key;
            this.gmList = gmList;
        }

        public List<int> GMArg
        {
            get => gmList[key].GMArg;
        }

        public List<string> GMArgStr
        {
            get => gmList[key].GMArgStr;
        }

        // TODO:?
        public List<string> GMName
        {
            get => gmList[key].GMName;
        }

        public int ID
        {
            get => gmList[key].ID;
        }

        public string Name
        {
            get => gmList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(gmList[key].Name);
        }

        public int Shape
        {
            get => gmList[key].Shape;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return GmNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        public static RStringDictionary GmNames = new StringDictionary()
        {

        };
    }
}
