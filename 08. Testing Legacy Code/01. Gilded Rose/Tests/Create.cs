using System.Collections.Generic;

namespace App
{
    public class Create
    {
        public static IList<Item> RegularItem(int sellIn, int quality)
        {
            return new List<Item> {new Item {Name = "Any", SellIn = sellIn, Quality = quality}};
        }

        public static IList<Item> AgedBrie(int sellIn, int quality)
        {
            return new List<Item> {new Item {Name = "Aged Brie", SellIn = sellIn, Quality = quality}};
        }
    }
}