using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class ClientsGData
    {
        public static Dictionary<string, clientsgdataclass> clientList;

        public static System.Collections.Generic.Dictionary<string, Classes.ClientsGDataClass> parsedClientList =
            new System.Collections.Generic.Dictionary<string, Classes.ClientsGDataClass>();

        internal static void Setup()
        {
            clientList = clientsgdata.GetData();
            foreach (KeyValuePair<string, clientsgdataclass> client in clientList)
            {
                parsedClientList.Add(client.Key, new Classes.ClientsGDataClass(client.Key, clientList));
            }
        }
    }
}