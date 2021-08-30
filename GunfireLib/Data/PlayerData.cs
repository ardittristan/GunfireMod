using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class PlayerData
    {
        public static Dictionary<string, playerdataclass> playerList;

        public static System.Collections.Generic.Dictionary<string, Classes.PlayerDataClass> parsedPlayerList =
            new System.Collections.Generic.Dictionary<string, Classes.PlayerDataClass>();

        internal static void Setup()
        {
            playerList = playerdata.GetData();
            foreach (KeyValuePair<string, playerdataclass> player in playerList)
            {
                parsedPlayerList.Add(player.Key, new Classes.PlayerDataClass(player.Key, playerList));
            }
        }
    }
}