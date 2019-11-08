using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarehouseLibrary.Entities
{
    class DestroyEvent : Event
    {
        public DestroyEvent(String description) : base(null, description)
        {

        }
    }
}
