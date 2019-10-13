namespace ClassWarehouseLibrary
{
    public class InventoryStatus
    {
        public Product _Product { get; set; }
        public int State { get; set; }
        public float NettoPrice { get; set; }
        public float Tax { get; set; }

        public InventoryStatus(Product product, int state, float nettoPrice, float tax)
        {
            _Product = product;
            State = state;
            NettoPrice = nettoPrice;
            Tax = tax;
        }
    }
}
