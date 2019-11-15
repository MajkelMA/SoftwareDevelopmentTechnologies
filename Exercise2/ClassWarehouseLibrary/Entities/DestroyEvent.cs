using System;
using System.Runtime.Serialization;

namespace ClassWarehouseLibrary.Entities
{
    [DataContract]
    public class DestroyEvent : Event
    {
        public DestroyEvent()
        {

        }

        public DestroyEvent(Guid id, Client warehouseClient, Status status, string description) : base(id, warehouseClient, status, description)
        {
            

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString() + " - DestroyEvent";
        }
    }
}
