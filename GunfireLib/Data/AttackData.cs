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
        public static string GetEnglishName(this attackdataclass baseClass) => AttackData.MODattackdataclass.GetEnglishName(baseClass.Name);
        public static string GetEnglishDesc(this attackdataclass baseClass) => AttackData.MODattackdataclass.GetEnglishDesc(baseClass.Desc);
        public static string GetPerformType(this attackdataclass baseClass) => AttackData.MODattackdataclass.GetEnglishPerformType(baseClass.PerformType);
    }

    public static class AttackData
    {
        public static Dictionary<string, attackdataclass> attackList;
        public static System.Collections.Generic.Dictionary<string, MODattackdataclass> parsedAttackList = new System.Collections.Generic.Dictionary<string, MODattackdataclass>();

        internal static void Setup()
        {
            attackList = attackdata.GetData();
            foreach (KeyValuePair<string, attackdataclass> attack in attackList)
            {
                parsedAttackList.Add(attack.Key, new MODattackdataclass(attack.Key));
            }
        }

        public class MODattackdataclass
        {
            private readonly string key;
            public MODattackdataclass(string key) { this.key = key; }

            public int CarreerPerformSubType { get => attackList[key].CareerPerformSubType; }
            // TODO:
            public Dictionary<string, SCommonProp> CommonProp { get => attackList[key].CommonProp; }
            public string Desc { get => attackList[key].Desc; }
            public string EnglishDesc { get => GetEnglishDesc(attackList[key].Desc); }
            public int EatBullet { get => attackList[key].EatBullet; }
            public List<int> ExAddSkill { get => attackList[key].ExAddSkill; }
            public int ForbidType { get => attackList[key].FobidType; }
            public int IconID { get => attackList[key].IconID; }
            public int ID { get => attackList[key].ID; }
            public string Name { get => attackList[key].Name; }
            public string EnglishName { get => GetEnglishName(attackList[key].Name); }
            public List<int> PassRule { get => attackList[key].PassRule; }
            public string PerformType { get => attackList[key].PerformType; }
            public string EnglishPerformType { get => GetEnglishPerformType(attackList[key].PerformType); }
            public int SecondaryPerformCD { get => attackList[key].SecondaryPerformCD; }

            internal static string GetEnglishName(string name)
            {
                if (string.IsNullOrWhiteSpace(name)) return "";
                try { return AttackNames[name]; }
                catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException) { return name; }
            }

            internal static string GetEnglishDesc(string desc)
            {
                if (string.IsNullOrWhiteSpace(desc)) return "";
                try { return AttackDescriptions[desc]; }
                catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException) { return desc; }
            }

            internal static string GetEnglishPerformType(string performType)
            {
                if (string.IsNullOrWhiteSpace(performType)) return "";
                try { return AttackPerformTypes[performType]; }
                catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException) { return performType; }
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
