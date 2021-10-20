using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class RelicBoxGoodsData
    {
        public static Dictionary<int, boxgoodsdataclass> goodsList;

        public static System.Collections.Generic.Dictionary<int, Classes.BoxGoodsDataClass> parsedGoodsList =
            new System.Collections.Generic.Dictionary<int, Classes.BoxGoodsDataClass>();

        internal static void Setup()
        {
            goodsList = relicboxgoodsdata.GetData();
            foreach (KeyValuePair<int, boxgoodsdataclass> good in goodsList)
            {
                parsedGoodsList.Add(good.Key, new Classes.BoxGoodsDataClass(good.Key, goodsList));
            }
        }
    }
}