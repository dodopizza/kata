using System;
using System.Collections.Generic;
using App.Tests.DSL;
using FluentAssertions;
using Xunit;

namespace App.Tests
{
	public class GlidedRoseShould
	{
		[Theory]
		[InlineData(5, 5, 4, 4)]
		[InlineData(5, 0, 3, -1)]
		[InlineData(0, 5, 0, 4)]
		public void DecrementQualityAndSellIn(int startingQuality, int staringSellIn, int expectedQuality, int expectedSellIn)
		{
			var items = Create.Items()
				.WithQuality(startingQuality)
				.WithSellIn(staringSellIn)
				.Please();
			var gildedRose = Create.GildedRose()
				.WithItems(items)
				.Please();

			gildedRose.UpdateQuality();

			var item = items.Should().ContainSingle().Which;
			item.Quality.Should().Be(expectedQuality);
			item.SellIn.Should().Be(expectedSellIn);
		}
		
		[Theory]
		[InlineData(5, 5, 6, 4)]
		[InlineData(50, 5, 50, 4)]
		public void IncrementQualityAndDecrementSellIn_ForAgedBrie(int startingQuality, int staringSellIn, int expectedQuality, int expectedSellIn)
		{
			var items = Create.Items()
				.WithName("Aged Brie")
				.WithQuality(startingQuality)
				.WithSellIn(staringSellIn)
				.Please();
			var gildedRose = Create.GildedRose()
				.WithItems(items)
				.Please();

			gildedRose.UpdateQuality();

			var item = items.Should().ContainSingle().Which;
			item.Quality.Should().Be(expectedQuality);
			item.SellIn.Should().Be(expectedSellIn);
		}
		
		[Theory]
		[InlineData(5, 5, 5, 5)]
		public void NotChangeQualityAndSellIn_ForSulfuras(int startingQuality, int staringSellIn, int expectedQuality, int expectedSellIn)
		{
			var items = Create.Items()
				.WithName("Sulfuras, Hand of Ragnaros")
				.WithQuality(startingQuality)
				.WithSellIn(staringSellIn)
				.Please();
			var gildedRose = Create.GildedRose()
				.WithItems(items)
				.Please();

			gildedRose.UpdateQuality();

			var item = items.Should().ContainSingle().Which;
			item.Quality.Should().Be(expectedQuality);
			item.SellIn.Should().Be(expectedSellIn);
		}

		[Theory]
		[InlineData(1, 11, 2, 10)]
		[InlineData(1, 10, 3, 9)]
		[InlineData(1, 6, 3, 5)]
		[InlineData(1, 5, 4, 4)]
		public void ChangeQualityAndSellIn_ForBackstagePasses(int startingQuality, int staringSellIn, int expectedQuality, int expectedSellIn)
		{
			var items = Create.Items()
				.WithName("Backstage passes to a TAFKAL80ETC concert")
				.WithQuality(startingQuality)
				.WithSellIn(staringSellIn)
				.Please();
			var gildedRose = Create.GildedRose()
				.WithItems(items)
				.Please();

			gildedRose.UpdateQuality();

			var item = items.Should().ContainSingle().Which;
			item.Quality.Should().Be(expectedQuality);
			item.SellIn.Should().Be(expectedSellIn);
		}
	}
}