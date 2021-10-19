// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data.Classes
{
    public class UnlockDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, unlockdataclass> unlockList;

        public UnlockDataClass(int key, Dictionary<int, unlockdataclass> unlockList)
        {
            this.key = key;
            this.unlockList = unlockList;
        }

        //public int SceneID
        //{
        //    get => unlockList[key].SceneID;
        //}

        //public int TarNum
        //{
        //    get => unlockList[key].TarNum;
        //}

        public int Type
        {
            get => unlockList[key].Type;
        }
    }
}
