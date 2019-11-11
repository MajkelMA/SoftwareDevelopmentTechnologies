using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarehouseLibrary.Entities
{
    public class BuyEvent : Event
    {
        public BuyEvent(Guid id, Client warehouseClient, Status status, string description) : base(id, warehouseClient, status, description)
        {

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
