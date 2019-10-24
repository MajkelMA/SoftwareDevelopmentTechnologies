using System;
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

        void AddProduct(Product product);

        Product GetProduct(Guid key);

        Product GetProduct(Product product);

        Dictionary<Guid, Product> GetAllProducts();

        void DeleteProduct(Guid key);

        void DeleteProduct(Product product);

        void UpdateProduct(Product product);

        void AddInventoryStatus(Status inventoryStatus);

        Status GetInventoryStatus(int id);

        List<Status> GetAllInventoryStatuses();

        void DeleteInventoryStatus(Status inventoryStatus);

        void UpdateInventoryStatus(int id, Status newInventoryStatusInfo);

        void AddInvoice(Invoice invoice);

        Invoice GetInvoice(Guid id);

        Invoice GetInvoice(Invoice invoice);

        ObservableCollection<Invoice> GetAllInvoices();

        void DeleteInvoice(Invoice invoice);

        void UpdateInvoice(Invoice invoice);
    }
}
