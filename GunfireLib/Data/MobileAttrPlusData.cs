using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileAttrPlusData
    {
        public static Dictionary<int, attrplusdataclass> attributeList;

        public static System.Collections.Generic.Dictionary<int, Classes.AttrPlusDataClass> parsedAttributeList =
            new System.Collections.Generic.Dictionary<int, Classes.AttrPlusDataClass>();

        internal static void Setup()
        {
            attributeList = mobileattrplusdata.GetData();
            foreach (KeyValuePair<int, attrplusdataclass> attribute in attributeList)
            {
                parsedAttributeList.Add(attribute.Key, new Classes.AttrPlusDataClass(attribute.Key, attributeList));
            }
        }
    }
}