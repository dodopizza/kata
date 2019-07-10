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
	}
}