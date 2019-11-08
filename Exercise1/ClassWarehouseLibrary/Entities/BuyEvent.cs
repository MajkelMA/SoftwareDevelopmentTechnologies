using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarehouseLibrary.Entities
{
    class BuyEvent : Event
    {
        public BuyEvent(Invoice invoice, String description) : base(invoice, description)
        {

        }
    }
}
