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
    }
}
