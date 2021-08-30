using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileAttributeScrollData
    {
        public static Dictionary<string, itemdataclass> attributeList;

        public static System.Collections.Generic.Dictionary<string, Classes.ItemDataClass> parsedAttributeList =
            new System.Collections.Generic.Dictionary<string, Classes.ItemDataClass>();

        internal static void Setup()
        {
            attributeList = mobileattrscrolldata.GetData();
            foreach (KeyValuePair<string, itemdataclass> attribute in attributeList)
            {
                parsedAttributeList.Add(attribute.Key, new Classes.ItemDataClass(attribute.Key, attributeList));
            }
        }
    }
}