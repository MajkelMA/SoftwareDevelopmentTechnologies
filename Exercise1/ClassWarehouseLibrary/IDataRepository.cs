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

        Client GetClient(String email);

        List<Client> GetAllClients();

        void UpdateClient(Client newClientInfo);

        void DeleteClient(Client clientToDelete);

        #endregion

        #region productCRUD
        void AddProduct(Product product);

        Product GetProduct(Guid key);

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

        void UpdateStatus(Status newStatusInfo);

        #endregion

        #region invoiceCRUD
        void AddInvoice(Invoice invoice);

        Invoice GetInvoice(Guid id);

        ObservableCollection<Invoice> GetAllInvoices();

        void DeleteInvoice(Invoice invoice);

        void UpdateInvoice(Invoice invoice);
        #endregion
    }
}
