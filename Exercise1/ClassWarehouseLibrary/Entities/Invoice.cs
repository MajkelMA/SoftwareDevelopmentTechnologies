using System;
using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public Client WarehouseClient { get; set; }
        public Status Status { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Invoice invoice &&
                   Id.Equals(invoice.Id) &&
                   EqualityComparer<Client>.Default.Equals(WarehouseClient, invoice.WarehouseClient) &&
                   EqualityComparer<Status>.Default.Equals(Status, invoice.Status);
        }
    }
}
