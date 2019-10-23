using System;

namespace ClassWarehouseLibrary
{
    public class Client
    {
        public String Name { get; set; }
        public String Lastname { get; set; }
        public DateTime Birthday { get; set; }

        public Client(string name, string lastname, DateTime birthday)
        {
            Name = name;
            Lastname = lastname;
            Birthday = birthday;
        }
    }
}
