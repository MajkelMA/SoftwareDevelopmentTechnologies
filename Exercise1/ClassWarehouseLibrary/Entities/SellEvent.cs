using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarehouseLibrary.Entities
{
    public class SellEvent : Event
    {
        public SellEvent(Invoice invoice, string description) : base(invoice, description)
        {

        }
    }
}
