using System;
using System.Collections.Generic;
using System.Linq;

namespace SKUPromotionEngine
{
    public class SKUCalculator : ISKUCalculator
    {
        private SKUData skuData;
        public SKUCalculator(SKUData skuData)
        {
            this.skuData = skuData;
        }
        public decimal CalculateTotalOrderValue(List<SKUDetail> clientSkuDetails)
        {
            decimal total = 0;
            foreach (var clientSkuDetail in clientSkuDetails)
            {
                decimal subTotal = 0;
                var promotion = skuData.ActivePromotions.Where(x => x.SkuId == clientSkuDetail.SkuId).FirstOrDefault();
                var skuActual = skuData.SKUActual.Where(x => x.SkuId == clientSkuDetail.SkuId).FirstOrDefault();
                if (promotion != null && clientSkuDetail.SkuId == promotion.SkuId)
                {
                    if (clientSkuDetail.Unit < promotion.Unit)
                        subTotal += SimpleCalculation(clientSkuDetail, skuActual);
                    else
                        subTotal += PromotionalCalculation(clientSkuDetail, promotion, skuActual);
                }
                else
                {
                    subTotal += SimpleCalculation(clientSkuDetail, skuActual);
                }

                Console.WriteLine($"Order value of {clientSkuDetail.SkuId} = {subTotal}");
                total += subTotal;
            }
            return total;
        }

        private decimal PromotionalCalculation(SKUDetail detail, SKUDetail promotion, SKUDetail actual)
        {
            decimal total = 0;
            while (detail.Unit > promotion.Unit)
            {
                total += promotion.UnitPrice;
                detail.Unit -= promotion.Unit;
            }
            if (detail.Unit != 0)
                return total += detail.Unit * actual.UnitPrice;
            return total;
        }

        private decimal SimpleCalculation(SKUDetail detail, SKUDetail actual)
        {
            return detail.Unit * actual.UnitPrice;
        }
    }
}
