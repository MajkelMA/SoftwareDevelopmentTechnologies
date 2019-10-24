using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassWarehouseLibrary
{
    interface IDataRepository
    {
        #region clientCRUD
        void AddClient(Client client);

        Client GetClient(Guid id);

        List<Client> GetAllClients();

        void UpdateClient(Guid id, Client newClientInfo);

        void DeleteClient(Client clientToDelete);
        #endregion

        #region productCRUD
        void AddProduct(Product product);

        Product GetProduct(Guid key);

        Product GetProduct(Product product);

        Dictionary<Guid, Product> GetAllProducts();

        void DeleteProduct(Guid key);

        void DeleteProduct(Product product);

        void UpdateProduct(Product product);

        #endregion

        #region statusCRUD
        void AddStatus(Status Status);

        Status GetStatus(Guid id);

        List<Status> GetAllStatuses();

        void DeleteStatus(Status Status);

        void UpdateStatus(Guid id, Status newStatusInfo);

        #endregion

        #region invoiceCRUD
        void AddInvoice(Invoice invoice);

        Invoice GetInvoice(Guid id);

        Invoice GetInvoice(Invoice invoice);

        ObservableCollection<Invoice> GetAllInvoices();

        void DeleteInvoice(Invoice invoice);

        void UpdateInvoice(Invoice invoice);
        #endregion
    }
}
