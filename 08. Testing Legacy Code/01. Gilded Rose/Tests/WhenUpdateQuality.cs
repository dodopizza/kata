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
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(199, items.Single().Quality);
        }

        [Test]
        public void ForExpiredRegulatItem_QualityDecreses2X()
        {
            var items = Create.RegularItem(0, 200);
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(198, items.Single().Quality);
        }

        [Test]
        public void QualityShouldNotBeNegative()
        {
            var items = Create.RegularItem(1, 0);
            var app = new GildedRose(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(0, items.Single().Quality);
        }
    }
}