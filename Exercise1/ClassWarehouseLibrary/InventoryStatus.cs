namespace ClassWarehouseLibrary
{
    public class InventoryStatus
    {
        public Product Product { get; set; }
        public int State { get; set; }
        public float NettoPrice { get; set; }
        public float Tax { get; set; }

        public InventoryStatus(Product product, int state, float nettoPrice, float tax)
        {
            Product = product;
            State = state;
            NettoPrice = nettoPrice;
            Tax = tax;
        }
    }
}
