using Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ClassWarehouseLibrary
{
    [DataContract]
    public class Product : IOwnSerialization
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String Description { get; set; }

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

        #region "Overrides"
        public override string ToString()
        {
            return "Product " + "Id: " + Id + " Name: " + Name + " Description: " + Description;
        }
        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Id.Equals(product.Id) &&
                   Name.Equals(product.Name) &&
                   Description.Equals(product.Description);
        }
        #endregion
    }
}
