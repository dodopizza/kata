using System.Collections.Generic;
using NUnit.Framework;

namespace App
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> {new Item {Name = "foo", SellIn = 0, Quality = 0}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void WhenNonSpecificName_AndQualityAndSellIs1_ThenQualityAndSellInReduceOn1()
        {
            var item = new Item
            {
                Name = "default",
                Quality = 1,
                SellIn = 1
            };
            var items = new[] {item};
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();

            var expected = new Item {Name = "default", Quality = 0, SellIn = 0};
            var actual = item;
            Assert.AreEqual(expected, actual);
        }
        
        //Sulfuras, Hand of Ragnaros
        [Test]
        public void WhenNameIs_Sulfuras_Hand_of_Ragnaros_AndQualityAndSellIs1_ThenQualityAndSellShouldBeSame()
        {
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = 1,
                SellIn = 1
            };
            var items = new[] {item};
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();

            var expected = new Item {Name = "Sulfuras, Hand of Ragnaros", Quality = 1, SellIn = 1};
            var actual = item;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WhenNonSpecificName_AndQualityIs0AndSellIs1_ThenQualityShouldBeSameAndSellInReduceOn1()
        {
            var item = new Item
            {
                Name = "default",
                Quality = 0,
                SellIn = 1
            };
            var items = new[] {item};
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();
            
            var expected = new Item {Name = "default", Quality = 0, SellIn = 0};
            var actual = item;
            Assert.AreEqual(expected, actual);
        }
        
        //Aged Brie
        [Test]
        public void WhenNameIs_Aged_Brie_AndQualityIs1AndSellIs1_ThenQualityShouldBe2AndSellInReduceOn1()
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = 1,
                SellIn = 1
            };
            var items = new[] {item};
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();
            
            var expected = new Item {Name = "Aged Brie", Quality = 2, SellIn = 0};
            var actual = item;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WhenNameIs_Backstage_AndQualityIs1AndSellIs1_ThenQualityShouldBe4AndSellIs0()
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 1,
                SellIn = 1
            };
            var items = new[] {item};
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();
            
            var expected = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 4, SellIn = 0};
            var actual = item;
            Assert.AreEqual(expected, actual);
        }
    }
}