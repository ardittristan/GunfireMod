using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class AttributePlusData
    {
        public static Dictionary<int, attrplusdataclass> attributeList;

        public static System.Collections.Generic.Dictionary<int, Classes.AttrPlusDataClass> parsedAttributeList =
            new System.Collections.Generic.Dictionary<int, Classes.AttrPlusDataClass>();

        internal static void Setup()
        {
            attributeList = attrplusdata.GetData();
            foreach (KeyValuePair<int, attrplusdataclass> attribute in attributeList)
            {
                parsedAttributeList.Add(attribute.Key, new Classes.AttrPlusDataClass(attribute.Key, attributeList));
            }
        }
    }
}
