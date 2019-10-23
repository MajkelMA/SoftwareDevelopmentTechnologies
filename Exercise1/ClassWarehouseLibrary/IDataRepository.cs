using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassWarehouseLibrary
{
    interface IDataRepository
    {
        void AddClient(Client client);
        Client GetClient(int id);
        List<Client> GetAllClients();
        void UpdateClient(Client newClientInfo, int id);
        void DeleteClient(Client clientToDelete);
        void AddProduct(Product product, int key);
        Product GetProduct(int key);
        Dictionary<int, Product> GetAllProducts();
        void DeleteProduct(int key);
        void UpdateProduct(int key, Product newproductInfo);
        void AddInventoryStatus(InventoryStatus inventoryStatus);
        InventoryStatus GetInventoryStatus(int id);
        List<InventoryStatus> GetAllInventoryStatuses();
        void DeleteInventoryStatus(InventoryStatus inventoryStatus);
        void UpdateInventoryStatus(int id, InventoryStatus newInventoryStatusInfo);
        void AddInvoice(Invoice invoice);
        Invoice GetInvoice(int id);
        ObservableCollection<Invoice> GetAllInvoices();
        void DeleteInvoice(Invoice invoice);
        void UpdateInvoice(int id, Invoice newInvoiceInfo);






    }
}
