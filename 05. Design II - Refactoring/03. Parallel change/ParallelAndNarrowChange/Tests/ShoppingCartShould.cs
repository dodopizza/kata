using FluentAssertions;
using NUnit.Framework;
using ParallelAndNarrowChange.Field;

namespace ParallelAndNarrowChange.Tests
{
    [TestFixture]
    public class ShoppingCartShould
    {
        private ShoppingCart cart;

        [SetUp]
        public void SetUp()
        {
            cart = new ShoppingCart();
        }

        [Test]
        public void calculate_the_final_price()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.Add(10);

            var totalPrice = shoppingCart.CalculateTotalPrice();

            totalPrice.Should().Be(10);
        }

        [Test]
        public void knows_the_number_of_items()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.Add(10);

            var numberOfProducts = shoppingCart.NumberOfProducts();

            numberOfProducts.Should().Be(1);
        }

        [Test]
        public void may_offer_discounts_when_there_at_least_one_expensive_product()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.Add(120);

            var hasDiscount = shoppingCart.HasDiscount();

            hasDiscount.Should().BeTrue();
        }

        [Test]
        public void does_not_offer_discount_for_cheap_products()
        {
            var shoppingCart = cart = new ShoppingCart();
            shoppingCart.Add(10);

            var hasDiscount = shoppingCart.HasDiscount();
            
            hasDiscount.Should().BeFalse();
        }
    }
}