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
        public static string GetEnglishDesc(this conversationdataclass baseClass) =>
            Classes.ConversationDataClass.GetEnglishDesc(baseClass.Desc);
    }
}

namespace GunfireLib.Data.Classes
{
    public class ConversationDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, conversationdataclass> conversationList;

        public ConversationDataClass(string key, Dictionary<string, conversationdataclass> conversationList)
        {
            this.key = key;
            this.conversationList = conversationList;
        }

        public string Desc
        {
            get => conversationList[key].Desc;
        }

        public string EnglishDesc
        {
            get => GetEnglishDesc(conversationList[key].Desc);
        }

        public int Shape
        {
            get => conversationList[key].Shape;
        }

        internal static string GetEnglishDesc(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return ConversationDescriptions[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary ConversationDescriptions = new StringDictionary()
        {

        };
    }
}