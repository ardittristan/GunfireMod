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
        public static string GetEnglishName(this closedataclass baseClass) =>
            Classes.CloseDataClass.GetEnglishName(baseClass.Name);
    }
}

namespace GunfireLib.Data.Classes
{
    public class CloseDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, closedataclass> closeList;

        public CloseDataClass(string key, Dictionary<string, closedataclass> closeList)
        {
            this.key = key;
            this.closeList = closeList;
        }

        // TODO:
        public Dictionary<string, OneComboData> ComboInfo
        {
            get => closeList[key].ComboInfo;
        }

        public string Name
        {
            get => closeList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(closeList[key].Name);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return CloseNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        public static RStringDictionary CloseNames = new StringDictionary()
        {

        };
    }
}
