using System.Collections.Generic;

namespace SKUPromotionEngine
{
    public class SKUData
    {
        public SKUData(List<SKUDetail> activePromotions, List<SKUDetail> skuActual)
        {
            ActivePromotions = activePromotions;
            SKUActual = skuActual;
        }
        public List<SKUDetail> ActivePromotions { get; }
        public List<SKUDetail> SKUActual { get; }
    }
}
