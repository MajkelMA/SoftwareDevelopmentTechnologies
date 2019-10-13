using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    public class Invoice
    {
        public Client WarehouseClient { get; set; }
        public List<Product> Produscts { get; set; }

        public Invoice(Client warehouseClient, List<Product> products)
        {
            WarehouseClient = warehouseClient;
            Produscts = products;
        }
    }
}
