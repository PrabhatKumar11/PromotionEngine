using System.Collections.Generic;

namespace SKUPromotionEngine
{
    public interface ISKUCalculator
    {
        decimal CalculateTotalOrderValue(List<SKUDetail> clientSkuDetails);
    }
}