using System;
using System.Runtime.Serialization;

namespace ClassWarehouseLibrary.Entities
{
    [DataContract]
    public class SellEvent : Event
    {
        public SellEvent()
        {

        }

        public SellEvent(Guid id, Client warehouseClient, Status status, string descripbion) : base(id, warehouseClient, status, descripbion )
        {
                
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString() + " - SellEvent";
        }
    }
}
