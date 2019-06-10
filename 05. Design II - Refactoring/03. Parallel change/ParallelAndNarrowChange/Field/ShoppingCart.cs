using System;

namespace ParallelAndNarrowChange.Field
{
    public class ShoppingCart
    {
        private decimal price;
        private int numberOfProducts;

        public decimal CalculateTotalPrice()
        {
            return price;
        }

        public void Add(int price)
        {
            this.price += price;
            numberOfProducts++;
        }

        public bool HasDiscount()
        {
            return price > 100;
        }

        [Obsolete("Use TotalNumberOfProducts")]
        public int NumberOfProducts()
        {
            return 1;
        }

        public int TotalNumberOfProducts()
        {
            return numberOfProducts;
        }
    }
}