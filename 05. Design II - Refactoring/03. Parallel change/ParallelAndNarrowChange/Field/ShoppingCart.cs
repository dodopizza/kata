namespace ParallelAndNarrowChange.Field
{
    public class ShoppingCart
    {
        private decimal price;

        public decimal CalculateTotalPrice()
        {
            return price;
        }

        public void AddAnother(int anotherPrice)
        {
            price += anotherPrice;
        }

        public bool HasDiscount()
        {
            return price > 100;
        }

        public int NumberOfProducts()
        {
            return 1;
        }
    }
}