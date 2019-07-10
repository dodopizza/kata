using System;
using System.Collections.Generic;
using App.Tests.DSL;
using FluentAssertions;
using Xunit;

namespace App.Tests
{
	public class GlidedRoseShould
	{
		[Fact]
		public void Decrement_potato_sell_in_to_1()
		{
			var items = Create.Items().WithQuality(5).WithSellIn(5).Please();
			var gildedRose = Create.GildedRose()
				.WithItems(items)
				.Please();


			gildedRose.UpdateQuality();

			var item = items.Should().ContainSingle().Which;
			item.SellIn.Should().Be(4);
		}

		[Fact]
		public void Decrement_potato_quality_to_1()
		{
			var items = Create.Items().WithQuality(5).WithSellIn(5).Please();
			var gildedRose = Create.GildedRose()
				.WithItems(items)
				.Please();

			gildedRose.UpdateQuality();

			var item = items.Should().ContainSingle().Which;
			item.Quality.Should().Be(4);
		}

		[Fact]
		public void Decrement_potato_quality_to_2_WhenSaleByDatePast()
		{
			var items = Create.Items().WithQuality(5).WithSellIn(0).Please();
			var gildedRose = Create.GildedRose()
				.WithItems(items)
				.Please();

			gildedRose.UpdateQuality();

			var item = items.Should().ContainSingle().Which;
			item.Quality.Should().Be(3);
		}
	}
}