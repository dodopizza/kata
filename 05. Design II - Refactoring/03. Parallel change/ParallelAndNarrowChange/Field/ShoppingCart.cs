namespace ParallelAndNarrowChange.Field
{
    public class ShoppingCart
    {
        private decimal price;

        public decimal CalculateTotalPrice()
        {
            return price;
        }

        public void Add(int price)
        {
            this.price += price;
        }

        public bool HasDiscount()
        {
            return price > 100;
        }

        public int NumberOfProducts()
        {
            return 1;
        }

        public int TotalNumberOfProducts()
        {
            return 2;
        }
    }
}