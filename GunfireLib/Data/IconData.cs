using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class IconData
    {
        public static Dictionary<int, icondataclass> iconList;

        public static System.Collections.Generic.Dictionary<int, Classes.IconDataClass> parsedIconList =
            new System.Collections.Generic.Dictionary<int, Classes.IconDataClass>();

        internal static void Setup()
        {
            iconList = icondata.GetData();
            foreach (KeyValuePair<int, icondataclass> icon in iconList)
            {
                parsedIconList.Add(icon.Key, new Classes.IconDataClass(icon.Key, iconList));
            }
        }
    }
}