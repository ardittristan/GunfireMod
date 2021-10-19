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
        public static string GetEnglishName(this objsignalclass baseClass) =>
            Classes.ObjSignalClass.GetEnglishName(baseClass.Name);
    }
}

namespace GunfireLib.Data.Classes
{
    public class ObjSignalClass
    {
        private readonly int key;
        private readonly Dictionary<int, objsignalclass> signalList;

        public ObjSignalClass(int key, Dictionary<int, objsignalclass> signalList)
        {
            this.key = key;
            this.signalList = signalList;
        }

        public int FightType
        {
            get => signalList[key].FightType;
        }

        public float Height
        {
            get => signalList[key].Height;
        }

        public string IconPath
        {
            get => signalList[key].IconPath;
        }

        public int ID
        {
            get => signalList[key].ID;
        }

        public int MarkRecord
        {
            get => signalList[key].MarkRecord;
        }

        public string Name
        {
            get => signalList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(signalList[key].Name);
        }

        public int Type
        {
            get => signalList[key].Type;
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return SignalNames[name];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return name;
            }
        }

        public static RStringDictionary SignalNames = new StringDictionary()
        {

        };
    }
}
