using System;
using System.Collections.Generic;

namespace ClassWarehouseLibrary.Entities
{
    public abstract class Event
    {
        public Invoice Invoice { get; set; }
        public String Description { get; set; }
        
        public Event(Invoice invoice, String description)
        {
            this.Invoice = invoice;
            this.Description = description;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   EqualityComparer<Invoice>.Default.Equals(Invoice, @event.Invoice) &&
                   Description == @event.Description;
        }
    }
}
