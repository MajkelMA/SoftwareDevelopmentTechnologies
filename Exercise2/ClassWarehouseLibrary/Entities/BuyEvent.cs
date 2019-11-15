using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ClassWarehouseLibrary.Entities
{
    [DataContract]
    public class BuyEvent : Event
    {
        public BuyEvent()
        {

        }

        public BuyEvent(Guid id, Client warehouseClient, Status status, string description) : base(id, warehouseClient, status, description)
        {

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString() + " - BuyEvent";
        }
    }
}
