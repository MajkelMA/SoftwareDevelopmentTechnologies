using System;

namespace ClassWarehouseLibrary.Entities
{
    public class SellEvent : Event
    {
        public SellEvent(Guid id, Client warehouseClient, Status status, string descripbion) : base(id, warehouseClient, status, descripbion )
        {
                
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
