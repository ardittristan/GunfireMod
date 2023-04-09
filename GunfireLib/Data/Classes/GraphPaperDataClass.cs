// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
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
        public static string GetEnglishAttName(this graphpaperdataclass baseClass) =>
            Classes.GraphPaperDataClass.GetEnglishAttName(baseClass.AttName);

        public static string GetEnglishDesc(this graphpaperdataclass baseClass) =>
            Classes.GraphPaperDataClass.GetEnglishDesc(baseClass.Desc);

        public static string GetEnglishDetailDesc(this graphpaperdataclass baseClass) =>
            Classes.GraphPaperDataClass.GetEnglishDetailDesc(baseClass.DetailDesc);

        public static string GetEnglishName(this graphpaperdataclass baseClass) =>
            Classes.GraphPaperDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishSimpleDesc(this graphpaperdataclass baseClass) =>
            Classes.GraphPaperDataClass.GetEnglishSimpleDesc(baseClass.SimpleDesc);

        public static string GetEnglishStateType(this graphpaperdataclass baseClass) =>
            Classes.GraphPaperDataClass.GetEnglishStateType(baseClass.StateType);
    }
}

namespace GunfireLib.Data.Classes
{
    public class GraphPaperDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, graphpaperdataclass> graphPaperList;

        public GraphPaperDataClass(int key, Dictionary<int, graphpaperdataclass> graphPaperList)
        {
            this.key = key;
            this.graphPaperList = graphPaperList;
        }

        public string AttName
        {
            get => graphPaperList[key].AttName;
        }

        public string EnglishAttName
        {
            get => GetEnglishAttName(graphPaperList[key].AttName);
        }

        public string Desc
        {
            get => graphPaperList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(graphPaperList[key].Desc);
        }

        public string DetailDesc
        {
            get => graphPaperList[key].DetailDesc;
        }

        public string EnglishDetailDesc
        {
            get => GetEnglishDetailDesc(graphPaperList[key].DetailDesc);
        }

        // TODO:
        public Dictionary<int, GraphGetSub> GraphGetInfo
        {
            get => graphPaperList[key].GraphGetInfo;
        }

        public int IconID
        {
            get => graphPaperList[key].IconID;
        }

        public string Name
        {
            get => graphPaperList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(graphPaperList[key].Name);
        }

        public int PaperType
        {
            get => graphPaperList[key].PaperType;
        }


        public List<int> PreGraphIDLst
        {
            get => graphPaperList[key].PreGraphIDLst;
        }

        // TODO:
        public Dictionary<int, GraphRewardSub> RewardInfo
        {
            get => graphPaperList[key].RewardInfo;
        }

        public int Shape
        {
            get => graphPaperList[key].Shape;
        }

        public int Showable
        {
            get => graphPaperList[key].Showable;
        }

        public string SimpleDesc
        {
            get => graphPaperList[key].SimpleDesc;
        }

        public string EnglishSimpleDesc
        {
            get => GetEnglishSimpleDesc(graphPaperList[key].SimpleDesc);
        }

        public string StateType
        {
            get => graphPaperList[key].StateType;
        }

        public string EnglishStateType
        {
            get => GetEnglishStateType(graphPaperList[key].StateType);
        }

        public int Type
        {
            get => graphPaperList[key].Type;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return GraphPaperNames[name];
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
                return GraphPaperDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        internal static string GetEnglishAttName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return GraphPaperAttNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        internal static string GetEnglishDetailDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return GraphPaperDetailDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        internal static string GetEnglishSimpleDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return GraphPaperSimpleDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        internal static string GetEnglishStateType(string type)
        {
            if (string.IsNullOrWhiteSpace(type)) return "";
            try
            {
                return GraphPaperStateTypes[type];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return type;
            }
        }

        public static RStringDictionary GraphPaperNames = new StringDictionary()
        {

        };

        public static RStringDictionary GraphPaperAttNames = new StringDictionary()
        {

        };

        public static RStringDictionary GraphPaperDescriptions = new StringDictionary()
        {

        };

        public static RStringDictionary GraphPaperDetailDescriptions = new StringDictionary()
        {

        };

        public static RStringDictionary GraphPaperSimpleDescriptions = new StringDictionary()
        {

        };

        public static RStringDictionary GraphPaperStateTypes = new StringDictionary()
        {

        };
    }
}
