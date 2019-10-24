using System;
using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public Client WarehouseClient { get; set; }
        public Status status { get; set; }

        public override bool Equals(object obj)
        {
            var invoice = obj as Invoice;
            return invoice != null &&
                   Id.Equals(invoice.Id) &&
                   EqualityComparer<Client>.Default.Equals(WarehouseClient, invoice.WarehouseClient) &&
                   EqualityComparer<Status>.Default.Equals(status, invoice.status);
        }

        public override int GetHashCode()
        {
            var hashCode = -83349094;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(WarehouseClient);
            hashCode = hashCode * -1521134295 + EqualityComparer<Status>.Default.GetHashCode(status);
            return hashCode;
        }
    }
}
