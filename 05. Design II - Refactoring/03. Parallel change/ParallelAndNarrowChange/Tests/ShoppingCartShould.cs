using FluentAssertions;
using NUnit.Framework;
using ParallelAndNarrowChange.Field;

namespace ParallelAndNarrowChange{
    [TestFixture]
    public class ShoppingCartShould{
        private ShoppingCart cart;

        [SetUp]
        public void SetUp(){
            cart = new ShoppingCart();
        }

        [Test]
        public void calculate_the_final_price(){
            cart.Add(10);

            cart.CalculateTotalPrice().Should().Be(10);
        }

        [Test]
        public void knows_the_number_of_items(){
            cart.Add(10);

            cart.NumberOfProducts().Should().Be(1);
        }

        [Test]
        public void may_offer_discounts_when_there_at_least_one_expensive_product(){
            cart.Add(120);

            cart.HasDiscount().Should().BeTrue();
        }

        [Test]
        public void does_not_offer_discount_for_cheap_products(){
            cart.Add(10);

            cart.HasDiscount().Should().BeFalse();
        }
    }
}
