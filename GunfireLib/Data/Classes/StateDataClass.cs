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
        public static string GetEnglishName(this statedataclass baseClass) =>
            Classes.StateDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishAttName(this statedataclass baseClass) =>
            Classes.StateDataClass.GetEnglishAttName(baseClass.AttName);
    }
}

namespace GunfireLib.Data.Classes
{
    public class StateDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, statedataclass> stateList;

        public StateDataClass(int key, Dictionary<int, statedataclass> stateList)
        {
            this.key = key;
            this.stateList = stateList;
        }

        public string AnimatorType
        {
            get => stateList[key].AnimatorType;
        }

        public string AttName
        {
            get => stateList[key].AttName;
        }

        public string EnglishAttName
        {
            get => GetEnglishAttName(stateList[key].AttName);
        }

        public int BehaviorID
        {
            get => stateList[key].BehaviorID;
        }

        public int CacheTime
        {
            get => stateList[key].CacheTime;
        }

        public int CanShowCount
        {
            get => stateList[key].CanShowCount;
        }

        public string EffectPath
        {
            get => stateList[key].EffectPath;
        }

        public string IconPath
        {
            get => stateList[key].IconPath;
        }

        public string JudgeType
        {
            get => stateList[key].JudgeType;
        }

        public string Name
        {
            get => stateList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(stateList[key].Name);
        }

        public int Showable
        {
            get => stateList[key].Showable;
        }

        public int StateCountBehav
        {
            get => stateList[key].StateCountBehav;
        }

        // TODO:
        public Dictionary<int, SStateDescDic> StateDescDic
        {
            get => stateList[key].StateDescDic;
        }

        public List<string> StateSignLst
        {
            get => stateList[key].StateSignLst;
        }

        public string StateType
        {
            get => stateList[key].StateType;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return StateNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        internal static string GetEnglishAttName(string name)
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

        public static RStringDictionary StateNames = new StringDictionary()
        {

        };

        public static RStringDictionary AttackNames = new StringDictionary()
        {

        };
    }
}
