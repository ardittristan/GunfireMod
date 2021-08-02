using System;
using Il2CppSystem.Collections.Generic;
using DataHelper;
using UnhollowerBaseLib;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;
using StringDictionary = System.Collections.Generic.Dictionary<string, string>;
using RStringDictionary = System.Collections.Generic.IReadOnlyDictionary<string, string>;

namespace GunfireLib.Data
{
    public static partial class Extensions
    {
        public static string GetEnglishName(this attrplusdataclass baseClass) => AttirbutePlusData.MODattrplusdataclass.GetEnglishName(baseClass.Name);
        public static string GetEnglishDesc(this attrplusdataclass baseClass) => AttirbutePlusData.MODattrplusdataclass.GetEnglishDesc(baseClass.Desc);
    }

    public static class AttirbutePlusData
    {
        public static Dictionary<string, attrplusdataclass> attributeList;
        public static System.Collections.Generic.Dictionary<string, MODattrplusdataclass> parsedAttributeList = new System.Collections.Generic.Dictionary<string, MODattrplusdataclass>();

        internal static void Setup()
        {
            attributeList = attrplusdata.GetData();
            foreach (KeyValuePair<string, attrplusdataclass> attribute in attributeList)
            {
                parsedAttributeList.Add(attribute.Key, new MODattrplusdataclass(attribute.Key));
            }
        }

        public class MODattrplusdataclass
        {
            private readonly string key;
            public MODattrplusdataclass(string key) { this.key = key; }

            public string Desc { get => attributeList[key].Desc; }
            public string EnglishDesc { get => GetEnglishDesc(attributeList[key].Desc); }
            public string Name { get => attributeList[key].Name; }
            public string EnglishName { get => GetEnglishName(attributeList[key].Name); }

            internal static string GetEnglishName(string name)
            {
                if (string.IsNullOrWhiteSpace(name)) return "";
                try { return AttributeNames[name]; }
                catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException) { return name; }
            }

            internal static string GetEnglishDesc(string desc)
            {
                if (string.IsNullOrWhiteSpace(desc)) return "";
                try { return AttributeDescriptions[desc]; }
                catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException) { return desc; }
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
