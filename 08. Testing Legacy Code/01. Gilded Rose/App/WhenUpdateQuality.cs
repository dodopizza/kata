using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace App
{
    [TestFixture]
    public class WhenUpdateQuality
    {
        [Test]
        public void ForRegularItem_QualityDecrements()
        {
            var items = new List<Item> {new Item {Name = "Any", SellIn = 1, Quality = 200}};
            var app = new GildedRose(items);

            app.UpdateQuality();
            
            Assert.AreEqual(199, items.Single().Quality);
        }
    }
}