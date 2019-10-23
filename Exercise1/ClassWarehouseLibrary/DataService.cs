using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassWarehouseLibrary
{
    class DataService
    {
        private IDataRepository _dataRepository;

        Dictionary<int, Product> GetAllProducts()
        {
            return _dataRepository.GetAllProducts();
        }

        List<Client> GetAllClients()
        {
            return _dataRepository.GetAllClients();
        }

        ObservableCollection<Invoice> GetAllInvoices()
        {
            return _dataRepository.GetAllInvoices();
        }

        List<InventoryStatus> GetInventoryStatuses()
        {
            return _dataRepository.GetAllInventoryStatuses();
        }

        List<Product> GetClientProducts(Client client)
        {
            ObservableCollection<Invoice> invoices = _dataRepository.GetAllInvoices();
            List<Product> products = new List<Product>();
            foreach(Invoice item in invoices)
            {
                if(item.WarehouseClient.Equals(client))
                {
                    products.AddRange(item.Products);
                }
            }
            return products;
        }
    }
}
