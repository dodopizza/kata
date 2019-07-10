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
        
        private static List<Item> Items(string name, int sellIn, int quality)
        {
            return new List<Item> {new Item {Name = name, SellIn = sellIn, Quality = quality}};
        }
    }
}