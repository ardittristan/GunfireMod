using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileConversationData
    {
        public static Dictionary<string, conversationdataclass> conversationList;

        public static System.Collections.Generic.Dictionary<string, Classes.ConversationDataClass> parsedConversationList =
            new System.Collections.Generic.Dictionary<string, Classes.ConversationDataClass>();

        internal static void Setup()
        {
            conversationList = mobileconversationdata.GetData();
            foreach (KeyValuePair<string, conversationdataclass> conversation in conversationList)
            {
                parsedConversationList.Add(conversation.Key,
                    new Classes.ConversationDataClass(conversation.Key, conversationList));
            }
        }
    }
}