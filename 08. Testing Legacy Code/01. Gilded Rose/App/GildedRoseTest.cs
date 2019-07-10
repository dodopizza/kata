﻿using System.Collections.Generic;
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
        public void WhenNonSpecificName_AndQualityAndSellMoreThen0_ThenQualityAndSellInReduceOn1()
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
        public void WhenNameIs_Sulfuras_Hand_of_Ragnaros_AndQualityAndSellMoreThen0_ThenQualityAndSellShouldBeSame()
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
        public void WhenNonSpecificName_AndQualityIs0AndSellMoreThan0_ThenQualityShouldBeSameAndSellInReduceOn1()
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
    }
}