using ClassWarehouseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ClassWarehouseLibrary
{
    [DataContract]
    [KnownType(typeof(ItemStatus))]
    [KnownType(typeof(PackageStatus))]
    public abstract class Status
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Product Product { get; set; }
        [DataMember]
        public float NettoPrice { get; set; }
        [DataMember]
        public float Tax { get; set; }
        [DataMember]
        public int Amount { get; set; }

        public Status()
        {

        }

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

        public override string ToString()
        {
            return "Status " + "Id: " + Id + " Product: " + Product.ToString() + " NettoPrice: " + NettoPrice + " Tax: " + Tax + " Amount: " + Amount;
        }
    }
}