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
        public static string GetEnglishName(this monsterafdataclass baseClass) =>
            Classes.MonsterAfDataClass.GetEnglishName(baseClass.Name);
    }
}

namespace GunfireLib.Data.Classes
{
    public class MonsterAfDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, monsterafdataclass> monsterList;

        public MonsterAfDataClass(string key, Dictionary<string, monsterafdataclass> monsterList)
        {
            this.key = key;
            this.monsterList = monsterList;
        }

        public int IconID
        {
            get => monsterList[key].IconID;
        }

        public string Name
        {
            get => monsterList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(monsterList[key].Name);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return MonsterNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        public static RStringDictionary MonsterNames = new StringDictionary()
        {

        };
    }
}
