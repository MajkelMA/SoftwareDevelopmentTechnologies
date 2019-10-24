using System;
using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    public class Status
    {
        public Guid Id { get; set; }
        public Product WarehouseProduct { get; set; }
        public int State { get; set; }
        public float NettoPrice { get; set; }
        public float Tax { get; set; }

        public override bool Equals(object obj)
        {
            var status = obj as Status;
            return status != null &&
                   Id.Equals(status.Id) &&
                   EqualityComparer<Product>.Default.Equals(WarehouseProduct, status.WarehouseProduct) &&
                   State == status.State &&
                   NettoPrice == status.NettoPrice &&
                   Tax == status.Tax;
        }

        public override int GetHashCode()
        {
            var hashCode = -691914087;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Product>.Default.GetHashCode(WarehouseProduct);
            hashCode = hashCode * -1521134295 + State.GetHashCode();
            hashCode = hashCode * -1521134295 + NettoPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + Tax.GetHashCode();
            return hashCode;
        }
    }
}
