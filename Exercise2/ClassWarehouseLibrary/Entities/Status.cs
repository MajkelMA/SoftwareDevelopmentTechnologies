using System;
using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    public abstract class Status
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public float NettoPrice { get; set; }
        public float Tax { get; set; }
        public int Amount { get; set; }

        public Status(Product product, float nettoPrice, float tax)
        {
            Id = Guid.NewGuid();
            NettoPrice = nettoPrice;
            Tax = tax;
            Product = product;
        }

        public override bool Equals(object obj)
        {
            return obj is Status status &&
                   Id.Equals(status.Id) &&
                   EqualityComparer<Product>.Default.Equals(Product, status.Product) &&
                   NettoPrice == status.NettoPrice &&
                   Tax == status.Tax;
        }
    }
}