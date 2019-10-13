namespace ClassWarehouseLibrary
{
    class InventoryStatus
    {
        public Product Good { get; set; }
        public int State { get; set; }
        public float NettoPrice { get; set; }
        public float Tax { get; set; }

        public InventoryStatus(Product good, int state, float nettoPrice, float tax)
        {
            Good = good;
            State = state;
            NettoPrice = nettoPrice;
            Tax = tax;
        }
    }
}
