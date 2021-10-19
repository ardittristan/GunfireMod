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
        public static string GetEnglishName(this chatdataclass baseClass) =>
            Classes.ChatDataClass.GetEnglishName(baseClass.Name);

        public static string GetEnglishDesc(this chatdataclass baseClass) =>
            Classes.ChatDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class ChatDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, chatdataclass> chatList;

        public ChatDataClass(int key, Dictionary<int, chatdataclass> chatList)
        {
            this.key = key;
            this.chatList = chatList;
        }

        public string Desc
        {
            get => chatList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(chatList[key].Desc);
        }

        public string Name
        {
            get => chatList[key].Name;
        }

        public string EnglishName
        {
            get => GetEnglishName(chatList[key].Name);
        }

        internal static string GetEnglishName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            try
            {
                return ChatNames[name];
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
                return ChatDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary ChatNames = new StringDictionary()
        {

        };

        public static RStringDictionary ChatDescriptions = new StringDictionary()
        {

        };
    }
}
