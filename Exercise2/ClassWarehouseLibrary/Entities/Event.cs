using System;
using System.Collections.Generic;

namespace ClassWarehouseLibrary.Entities
{
    public abstract class Event
    {

        public Guid Id { get; set; }
        public Client WarehouseClient { get; set; }
        public Status Status { get; set; }
        public String Description { get; set; }

        protected Event(Guid id, Client warehouseClient, Status status, string description)
        {
            this.Id = id;
            WarehouseClient = warehouseClient;
            Status = status;
            Description = description;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id.Equals(@event.Id) &&
                   EqualityComparer<Client>.Default.Equals(WarehouseClient, @event.WarehouseClient) &&
                   EqualityComparer<Status>.Default.Equals(Status, @event.Status) &&
                   Description == @event.Description;
        }
    }
}
