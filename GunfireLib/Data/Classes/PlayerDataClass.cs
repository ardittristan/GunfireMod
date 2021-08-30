// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data.Classes
{
    public class PlayerDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, playerdataclass> playerList;

        public PlayerDataClass(string key, Dictionary<string, playerdataclass> playerList)
        {
            this.key = key;
            this.playerList = playerList;
        }

        // TODO:
        public Dictionary<string, PlayerGradeInfo> PlayerInfo
        {
            get => playerList[key].PlayerInfo;
        }
    }
}
