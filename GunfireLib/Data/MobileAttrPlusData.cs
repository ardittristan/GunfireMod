using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MobileAttrPlusData
    {
        public static Dictionary<string, attrplusdataclass> attributeList;

        public static System.Collections.Generic.Dictionary<string, Classes.AttrPlusDataClass> parsedAttributeList =
            new System.Collections.Generic.Dictionary<string, Classes.AttrPlusDataClass>();

        internal static void Setup()
        {
            attributeList = mobileattrplusdata.GetData();
            foreach (KeyValuePair<string, attrplusdataclass> attribute in attributeList)
            {
                parsedAttributeList.Add(attribute.Key, new Classes.AttrPlusDataClass(attribute.Key, attributeList));
            }
        }
    }
}