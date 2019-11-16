using ClassWarehouseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace ClassWarehouseLibrary
{
    [DataContract]
    [KnownType(typeof(Product))]
    [KnownType(typeof(Client))]
    [KnownType(typeof(Event))]
    [KnownType(typeof(Status))]
    public class DataContext
    {
        [DataMember]
        public Dictionary<Guid, Product> Products { get; set; }
        [DataMember]
        public List<Client> Clients { get; set; }
        [DataMember]
        public ObservableCollection<Event> Events { get; set; }
        [DataMember]
        public List<Status> Statuses { get; set; }

        public DataContext()
        {
            Clients = new List<Client>();
            Products = new Dictionary<Guid, Product>();
            Events = new ObservableCollection<Event>();
            Statuses = new List<Status>();
        }

        public override string ToString()
        {
            string result = "Products \n";
            foreach (KeyValuePair<Guid, Product> item in Products)
            {
                result += item.Value.ToString() + "\n";
            }
            result += "Clients \n";
            foreach (Client item in Clients)
            {
                result += item.ToString() + "\n";
            }
            result += "Events \n";
            foreach (Event item in Events)
            {
                result += item.ToString() + "\n";
            }
            result += "Statuses \n";
            foreach (Status item in Statuses)
            {
                result += item.ToString() + "\n";
            }

            return result;
        }
    }
}
