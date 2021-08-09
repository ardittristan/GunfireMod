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
        public static string GetEnglishName(this attackdataclass baseClass) => Classes.AttackDataClass.GetEnglishName(baseClass.Name);
        public static string GetEnglishDesc(this attackdataclass baseClass) => Classes.AttackDataClass.GetEnglishDesc(baseClass.Desc);
        public static string GetPerformType(this attackdataclass baseClass) => Classes.AttackDataClass.GetEnglishPerformType(baseClass.PerformType);
    }
}

namespace GunfireLib.Data.Classes
{
    public class AttackDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, attackdataclass> attackList;

        public AttackDataClass(string key, Dictionary<string, attackdataclass> attackList)
        {
            this.key = key;
            this.attackList = attackList;
        }

        public int CarreerPerformSubType
        {
            get => attackList[key].CareerPerformSubType;
        }

        // TODO:
        public Dictionary<string, SCommonProp> CommonProp
        {
            get => attackList[key].CommonProp;
        }

        public string Desc
        {
            get => attackList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(attackList[key].Desc);
        }

        public int EatBullet
        {
            get => attackList[key].EatBullet;
        }

        public List<int> ExAddSkill
        {
            get => attackList[key].ExAddSkill;
        }

        public int ForbidType
        {
            get => attackList[key].FobidType;
        }

        public int IconID
        {
            get => attackList[key].IconID;
        }

        public int ID
        {
            get => attackList[key].ID;
        }

        public string Name
        {
            get => attackList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(attackList[key].Name);
        }

        public List<int> PassRule
        {
            get => attackList[key].PassRule;
        }

        public string PerformType
        {
            get => attackList[key].PerformType;
        }

        public string EnglishPerformType
        {
            get => GetEnglishPerformType(attackList[key].PerformType);
        }

        public int SecondaryPerformCD
        {
            get => attackList[key].SecondaryPerformCD;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return AttackNames[name];
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
                return AttackDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        internal static string GetEnglishPerformType(string performType)
        {
            if (string.IsNullOrWhiteSpace(performType)) return "";
            try
            {
                return AttackPerformTypes[performType];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return performType;
            }
        }

        public static RStringDictionary AttackNames = new StringDictionary()
        {

        };

        public static RStringDictionary AttackDescriptions = new StringDictionary()
        {

        };

        public static RStringDictionary AttackPerformTypes = new StringDictionary()
        {

        };
    }
}
