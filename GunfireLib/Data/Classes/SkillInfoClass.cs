﻿// ReSharper disable InconsistentNaming
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
        public static string GetEnglishName(this skillinfoclass baseClass) =>
            Classes.SkillInfoClass.GetEnglishName(baseClass.Name);
    }
}

namespace GunfireLib.Data.Classes
{
    public class SkillInfoClass
    {
        private readonly string key;
        private readonly Dictionary<string, skillinfoclass> skillList;

        public SkillInfoClass(string key, Dictionary<string, skillinfoclass> skillList)
        {
            this.key = key;
            this.skillList = skillList;
        }

        public List<int> BreakInRule
        {
            get => skillList[key].BreakInRule;
        }

        public int ForbidRule
        {
            get => skillList[key].ForbidRule;
        }

        public int ID
        {
            get => skillList[key].ID;
        }

        public string Name
        {
            get => skillList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(skillList[key].Name);
        }

        public List<int> PassRule
        {
            get => skillList[key].PassRule;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return SkillNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        public static RStringDictionary SkillNames = new StringDictionary()
        {

        };
    }
}
