using System.Collections.Generic;
using System.Linq;
using App;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WhenUpdateQuality
    {
        [Test]
        public void ForRegularItem_QualityDecrements()
        {
            var items = Create.RegularItem(1, 200);

            UpdateQuality(items);

            Assert.AreEqual(199, items.Single().Quality);
        }

        [Test]
        public void ForExpiredRegulatItem_QualityDecreses2X()
        {
            var items = Create.RegularItem(0, 200);

            UpdateQuality(items);

            Assert.AreEqual(198, items.Single().Quality);
        }

        [Test]
        public void QualityShouldNotBeNegative()
        {
            var items = Create.RegularItem(1, 0);

            UpdateQuality(items);
            
            Assert.AreEqual(0, items.Single().Quality);
        }

        [Test]
        public void ForAgedBrie_QualityIncreses()
        {
            var items = Create.AgedBrie(1, 10);

            UpdateQuality(items);
            
            Assert.AreEqual(11, items.Single().Quality);
        }

        [Test]
        public void ForAgedBrie_QualityCannotExceed50()
        {
            var items = Create.AgedBrie(1, 50);

            UpdateQuality(items);
            
            Assert.AreEqual(50, items.Single().Quality);
        }

        [Test]
        public void ForSulfuras_QualityIs80()
        {
            var items = Create.Sulfuras(1, 80);

            UpdateQuality(items);
            
            Assert.AreEqual(80, items.Single().Quality);
        }

        [Test]
        public void ForExpiredSulfuras_QualityIs80()
        {
            var items = Create.Sulfuras(0, 80);

            UpdateQuality(items);
            
            Assert.AreEqual(80, items.Single().Quality);
        }

        [Test]
        public void ForBackstagePass_QualityIncreases_IfSellInMoreThan10()
        {
            var items = Create.BackstagePass(11, 30);

            UpdateQuality(items);
            
            Assert.AreEqual(31, items.Single().Quality);
        }

        [Test]
        public void ForBackstagePass_QualityIncreasesX2_IfSellInLessThan10()
        {
            var items = Create.BackstagePass(10, 30);

            UpdateQuality(items);

            Assert.AreEqual(32, items.Single().Quality);
        }

        private static void UpdateQuality(IList<Item> items)
        {
            var app = new GildedRose(items);

            app.UpdateQuality();
        }
    }
}