// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data.Classes
{
    public class EleabNormalDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, eleabnormaldataclass> eleabList;

        public EleabNormalDataClass(string key, Dictionary<string, eleabnormaldataclass> eleabList)
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
