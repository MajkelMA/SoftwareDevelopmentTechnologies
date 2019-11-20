using Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ClassWarehouseLibrary
{
    [DataContract]
    public class Client : IOwnSerialization
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

        public string Serialize(ObjectIDGenerator idGenerator)
        {
            return this.GetType().FullName + "|"
                   + idGenerator.GetId(this, out bool firstTime) + "|" 
                   + Id + "|" + Name + "|" + LastName + "|" + Birthday.ToString() + "|" + Email + "\n";
        }

        public void Deserialize(string[] details, Dictionary<long, Object> objReferences)
        {
            Id = Guid.Parse(details[2]);
            Name = details[3];
            LastName = details[4];
            Birthday = Convert.ToDateTime(details[5]);
            Email = details[6];
        }

        #region "Overrides"
        public override string ToString()
        {
            return "Client |" + "Id: " + Id + "| Name: " + Name + "| LastName: " + LastName + "| Birthday: " + Birthday.ToString() + "| Email: " + Email;
        }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   Id.Equals(client.Id) &&
                   Name.Equals(client.Name) &&
                   LastName.Equals(client.LastName) &&
                   Birthday.Equals(client.Birthday);
        }
        #endregion
    }
}
