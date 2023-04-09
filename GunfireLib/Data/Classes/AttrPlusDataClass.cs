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
        public static string GetEnglishName(this attrplusdataclass baseClass) =>
            Classes.AttrPlusDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this attrplusdataclass baseClass) =>
            Classes.AttrPlusDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class AttrPlusDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, attrplusdataclass> attributeList;

        public AttrPlusDataClass(int key, Dictionary<int, attrplusdataclass> attributeList)
        {
            this.key = key;
            this.attributeList = attributeList;
        }

        public string Desc
        {
            get => attributeList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(attributeList[key].Desc);
        }

        public string Name
        {
            get => attributeList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(attributeList[key].Name);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return AttributeNames[name];
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
                return AttributeDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary AttributeNames = new StringDictionary()
        {

        };

        public static RStringDictionary AttributeDescriptions = new StringDictionary()
        {

        };
    }
}
