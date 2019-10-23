using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassWarehouseLibrary
{
    class DataService
    {
        private IDataRepository _dataRepository;

        //Product
        Dictionary<int, Product> GetAllProducts()
        {
            return _dataRepository.GetAllProducts();
        }

        //Clients
        List<Client> GetAllClients()
        {
            return _dataRepository.GetAllClients();
        }

        //Invoices
        ObservableCollection<Invoice> GetAllInvoices()
        {
            return _dataRepository.GetAllInvoices();
        }

        //InventoryStatuses
        List<InventoryStatus> GetInventoryStatuses()
        {
            return _dataRepository.GetAllInventoryStatuses();
        }


    }
}
