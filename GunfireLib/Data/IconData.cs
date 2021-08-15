using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class IconData
    {
        public static Dictionary<string, icondataclass> iconList;

        public static System.Collections.Generic.Dictionary<string, Classes.IconDataClass> parsedIconList =
            new System.Collections.Generic.Dictionary<string, Classes.IconDataClass>();

        internal static void Setup()
        {
            iconList = icondata.GetData();
            foreach (KeyValuePair<string, icondataclass> icon in iconList)
            {
                parsedIconList.Add(icon.Key, new Classes.IconDataClass(icon.Key, iconList));
            }
        }
    }
}