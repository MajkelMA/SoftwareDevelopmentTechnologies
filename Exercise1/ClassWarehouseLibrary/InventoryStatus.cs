using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    public class InventoryStatus
    {
        public Product WarehouseProduct { get; set; }
        public int State { get; set; }
        public float NettoPrice { get; set; }
        public float Tax { get; set; }

        public InventoryStatus(Product product, int state, float nettoPrice, float tax)
        {
            WarehouseProduct = product;
            State = state;
            NettoPrice = nettoPrice;
            Tax = tax;
        }

        public override bool Equals(object obj)
        {
            return obj is InventoryStatus status &&
                   EqualityComparer<Product>.Default.Equals(WarehouseProduct, status.WarehouseProduct) &&
                   State == status.State &&
                   NettoPrice == status.NettoPrice &&
                   Tax == status.Tax;
        }

        public override int GetHashCode()
        {
            var hashCode = -687840871;
            hashCode = hashCode * -1521134295 + EqualityComparer<Product>.Default.GetHashCode(WarehouseProduct);
            hashCode = hashCode * -1521134295 + State.GetHashCode();
            hashCode = hashCode * -1521134295 + NettoPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + Tax.GetHashCode();
            return hashCode;
        }
    }
}
