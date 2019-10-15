using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    public class Invoice
    {
        public Client WarehouseClient { get; set; }
        public List<Product> Products { get; set; }

        public Invoice(Client warehouseClient, List<Product> products)
        {
            WarehouseClient = warehouseClient;
            Products = products;
        }
    }
}
