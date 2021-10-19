// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data.Classes
{
    public class PlayerDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, playerdataclass> playerList;

        public PlayerDataClass(int key, Dictionary<int, playerdataclass> playerList)
        {
            this.key = key;
            this.playerList = playerList;
        }

        // TODO:
        public Dictionary<int, PlayerGradeInfo> PlayerInfo
        {
            get => playerList[key].PlayerInfo;
        }
    }
}
