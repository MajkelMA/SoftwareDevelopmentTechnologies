using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarehouseLibrary
{
    public class Client
    {
        public String Name { get; set; }
        public String Lastname { get; set; }
        public DateTime Birthdey { get; set; }

        public Client(string name, string lastname, DateTime birthdey, long id)
        {
            Name = name;
            Lastname = lastname;
            Birthdey = birthdey;
            Id = id;
        }
    }
}
