using System;
using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    public class Client
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public DateTime Birthday { get; set; }
        public String Email { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   Id.Equals(client.Id) &&
                   Name == client.Name &&
                   LastName == client.LastName &&
                   Birthday == client.Birthday;
        }
    }
}
