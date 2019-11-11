using ClassWarehouseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassWarehouseLibrary
{
    public class DataContext
    {
        public List<Client> Clients { get; }
        public Dictionary<Guid, Product> Products { get; }
        public ObservableCollection<Event> Events { get; }
        public List<Status> Statuses { get; }
        public DataContext()
        {
            Clients = new List<Client>();
            Products = new Dictionary<Guid, Product>();
            Events = new ObservableCollection<Event>();
            Statuses = new List<Status>();
        }
    }
}
