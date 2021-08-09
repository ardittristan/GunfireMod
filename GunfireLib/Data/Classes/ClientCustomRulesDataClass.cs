// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data.Classes
{
    public class ClientCustomRulesDataClass
    {
        private readonly string key;
        private readonly Dictionary<string, clientcustomrulesdataclass> ruleList;

        public ClientCustomRulesDataClass(string key, Dictionary<string, clientcustomrulesdataclass> ruleList)
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
