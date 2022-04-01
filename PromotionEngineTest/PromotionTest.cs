using NUnit.Framework;
using SKUPromotionEngine;
using System;
using System.Collections.Generic;

namespace PromotionEngineTest
{
    [TestFixture]
    public class PromotionTest
    {
        private SKUCalculator skuCalculator;
        [SetUp]
        public void SetUp()
        {
            var skuData = new SKUData(MockData.ActivePromotions, MockData.SKUActual);
            skuCalculator = new SKUCalculator(skuData);
        }

        [Test]
        public void CalculateTotalOrderValue_Return100()
        {
            //Scenario - 1
            var details = new List<SKUDetail>()
            {
                new SKUDetail() { SkuId = "A", Unit = 1 },
                new SKUDetail() { SkuId = "B", Unit = 1 },
                new SKUDetail() { SkuId = "C", Unit = 1 }
            };

            var total = skuCalculator.CalculateTotalOrderValue(details);
            Console.WriteLine($"Expected Total Order value :100");
            Console.WriteLine($"Actual Total Order value :{total}");

            Assert.AreEqual(100, total);
        }

        [Test]
        public void CalculateTotalOrderValue_Return370()
        {
            //Scenario-2
            var details = new List<SKUDetail>()
            {
                new SKUDetail() { SkuId = "A", Unit = 5 },
                new SKUDetail() { SkuId = "B", Unit = 5 },
                new SKUDetail() { SkuId = "C", Unit = 1 }
            };

            var total = skuCalculator.CalculateTotalOrderValue(details);
            Console.WriteLine($"Expected Total Order value :370");
            Console.WriteLine($"Actual Total Order value :{total}");

            Assert.AreEqual(370, total);
        }
    }
}
