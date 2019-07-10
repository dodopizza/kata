using System.Collections.Generic;

namespace App.Tests.DSL
{
	public class Create
	{
		public static GildedRoseBuilder GildedRose()
		{
			return new GildedRoseBuilder();
		}

		public static ItemBuilder Items()
		{
			return new ItemBuilder();
		}
	}

	public class ItemBuilder
	{
		private Item _item = new Item
		{
			Name = "Potato"
		};

		public ItemBuilder WithQuality(int quality)
		{
			_item.Quality = quality;
			return this;
		}

		public ItemBuilder WithSellIn(int sellIn)
		{
			_item.SellIn = sellIn;
			return this;
		}

		public IList<Item> Please()
		{
			return new List<Item>
			{
				_item
			};
		}

		public ItemBuilder WithName(string name)
		{
			_item.Name = name;
			return this;
		}
	}

	public class GildedRoseBuilder
	{
		private IList<Item> _items = new List<Item>();

		public GildedRose Please()
		{
			return new GildedRose(_items);
		}

		public GildedRoseBuilder WithItems(IList<Item> items)
		{
			_items = items;
			return this;
		}
	}
}