using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
