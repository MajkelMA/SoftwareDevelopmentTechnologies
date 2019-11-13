using System;

namespace ClassWarehouseLibrary
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }

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
