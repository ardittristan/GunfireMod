// ReSharper disable InconsistentNaming
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable StringLiteralTypo
using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data.Classes
{
    public class HeroRelevanceDataClass
    {
        private readonly int key;
        private readonly Dictionary<int, herorelevancedataclass> relevanceList;

        public HeroRelevanceDataClass(int key, Dictionary<int, herorelevancedataclass> relevanceList)
        {
            this.key = key;
            this.relevanceList = relevanceList;
        }

        public int ID
        {
            get => relevanceList[key].ID;
        }

        // TODO:?
        public Dictionary<string, int> Skill
        {
            get => relevanceList[key].Skill;
        }
    }
}
