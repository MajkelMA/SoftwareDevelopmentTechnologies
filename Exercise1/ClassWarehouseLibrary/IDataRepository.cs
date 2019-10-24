using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace ClassWarehouseLibrary
{
    interface IDataRepository
    {
        void AddClient(Client client);

        Client GetClient(Guid id);

        List<Client> GetAllClients();

        void UpdateClient(Guid id, Client newClientInfo);

        void DeleteClient(Client clientToDelete);

        void AddProduct(Product product, int key);

        Product GetProduct(int key);

        Dictionary<int, Product> GetAllProducts();

        void DeleteProduct(int key);

        void UpdateProduct(int key, Product newproductInfo);

        void AddStatus(Status Status);

        Status GetStatus(Guid id);

        List<Status> GetAllStatuses();

        void DeleteStatus(Status Status);

        void UpdateStatus(Guid id, Status newStatusInfo);

        void AddInvoice(Invoice invoice);

        Invoice GetInvoice(int id);

        ObservableCollection<Invoice> GetAllInvoices();

        void DeleteInvoice(Invoice invoice);

        void UpdateInvoice(int id, Invoice newInvoiceInfo);
    }
}
