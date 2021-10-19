using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class GarnishGoodsData
    {
        public static Dictionary<int, garnishgoodsdataclass> goodsList;

        public static System.Collections.Generic.Dictionary<int, Classes.GarnishGoodsDataClass> parsedGoodsList =
            new System.Collections.Generic.Dictionary<int, Classes.GarnishGoodsDataClass>();

        internal static void Setup()
        {
            goodsList = garnishgoodsdata.GetData();
            foreach (KeyValuePair<int, garnishgoodsdataclass> goods in goodsList)
            {
                parsedGoodsList.Add(goods.Key, new Classes.GarnishGoodsDataClass(goods.Key, goodsList));
            }
        }
    }
}