using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileAttributeScrollData
    {
        public static Dictionary<int, itemdataclass> attributeList;

        public static System.Collections.Generic.Dictionary<int, Classes.ItemDataClass> parsedAttributeList =
            new System.Collections.Generic.Dictionary<int, Classes.ItemDataClass>();

        internal static void Setup()
        {
            attributeList = mobileattrscrolldata.GetData();
            foreach (KeyValuePair<int, itemdataclass> attribute in attributeList)
            {
                parsedAttributeList.Add(attribute.Key, new Classes.ItemDataClass(attribute.Key, attributeList));
            }
        }
    }
}