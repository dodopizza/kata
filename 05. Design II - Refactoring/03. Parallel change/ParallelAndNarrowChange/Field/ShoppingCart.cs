namespace ParallelAndNarrowChange.Field
{
    public class ShoppingCart
    {
        private decimal _totalPrice;
        private int _productCount;

        public decimal CalculateTotalPrice()
        {
            return _totalPrice;
        }

        public bool HasDiscount()
        {
            return _totalPrice > 100;
        }

        public void Add(int productPrice)
        {
            _totalPrice += productPrice;
            _productCount++;
        }

        public int NumberOfProducts()
        {
            return _productCount;
        }
    }
}