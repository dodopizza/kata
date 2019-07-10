using System.Collections.Generic;

namespace App
{
    public class Create
    { 
        public static IList<Item> AgedBrie(int sellIn, int quality)
        {
            return Items("Aged Brie", sellIn, quality);
        }
        
        public static IList<Item> RegularItem(int sellIn, int quality)
        {
            return Items("Any", sellIn, quality);
        }
        
        public static IList<Item> Sulfuras(int sellIn, int quality)
        {
            return Items("Sulfuras, Hand of Ragnaros", sellIn, quality);
        }
        public static IList<Item> BackstagePass(int sellIn, int quality)
        {
            return Items("Backstage passes to a TAFKAL80ETC concert", sellIn, quality);
        }
        
        private static List<Item> Items(string name, int sellIn, int quality)
        {
            return new List<Item> {new Item {Name = name, SellIn = sellIn, Quality = quality}};
        }

    }
}