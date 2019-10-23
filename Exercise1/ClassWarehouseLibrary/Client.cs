using System;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   Name == client.Name &&
                   Lastname == client.Lastname &&
                   Birthday == client.Birthday;
        }

        public override int GetHashCode()
        {
            var hashCode = 1802927188;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Lastname);
            hashCode = hashCode * -1521134295 + Birthday.GetHashCode();
            return hashCode;
        }
    }
}
