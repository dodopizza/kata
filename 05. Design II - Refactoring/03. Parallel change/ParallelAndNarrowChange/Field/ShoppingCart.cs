using System;

namespace ParallelAndNarrowChange.Field
{
    public class ShoppingCart
    {
        private decimal price;

        public decimal CalculateTotalPrice()
        {
            return price;
        }

        public bool HasDiscount()
        {
            return price > 100;
        }

        [Obsolete("Use AddAnother")]
        public void Add(int aPrice)
        {
            price = aPrice;
        }

        public int NumberOfProducts()
        {
            return 1;
        }

        public void AddAnother(int anotherPrice)
        {
            price += anotherPrice;
        }
    }
}