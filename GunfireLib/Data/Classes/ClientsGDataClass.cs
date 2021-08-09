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
        public static string GetEnglishName(this clientsgdataclass baseClass) =>
            Classes.ClientsGDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this clientsgdataclass baseClass) =>
            Classes.ClientsGDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class ClientsGDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, clientsgdataclass> clientList;

        public ClientsGDataClass(string key, Dictionary<string, clientsgdataclass> clientList)
        {
            this.key = key;
            this.clientList = clientList;
        }

        public List<string> ButtonLst
        {
            get => clientList[key].ButtonLst;
        }

        public string Desc
        {
            get => clientList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(clientList[key].Desc);
        }

        public string Name
        {
            get => clientList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(clientList[key].Name);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return ClientNames[name];
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
                return ClientDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary ClientNames = new StringDictionary()
        {

        };

        public static RStringDictionary ClientDescriptions = new StringDictionary()
        {

        };
    }
}
