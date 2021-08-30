using DataHelper;
using Il2CppSystem.Collections.Generic;

namespace GunfireLib.Data
{
    public static class MobileBulletData
    {
        public static Dictionary<string, itemdataclass> attributeList;

        public static System.Collections.Generic.Dictionary<string, Classes.ItemDataClass> parsedAttributeList =
            new System.Collections.Generic.Dictionary<string, Classes.ItemDataClass>();

        internal static void Setup()
        {
            attributeList = mobilebulletdata.GetData();
            foreach (KeyValuePair<string, itemdataclass> bullet in attributeList)
            {
                parsedAttributeList.Add(bullet.Key, new Classes.ItemDataClass(bullet.Key, attributeList));
            }
        }
    }
}