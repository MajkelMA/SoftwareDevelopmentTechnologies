using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassWarehouseLibrary
{
    public class DataContext
    {
        public List<Client> Clients { get; set; }
        public Dictionary<int, Product> Products { get; set; }
        public ObservableCollection<Invoice> Invoices { get; set; }
        public List<Status> Statuses { get; set; }
        public DataContext()
        {
            Clients = new List<Client>();
            Products = new Dictionary<int, Product>();
            Invoices = new ObservableCollection<Invoice>();
            Statuses = new List<Status>();
        }
    }
}
