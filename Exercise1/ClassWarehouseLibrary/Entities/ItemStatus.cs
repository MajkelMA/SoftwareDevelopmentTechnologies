using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarehouseLibrary.Entities
{
    public class ItemStatus : ClassWarehouseLibrary.Status
    {
        public int Amount { get; set; }

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
            var hashCode = 1233020415;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            return hashCode;
        }
    }
}
