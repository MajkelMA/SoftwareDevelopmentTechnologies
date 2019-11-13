﻿namespace ClassWarehouseLibrary.Entities
{
    public class PackageStatus : Status
    {
        public PackageStatus(Product product, float nettoPrice, float tax, int amount) : base(product, nettoPrice, tax)
        {
            Amount = amount;
        }

        public override bool Equals(object obj)
        {
            return obj is PackageStatus status &&
                         base.Equals(obj) &&
                         Amount == status.Amount;
        }
    }
}
