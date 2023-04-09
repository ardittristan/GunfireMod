// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data.Classes
{
    public class MapEffectDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, mapeffectdataclass> effectList;

        public MapEffectDataClass(int key, Dictionary<int, mapeffectdataclass> effectList)
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
