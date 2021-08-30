using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class MonsterGalleryClsData
    {
        public static Dictionary<string, monstergalleryclsdataclass> galleryList;

        public static System.Collections.Generic.Dictionary<string, Classes.MonsterGalleryClsDataClass>
            parsedGalleryList =
                new System.Collections.Generic.Dictionary<string, Classes.MonsterGalleryClsDataClass>();

        internal static void Setup()
        {
            galleryList = monstergalleryclsdata.GetData();
            foreach (KeyValuePair<string, monstergalleryclsdataclass> gallery in galleryList)
            {
                parsedGalleryList.Add(gallery.Key, new Classes.MonsterGalleryClsDataClass(gallery.Key, galleryList));
            }
        }
    }
}