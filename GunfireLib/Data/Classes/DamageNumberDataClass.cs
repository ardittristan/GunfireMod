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
        public static string GetEnglishExtraInfo(this damagenumberdataclass baseClass) =>
            Classes.DamageNumberDataClass.GetEnglishExtraInfo(baseClass.ExtraInfo);
    }
}

namespace GunfireLib.Data.Classes
{
    public class DamageNumberDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, damagenumberdataclass> damageNumberList;

        public DamageNumberDataClass(int key, Dictionary<int, damagenumberdataclass> damageNumberList)
        {
            this.key = key;
            this.damageNumberList = damageNumberList;
        }

        public string ExtraInfo
        {
            get => damageNumberList[key].ExtraInfo;
        }

        public string EnglishExtraInfo
        {
            get => GetEnglishExtraInfo(damageNumberList[key].ExtraInfo);
        }

        public string HurtElement
        {
            get => damageNumberList[key].HurtElement;
        }

        public string HurtPart
        {
            get => damageNumberList[key].HurtPart;
        }

        public string HurtPath
        {
            get => damageNumberList[key].HurtPath;
        }

        internal static string GetEnglishExtraInfo(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return ExtraInfos[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        public static RStringDictionary ExtraInfos = new StringDictionary()
        {

        };
    }
}
