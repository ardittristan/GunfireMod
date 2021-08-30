// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data.Classes
{
    public class MapEffectDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, mapeffectdataclass> effectList;

        public MapEffectDataClass(string key, Dictionary<string, mapeffectdataclass> effectList)
        {
            this.key = key;
            this.effectList = effectList;
        }

        public int MapEffectPathID
        {
            get => effectList[key].MapEffectPathID;
        }
    }
}
