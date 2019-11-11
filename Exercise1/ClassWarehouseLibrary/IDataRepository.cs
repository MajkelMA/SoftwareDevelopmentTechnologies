using ClassWarehouseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassWarehouseLibrary
{
    interface IDataRepository
    {
        event EventHandler EventAdded;
        event EventHandler EventDeleted;
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

        #region eventCRUD
        void AddEvent(Event eventToAdd);

        Event GetEvent(Guid id);

        ObservableCollection<Event> GetAllEvents();

        void DeleteEvent(Event eventToDelete);

        void UpdateEvent(Event eventToUpdate);
        #endregion
    }
}
