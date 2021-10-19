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
        public static string GetEnglishName(this herodataclass baseClass) =>
            Classes.HeroDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishHeroBrief(this herodataclass baseClass) =>
            Classes.HeroDataClass.GetEnglishHeroBrief(baseClass.HeroBrief);

        public static string GetEnglishUnLockDesc(this herodataclass baseClass) =>
            Classes.HeroDataClass.GetEnglishUnLockDesc(baseClass.UnLockDesc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class HeroDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, herodataclass> heroList;

        public HeroDataClass(int key, Dictionary<int, herodataclass> heroList)
        {
            this.key = key;
            this.heroList = heroList;
        }

        public int AdditionIconID
        {
            get => heroList[key].AdditionIconID;
        }

        // TODO:
        public BaseAttrInfo BaseAttr
        {
            get => heroList[key].BaseAttr;
        }

        public string BigIconPath
        {
            get => heroList[key].BigIconPath;
        }

        public int CanGold
        {
            get => heroList[key].CanGold;
        }

        public int CanGSCashUnlock
        {
            get => heroList[key].CanGSCashUnlock;
        }

        public int Career
        {
            get => heroList[key].Career;
        }

        public int DefaultLock
        {
            get => heroList[key].DefaultLock;
        }

        public int DefendTrend
        {
            get => heroList[key].DefendTrend;
        }

        public int Gold
        {
            get => heroList[key].Gold;
        }

        public int GSCashConsume
        {
            get => heroList[key].GSCashConsume;
        }

        public string HeroBrief
        {
            get => heroList[key].HeroBrief;
        }

        public string EnglishHeroBrief
        {
            get => GetEnglishHeroBrief(heroList[key].HeroBrief);
        }

        // TODO:
        public Dictionary<int, HeroGrade> HeroGradeInfo
        {
            get => heroList[key].HeroGradeInfo;
        }

        public int IconID
        {
            get => heroList[key].IconID;
        }

        public int ID
        {
            get => heroList[key].ID;
        }

        public string Name
        {
            get => heroList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(heroList[key].Name);
        }

        public int Shape
        {
            get => heroList[key].Shape;
        }

        public int Showable
        {
            get => heroList[key].Showable;
        }

        // TODO:
        public Dictionary<string, int> Skill
        {
            get => heroList[key].Skill;
        }

        public int StartGun
        {
            get => heroList[key].StartGun;
        }

        // TODO:
        public Dictionary<int, TalentIconInfo> TalentIconInfo
        {
            get => heroList[key].TalentIconInfo;
        }

        public string UnLockDesc
        {
            get => heroList[key].UnLockDesc;
        }

        public string EnglishUnLockDesc
        {
            get => GetEnglishUnLockDesc(heroList[key].UnLockDesc);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return HeroNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        internal static string GetEnglishHeroBrief(string heroBrief)
        {
            if (string.IsNullOrWhiteSpace(heroBrief)) return "";
            try
            {
                return HeroBriefs[heroBrief];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return heroBrief;
            }
        }

        internal static string GetEnglishUnLockDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return HeroUnlockDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary HeroNames = new StringDictionary()
        {

        };

        public static RStringDictionary HeroBriefs = new StringDictionary()
        {

        };

        public static RStringDictionary HeroUnlockDescriptions = new StringDictionary()
        {
            
        };
    }
}
