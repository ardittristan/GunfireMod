// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data.Classes
{
    public class EffectDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, effectdataclass> effectList;

        public EffectDataClass(string key, Dictionary<string, effectdataclass> effectList)
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
