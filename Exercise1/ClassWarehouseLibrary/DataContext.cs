using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassWarehouseLibrary
{
    class DataContext
    {
        public List<Client> Clients { get; set; }
        public Dictionary<int, Product> Products { get; set; }
        public ObservableCollection<Invoice> Invoices { get; set; }
        public List<InventoryStatus> InventoryStatuses { get; set; }
        public DataContext()
        {
            Clients = new List<Client>();
            Products = new Dictionary<int, Product>();
            Invoices = new ObservableCollection<Invoice>();
            InventoryStatuses = new List<InventoryStatus>();
        }
    }
}
