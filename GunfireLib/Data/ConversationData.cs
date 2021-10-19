using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class ConversationData
    {
        public static Dictionary<int, conversationdataclass> conversationList;

        public static System.Collections.Generic.Dictionary<int, Classes.ConversationDataClass> parsedConversationList =
            new System.Collections.Generic.Dictionary<int, Classes.ConversationDataClass>();

        internal static void Setup()
        {
            conversationList = conversationdata.GetData();
            foreach (KeyValuePair<int, conversationdataclass> conversation in conversationList)
            {
                parsedConversationList.Add(conversation.Key,
                    new Classes.ConversationDataClass(conversation.Key, conversationList));
            }
        }
    }
}