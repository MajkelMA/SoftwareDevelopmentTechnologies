using Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ClassWarehouseLibrary.Entities
{
    [DataContract]
    [KnownType(typeof(BuyEvent))]
    [KnownType(typeof(DestroyEvent))]
    [KnownType(typeof(SellEvent))]
    public abstract class Event : IOwnFormatter
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Client WarehouseClient { get; set; }
        [DataMember]
        public EventStatus Status { get; set; }
        [DataMember]
        public String Description { get; set; }

        protected Event()
        {

        }

        protected Event(Guid id, Client warehouseClient, EventStatus status, string description)
        {
            this.Id = id;
            WarehouseClient = warehouseClient;
            Status = status;
            Description = description;
        }

        public override string ToString()
        {
            return "Event" + " Id: " + Id + " Client: " + WarehouseClient + " Status: " + Status + " Description: " + Description;
        }

        public abstract string Serialize(ObjectIDGenerator idGenerator);

        public abstract void Deserialize(string[] details, Dictionary<long, Object> objReferences);
    }
}
