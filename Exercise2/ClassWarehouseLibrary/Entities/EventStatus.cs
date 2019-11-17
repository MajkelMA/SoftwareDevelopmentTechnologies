﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarehouseLibrary
{
    [DataContract]
    public class EventStatus
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

        public EventStatus() { }

        public EventStatus(Product product, float nettoPrice, float tax, int amount)
        {
            Id = Guid.NewGuid();
            NettoPrice = nettoPrice;
            Tax = tax;
            Product = product;
            Amount = amount;
        }

        public string Serialize(ObjectIDGenerator idGenerator)
        {
            return this.GetType().FullName + "|"
                   + idGenerator.GetId(this, out bool firstTime) + "|"
                   + Id + "|" + NettoPrice + "|" + Tax + "|" + Amount + "|"
                   + idGenerator.GetId(Product, out firstTime) + "\n";
        }

        public void Deserialize(string[] details, Dictionary<long, object> objReferences)
        {
            Id = Guid.Parse(details[2]);
            NettoPrice = float.Parse(details[3]);
            Tax = float.Parse(details[4]);
            Amount = Int32.Parse(details[5]);
            Product = (Product)objReferences[Int64.Parse(details[6])];
        }

        #region "Overrides"
        public override string ToString()
        {
            return "EventStatus " + "Id: " + Id + " Product: " + Product.ToString() + " NettoPrice: " + NettoPrice + " Tax: " + Tax + " Amount: " + Amount;
        }

        public override bool Equals(object obj)
        {
            return obj is EventStatus status &&
                   Id.Equals(status.Id) &&
                   Product.Equals(status.Product) &&
                   NettoPrice.Equals(status.NettoPrice) &&
                   Tax.Equals(status.Tax);
        }
        #endregion
    }
}
