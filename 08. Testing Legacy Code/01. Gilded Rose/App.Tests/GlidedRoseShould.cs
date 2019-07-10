using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace App.Tests
{
	public class GlidedRoseShould
	{
		[Fact]
		public void Decrement_potato_sell_in_to_1()
		{
			var products = new List<Item>
			{
				new Item
				{
					Name = "Potato",
					Quality = 5,
					SellIn = 5,
				}
			};
			var gildedRose = new GildedRose(products);

			gildedRose.UpdateQuality();

			var potato = products.Should().ContainSingle().Which;
			potato.SellIn.Should().Be(4);
		}

		[Fact]
		public void Decrement_potato_quality_to_1()
		{
			var products = new List<Item>
			{
				new Item
				{
					Name = "Potato",
					Quality = 5,
					SellIn = 5,
				}
			};
			var gildedRose = new GildedRose(products);

			gildedRose.UpdateQuality();

			var potato = products.Should().ContainSingle().Which;
			potato.Quality.Should().Be(4);
		}
	}
}