using System.Collections.Generic;

namespace App
{
    public class Create
    {
        public static IList<Item> RegularItem(int sellIn, int quality)
        {
            return new List<Item> {new Item {Name = "Any", SellIn = sellIn, Quality = quality}};
        }
    }
}