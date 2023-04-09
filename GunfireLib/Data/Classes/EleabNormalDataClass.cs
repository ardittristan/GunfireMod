// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data.Classes
{
    public class EleabNormalDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, eleabnormaldataclass> eleabList;

        public EleabNormalDataClass(int key, Dictionary<int, eleabnormaldataclass> eleabList)
        {
            this.key = key;
            this.eleabList = eleabList;
        }

        public int IconID
        {
            get => eleabList[key].IconID;
        }

        public string IconPath
        {
            get => eleabList[key].IconPath;
        }

        public int ID
        {
            get => eleabList[key].ID;
        }
    }
}
