using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class PlayerData
    {
        public static Dictionary<int, playerdataclass> playerList;

        public static System.Collections.Generic.Dictionary<int, Classes.PlayerDataClass> parsedPlayerList =
            new System.Collections.Generic.Dictionary<int, Classes.PlayerDataClass>();

        internal static void Setup()
        {
            playerList = playerdata.GetData();
            foreach (KeyValuePair<int, playerdataclass> player in playerList)
            {
                parsedPlayerList.Add(player.Key, new Classes.PlayerDataClass(player.Key, playerList));
            }
        }
    }
}