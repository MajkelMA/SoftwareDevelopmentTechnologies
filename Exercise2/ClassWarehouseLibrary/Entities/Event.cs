using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ClassWarehouseLibrary.Entities
{
    [DataContract]
    [KnownType(typeof(BuyEvent))]
    [KnownType(typeof(DestroyEvent))]
    [KnownType(typeof(SellEvent))]
    public abstract class Event
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Client WarehouseClient { get; set; }
        [DataMember]
        public Status Status { get; set; }
        [DataMember]
        public String Description { get; set; }

        protected Event()
        {

        }

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

        public override string ToString()
        {
            return "Event" + " Id: " + Id + " Client: " + WarehouseClient + " Status: " + Status + " Description: " + Description;
        }
    }
}
