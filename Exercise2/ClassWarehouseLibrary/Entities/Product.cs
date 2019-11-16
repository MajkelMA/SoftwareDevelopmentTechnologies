using Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ClassWarehouseLibrary
{
    [DataContract]
    public class Product : IOwnFormatter
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String Description { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Id.Equals(product.Id) &&
                   Name == product.Name &&
                   Description == product.Description;
        }

        public override string ToString()
        {
            return "Product " + "Id: " + Id + " Name: " + Name + " Description: " + Description;
        }

        public string Serialize(ObjectIDGenerator idGenerator)
        {
            return this.GetType().FullName + "|"
                   + idGenerator.GetId(this, out bool firstTime) + "|"
                   + Id + "|" + Name + "|" + Description + "\n";
        }

        public void Deserialize(string[] details, Dictionary<long, Object> objReferences)
        {
            this.Id = Guid.Parse(details[2]);
            this.Name = details[3];
            this.Description = details[4];
        }
    }
}
