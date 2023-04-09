// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data.Classes
{
    public class ClientCustomRulesDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, clientcustomrulesdataclass> ruleList;

        public ClientCustomRulesDataClass(int key, Dictionary<int, clientcustomrulesdataclass> ruleList)
        {
            this.key = key;
            this.ruleList = ruleList;
        }

        public List<int> LimitType
        {
            get => ruleList[key].LimitType;
        }
    }
}
