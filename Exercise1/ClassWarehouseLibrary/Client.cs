using System;

namespace ClassWarehouseLibrary
{
    public class Client
    {
        public static long NextId = 0;
        public long Id { get; }
        public String Name { get; set; }
        public String Lastname { get; set; }
        public DateTime Birthday { get; set; }

        public Client(string name, string lastname, DateTime birthday)
        {
            Id = NextId;
            NextId++;
            Name = name;
            Lastname = lastname;
            Birthday = birthday;
        }
    }
}
