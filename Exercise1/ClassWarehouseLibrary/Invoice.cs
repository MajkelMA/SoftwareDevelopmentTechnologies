using System.Collections.Generic;
using System.Linq;

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

        public override bool Equals(object obj)
        {
            return obj is Invoice invoice &&
                   EqualityComparer<Client>.Default.Equals(WarehouseClient, invoice.WarehouseClient) &&
                   Products.SequenceEqual(invoice.Products);
        }

        public override int GetHashCode()
        {
            var hashCode = 634928472;
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(WarehouseClient);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Product>>.Default.GetHashCode(Products);
            return hashCode;
        }
    }
}
