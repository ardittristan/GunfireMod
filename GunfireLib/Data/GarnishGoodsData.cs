using Il2CppSystem.Collections.Generic;
using DataHelper;

namespace GunfireLib.Data
{
    public static class GarnishGoodsData
    {
        public static Dictionary<string, garnishgoodsdataclass> goodsList;

        public static System.Collections.Generic.Dictionary<string, Classes.GarnishGoodsDataClass> parsedGoodsList =
            new System.Collections.Generic.Dictionary<string, Classes.GarnishGoodsDataClass>();

        internal static void Setup()
        {
            goodsList = garnishgoodsdata.GetData();
            foreach (KeyValuePair<string, garnishgoodsdataclass> goods in goodsList)
            {
                parsedGoodsList.Add(goods.Key, new Classes.GarnishGoodsDataClass(goods.Key, goodsList));
            }
        }
    }
}