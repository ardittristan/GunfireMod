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
        public static string GetEnglishName(this monsterconfigclass baseClass) =>
            Classes.MonsterConfigClass.GetEnglishName(baseClass.Name);
    }
}

namespace GunfireLib.Data.Classes
{
    public class MonsterConfigClass
    {
        private readonly int key;
        private readonly Dictionary<int, monsterconfigclass> configList;

        public MonsterConfigClass(int key, Dictionary<int, monsterconfigclass> configList)
        {
            this.key = key;
            this.configList = configList;
        }

        public float CombatForce
        {
            get => configList[key].CombatForce;
        }

        public int FightType
        {
            get => configList[key].FightType;
        }

        public int IconID
        {
            get => configList[key].IconID;
        }

        public string MonsterType
        {
            get => configList[key].MonsterType;
        }

        public string Name
        {
            get => configList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(configList[key].Name);
        }

        public int Shape
        {
            get => configList[key].Shape;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return ConfigNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        public static RStringDictionary ConfigNames = new StringDictionary()
        {

        };
    }
}
