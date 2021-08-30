// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data.Classes
{
    public class LocalWarBornPosDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, localwarbornposdataclass> posList;

        public LocalWarBornPosDataClass(string key, Dictionary<string, localwarbornposdataclass> posList)
        {
            this.key = key;
            this.posList = posList;
        }

        public int SceneID
        {
            get => posList[key].SceneID;
        }

        public int X
        {
            get => posList[key].X;
        }

        public int Y
        {
            get => posList[key].Y;
        }

        public int Z
        {
            get => posList[key].Z;
        }
    }
}
