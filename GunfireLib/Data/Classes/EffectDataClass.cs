// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data.Classes
{
    public class EffectDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, effectdataclass> effectList;

        public EffectDataClass(int key, Dictionary<int, effectdataclass> effectList)
        {
            this.key = key;
            this.effectList = effectList;
        }

        public string EffectPath
        {
            get => effectList[key].EffectPath;
        }
    }
}
