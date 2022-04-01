using SKUPromotionEngine;
using System.Collections.Generic;

namespace PromotionEngineTest
{
    internal static class MockData
    {
        public static List<SKUDetail> ActivePromotions => new List<SKUDetail>()
            {
                new SKUDetail(){SkuId="A",Unit=3, UnitPrice=130 },
                new SKUDetail(){SkuId="B",Unit=2, UnitPrice=45 },
            };

        public static List<SKUDetail> SKUActual => new List<SKUDetail>()
            {
                new SKUDetail() { SkuId="A", Unit=1, UnitPrice=50},
                new SKUDetail() { SkuId="B", Unit=1, UnitPrice=30},
                new SKUDetail() { SkuId="C", Unit=1, UnitPrice=20},
                new SKUDetail() { SkuId="D", Unit=1, UnitPrice=10}
            };

    }
}
