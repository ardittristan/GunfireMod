// ReSharper disable InconsistentNaming
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
        public static string GetEnglishChatName(this commonnotifydataclass baseClass) =>
            Classes.CommonNotifyDataClass.GetEnglishChatName(baseClass.ChatName);

        public static string GetEnglishChatText(this commonnotifydataclass baseClass) =>
            Classes.CommonNotifyDataClass.GetEnglishChatText(baseClass.ChatText);
    }
}

namespace GunfireLib.Data.Classes
{
    public class CommonNotifyDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, commonnotifydataclass> notifyList;

        public CommonNotifyDataClass(int key, Dictionary<int, commonnotifydataclass> notifyList)
        {
            this.key = key;
            this.notifyList = notifyList;
        }

        public string ChatName
        {
            get => notifyList[key].ChatName;
        }

        public string ChatText
        {
            get => notifyList[key].ChatText;
        }

        public int ChatTime
        {
            get => notifyList[key].ChatTime;
        }

        internal static string GetEnglishChatName(string name)
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

        internal static string GetEnglishChatText(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc)) return "";
            try
            {
                return ChatTexts[desc];
            }
            catch (Exception ex) when (ex is Il2CppException || ex is KeyNotFoundException)
            {
                return desc;
            }
        }

        public static RStringDictionary ChatNames = new StringDictionary()
        {

        };

        public static RStringDictionary ChatTexts = new StringDictionary()
        {

        };
    }
}
