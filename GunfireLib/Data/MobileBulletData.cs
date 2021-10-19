using DataHelper;
using Il2CppSystem.Collections.Generic;

namespace GunfireLib.Data
{
    public static class MobileBulletData
    {
        public static Dictionary<int, itemdataclass> attributeList;

        public static System.Collections.Generic.Dictionary<int, Classes.ItemDataClass> parsedAttributeList =
            new System.Collections.Generic.Dictionary<int, Classes.ItemDataClass>();

        internal static void Setup()
        {
            attributeList = mobilebulletdata.GetData();
            foreach (KeyValuePair<int, itemdataclass> bullet in attributeList)
            {
                parsedAttributeList.Add(bullet.Key, new Classes.ItemDataClass(bullet.Key, attributeList));
            }
        }
    }
}