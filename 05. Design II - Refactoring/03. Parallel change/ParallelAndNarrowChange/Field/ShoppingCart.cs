namespace ParallelAndNarrowChange.Field
{
    public class ShoppingCart
    {
        private decimal price;
        private int productCount;

        public decimal CalculateTotalPrice()
        {
            return price;
        }

        public bool HasDiscount()
        {
            return price > 100;
        }

        public void Add(int aPrice)
        {
            price += aPrice;
            productCount++;
        }

        public int NumberOfProducts()
        {
            return productCount;
        }
    }
}