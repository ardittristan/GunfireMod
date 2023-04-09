using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppDataHelper;

namespace GunfireLib.Data
{
    public static class MonsterGalleryData
    {
        public static Dictionary<int, monstergalleryclsdataclass> galleryList;

        public static System.Collections.Generic.Dictionary<int, Classes.MonsterGalleryClsDataClass>
            parsedGalleryList =
                new System.Collections.Generic.Dictionary<int, Classes.MonsterGalleryClsDataClass>();

        internal static void Setup()
        {
            galleryList = monstergallerydata.GetData();
            foreach (KeyValuePair<int, monstergalleryclsdataclass> gallery in galleryList)
            {
                parsedGalleryList.Add(gallery.Key, new Classes.MonsterGalleryClsDataClass(gallery.Key, galleryList));
            }
        }
    }
}