using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    public class Invoice
    {
        public static long NextId = 0;
        public long Id { get; }
        public Client WarehouseClient { get; set; }
        public List<Product> Products { get; set; }

        public Invoice(Client warehouseClient, List<Product> products)
        {
            Id = NextId;
            NextId++;
            WarehouseClient = warehouseClient;
            Products = products;
        }
    }
}
