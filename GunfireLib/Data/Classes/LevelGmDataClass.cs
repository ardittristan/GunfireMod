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
        public static string GetEnglishName(this levelgmdataclass baseClass) =>
            Classes.LevelGmDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDevName(this levelgmdataclass baseClass) =>
            Classes.LevelGmDataClass.GetEnglishDevName(baseClass.DevName);
    }
}

namespace GunfireLib.Data.Classes
{
    public class LevelGmDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, levelgmdataclass> gmList;

        public LevelGmDataClass(int key, Dictionary<int, levelgmdataclass> gmList)
        {
            this.key = key;
            this.gmList = gmList;
        }

        public string DevName
        {
            get => gmList[key].DevName;
        }

        public string EnglishDevName
        {
            get => gmList[key].DevName;
        }

        public int LevelID
        {
            get => gmList[key].LevelID;
        }

        public string Name
        {
            get => gmList[key].Name;
        }

        public string EnglishName
        {
            get => gmList[key].Name;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return LevelGmNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        internal static string GetEnglishDevName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return LevelGmDevNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        public static RStringDictionary LevelGmNames = new StringDictionary()
        {

        };

        public static RStringDictionary LevelGmDevNames = new StringDictionary()
        {

        };
    }
}
