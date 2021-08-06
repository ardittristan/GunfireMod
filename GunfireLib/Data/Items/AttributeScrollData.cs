using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data.Items
{
    public static class AttirbuteScrollData
    {
        public static Dictionary<string, itemdataclass> attributeList;
        public static System.Collections.Generic.Dictionary<string, Classes.ItemDataClass> parsedAttributeList = new System.Collections.Generic.Dictionary<string, Classes.ItemDataClass>();

        internal static void Setup()
        {
            attributeList = attrscrolldata.GetData();
            foreach (KeyValuePair<string, itemdataclass> attribute in attributeList)
            {
                parsedAttributeList.Add(attribute.Key, new Classes.ItemDataClass(attribute.Key, attributeList));
            }
        }
    }
}
