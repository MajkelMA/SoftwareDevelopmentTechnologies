﻿using System;
using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    public abstract class Status
    {
        public Guid Id { get; set; }
        public Product WarehouseProduct { get; set; }
        public float NettoPrice { get; set; }
        public float Tax { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Status status &&
                   Id.Equals(status.Id) &&
                   EqualityComparer<Product>.Default.Equals(WarehouseProduct, status.WarehouseProduct) &&
                   NettoPrice == status.NettoPrice &&
                   Tax == status.Tax;
        }

        public override int GetHashCode()
        {
            var hashCode = 1746626795;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Product>.Default.GetHashCode(WarehouseProduct);
            hashCode = hashCode * -1521134295 + NettoPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + Tax.GetHashCode();
            return hashCode;
        }
        
       
    }
}
