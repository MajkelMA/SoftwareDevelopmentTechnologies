using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ClassWarehouseLibrary.Entities
{
    [DataContract]
    public class PackageStatus : Status
    {
        public PackageStatus()
        {

        }

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

        public override string ToString()
        {
            return base.ToString() + " - PackageStatus";
        }
    }
}
