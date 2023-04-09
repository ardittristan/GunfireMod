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
        public static string GetEnglishName(this coursewindowsdataclass baseClass) =>
            Classes.CourseWindowsDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this coursewindowsdataclass baseClass) =>
            Classes.CourseWindowsDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class CourseWindowsDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, coursewindowsdataclass> windowList;

        public CourseWindowsDataClass(int key, Dictionary<int, coursewindowsdataclass> windowList)
        {
            this.key = key;
            this.windowList = windowList;
        }

        public string Desc
        {
            get => windowList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(windowList[key].Desc);
        }

        public int IconID
        {
            get => windowList[key].IconID;
        }

        public string Name
        {
            get => windowList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(windowList[key].Name);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return WindowNames[name];
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
                return WindowDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary WindowNames = new StringDictionary()
        {

        };

        public static RStringDictionary WindowDescriptions = new StringDictionary()
        {

        };
    }
}
