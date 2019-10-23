namespace ClassWarehouseLibrary
{
    public class InventoryStatus
    {
        public static long NextId = 0;
        public long Id { get; }
        public Product WarehouseProduct { get; set; }
        public int State { get; set; }
        public float NettoPrice { get; set; }
        public float Tax { get; set; }

        public InventoryStatus(Product product, int state, float nettoPrice, float tax)
        {
            Id = NextId;
            NextId++;
            WarehouseProduct = product;
            State = state;
            NettoPrice = nettoPrice;
            Tax = tax;
        }
    }
}
