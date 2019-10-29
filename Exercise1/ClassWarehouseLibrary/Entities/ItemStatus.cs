namespace ClassWarehouseLibrary.Entities
{
    public class ItemStatus : ClassWarehouseLibrary.Status
    {
        

        public ItemStatus(Product product, float nettoPrice, float tax, int amount) : base(product, nettoPrice, tax)
        {
            Amount = amount;
        }

        public override bool Equals(object obj)
        {
            return obj is ItemStatus status &&
                   base.Equals(obj) &&
                   Amount == status.Amount;
        }

        public override int GetHashCode()
        {
            int hashCode = 1233020415;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            return hashCode;
        }
    }
}
