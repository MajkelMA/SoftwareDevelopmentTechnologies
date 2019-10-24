using System;
using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    public class Client
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Lastname { get; set; }
        public DateTime Birthday { get; set; }

        public override bool Equals(object obj)
        {
            var client = obj as Client;
            return client != null &&
                   Id.Equals(client.Id) &&
                   Name == client.Name &&
                   Lastname == client.Lastname &&
                   Birthday == client.Birthday;
        }

        public override int GetHashCode()
        {
            var hashCode = -1813795500;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Lastname);
            hashCode = hashCode * -1521134295 + Birthday.GetHashCode();
            return hashCode;
        }
    }
}
