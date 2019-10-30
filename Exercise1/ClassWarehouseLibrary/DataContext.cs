using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassWarehouseLibrary
{
    public class DataContext
    {
        public List<Client> Clients { get; }
        public Dictionary<Guid, Product> Products { get; }
        public ObservableCollection<Invoice> Invoices { get; }
        public List<Status> Statuses { get; }
        public DataContext()
        {
            Clients = new List<Client>();
            Products = new Dictionary<Guid, Product>();
            Invoices = new ObservableCollection<Invoice>();
            Statuses = new List<Status>();
        }
    }
}
