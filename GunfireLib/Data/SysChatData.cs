using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class SysChatData
    {
        public static Dictionary<string, chatdataclass> chatList;

        public static System.Collections.Generic.Dictionary<string, Classes.ChatDataClass> parsedChatList =
            new System.Collections.Generic.Dictionary<string, Classes.ChatDataClass>();

        internal static void Setup()
        {
            chatList = c_syschatdata.GetData();
            foreach (KeyValuePair<string, chatdataclass> chat in chatList)
            {
                parsedChatList.Add(chat.Key, new Classes.ChatDataClass(chat.Key, chatList));
            }
        }
    }
}