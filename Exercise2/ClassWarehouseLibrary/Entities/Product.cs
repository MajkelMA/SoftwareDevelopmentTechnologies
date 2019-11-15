using System;
using System.Runtime.Serialization;

namespace ClassWarehouseLibrary
{
    [DataContract]
    public class Product
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

        //public XmlSchema GetSchema()
        //{
        //    return null;
        //}

        //public void ReadXml(XmlReader reader)
        //{
        //    throw new NotImplementedException();
        //}

        //public void WriteXml(XmlWriter writer)
        //{
        //    //writer.WriteStartElement("Product");
        //    writer.WriteStartElement("Id");
        //    writer.WriteString(Id.ToString());
        //    writer.WriteEndElement();
        //    writer.WriteStartElement("Name");
        //    writer.WriteString(Name);
        //    writer.WriteEndElement();
        //    writer.WriteStartElement("Description");
        //    writer.WriteString(Description);
        //    writer.WriteEndElement();
        //    //writer.WriteEndElement();
        //}
    }
}
