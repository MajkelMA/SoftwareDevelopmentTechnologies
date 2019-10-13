using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarehouseLibrary
{
    class Client
    {
        public String Name { get; set; }
        public String Lastname { get; set; }
        public DateTime Birthdey { get; set; }
        public long Id { get; }

        public Client(string name, string lastname, DateTime birthdey, long id)
        {
            Name = name;
            Lastname = lastname;
            Birthdey = birthdey;
            Id = id;
        }
    }
}
