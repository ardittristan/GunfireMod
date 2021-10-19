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
        public static string GetEnglishName(this icondataclass baseClass) =>
            Classes.IconDataClass.GetEnglishName(baseClass.Name);
    }
}

namespace GunfireLib.Data.Classes
{
    public class IconDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, icondataclass> iconList;

        public IconDataClass(int key, Dictionary<int, icondataclass> iconList)
        {
            this.key = key;
            this.iconList = iconList;
        }

        public string BigIconPath
        {
            get => iconList[key].BigIconPath;
        }

        public string IconPath
        {
            get => iconList[key].IconPath;
        }

        public string LockedIconPath
        {
            get => iconList[key].LockedIconPath;
        }

        public string Name
        {
            get => iconList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(iconList[key].Name);
        }

        public string ShopIconPath
        {
            get => iconList[key].ShopIconPath;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return IconNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        public static RStringDictionary IconNames = new StringDictionary()
        {

        };
    }
}
