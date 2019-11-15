using System;
using System.Runtime.Serialization;

namespace ClassWarehouseLibrary
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
        [DataMember]
        public String Email { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   Id.Equals(client.Id) &&
                   Name == client.Name &&
                   LastName == client.LastName &&
                   Birthday == client.Birthday;
        }

        public override string ToString()
        {
            return "Client " + "Id: " + Id + " Name: " + Name + " LastName: " + LastName + " Birthday: " + Birthday.ToString() + " Email: " + Email;
        }
    }
}
