using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Collections.Specialized;
using ClassWarehouseLibrary.Entities;

namespace ClassWarehouseLibrary
{
    public class DataRepository : IDataRepository
    {
        private DataContext _dataContext;
        private IAutoFiller _autoFilling;

        public event EventHandler EventAdded;
        public event EventHandler EventDeleted;

        public DataRepository(IAutoFiller autoFilling)
        {
            _dataContext = new DataContext();
            _autoFilling = autoFilling;
            _autoFilling.AutoFill(_dataContext);
            _dataContext.Events.CollectionChanged += EventsContexChanged;
        }

        private void EventsContexChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                EventAdded?.Invoke(this, new EventArgs());
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                EventDeleted?.Invoke(this, new EventArgs());
            }
        }


        #region client
        public void AddClient(Client client)
        {
            foreach (Client clientInList in _dataContext.Clients)
            {
                if (clientInList.Id == client.Id || clientInList.Email == client.Email)
                {
                    throw new ArgumentException("such client already exists");
                }
            }

            _dataContext.Clients.Add(client);
        }

        public void DeleteClient(Client clientToDelete)
        {
            if (!_dataContext.Clients.Remove(clientToDelete))
            {
                throw new ArgumentException("such client does not exist");
            }
        }


        public List<Client> GetAllClients()
        {
            return _dataContext.Clients;
        }

        public Client GetClient(Guid id)
        {
            foreach (Client clientToFind in _dataContext.Clients)
            {
                if (clientToFind.Id == id)
                {
                    return clientToFind;
                }
            }
            return null;
        }

        public Client GetClient(String email)
        {
            foreach (Client clientToFind in _dataContext.Clients)
            {
                if (clientToFind.Email == email)
                {
                    return clientToFind;
                }
            }
            return null;
        }

        public void UpdateClient(Client newCLientInfo)
        {
            bool findFlag = false;
            bool noneUniqueEmailFlag = false;

            foreach (Client client in _dataContext.Clients)
            {
                if (newCLientInfo.Id != client.Id)
                {
                    if (client.Email == newCLientInfo.Email)
                    {
                        noneUniqueEmailFlag = true;
                    }
                }
            }

            foreach (Client clientToUpdate in _dataContext.Clients)
            {
                if (newCLientInfo.Id == clientToUpdate.Id)
                {
                    clientToUpdate.Name = newCLientInfo.Name;
                    clientToUpdate.LastName = newCLientInfo.LastName;
                    clientToUpdate.Birthday = newCLientInfo.Birthday;
                    clientToUpdate.Email = newCLientInfo.Email;
                    findFlag = true;
                }
            }
            if (!findFlag)
            {
                throw new ArgumentException("such client does not exist");
            }

            if (noneUniqueEmailFlag)
            {
                throw new ArgumentException("none unique Email");
            }
        }

        #endregion

        #region status
        public void AddStatus(Status status)
        {
            foreach (Status statusInList in _dataContext.Statuses)
            {
                if (statusInList.Id == status.Id || statusInList.Product.Equals(status.Product))
                {
                    throw new ArgumentException("such status already exists");
                }
            }
            _dataContext.Statuses.Add(status);
        }

        public void DeleteStatus(Status status)
        {
            if (!_dataContext.Statuses.Remove(status))
            {
                throw new ArgumentException("such status does not exist");
            }
        }

        public List<Status> GetAllStatuses()
        {
            return _dataContext.Statuses;
        }

        public Status GetStatus(Guid id)
        {
            foreach (Status statusToFind in _dataContext.Statuses)
            {
                if (statusToFind.Id == id)
                {
                    return statusToFind;
                }
            }
            return null;
        }

        public void UpdateStatus(Status newStatusInfo)
        {
            bool changeFlag = false;
            bool noneUniqueProductFlag = false;

            foreach (Status status in _dataContext.Statuses)
            {
                if (newStatusInfo.Id != status.Id)
                {
                    if (newStatusInfo.Product.Equals(status.Product))
                    {
                        noneUniqueProductFlag = true;
                    }
                }
            }

            foreach (Status statusToUpdate in _dataContext.Statuses)
            {
                if (newStatusInfo.Id == statusToUpdate.Id)
                {
                    statusToUpdate.NettoPrice = newStatusInfo.NettoPrice;
                    statusToUpdate.Tax = newStatusInfo.Tax;
                    statusToUpdate.Product = newStatusInfo.Product;
                    statusToUpdate.Amount = newStatusInfo.Amount;
                    changeFlag = true;
                }
            }

            if (!changeFlag)
            {
                throw new ArgumentException("such status dosn't exist");
            }

            if (noneUniqueProductFlag) {
                throw new ArgumentException("Product in Status is not unique");
            }
        }

        #endregion

        #region ProductRegion
        public void AddProduct(Product product)
        {
            _dataContext.Products.Add(product.Id, product);
        }

        public void DeleteProduct(Guid key)
        {
            if (!_dataContext.Products.Remove(key))
            {
                throw new ArgumentException("such product does not exist");
            }
        }

        public void DeleteProduct(Product product)
        {
            if (!_dataContext.Products.Remove(product.Id))
            {
                throw new ArgumentException("such product does not exist");
            }
        }

        public void UpdateProduct(Product product)
        {
            if (!_dataContext.Products.ContainsKey(product.Id))
            {
                throw new ArgumentException("such product does not extist");
            }

            foreach (KeyValuePair<Guid, Product> item in _dataContext.Products)
            {
                if (item.Key == product.Id)
                {
                    item.Value.Description = product.Description;
                    item.Value.Name = product.Name;
                }
            }
        }

        public Dictionary<Guid, Product> GetAllProducts()
        {
            return _dataContext.Products;
        }

        public Product GetProduct(Guid key)
        {
            return _dataContext.Products[key];
        }
        #endregion

        #region EventRegion
        public void AddEvent(Event eventToAdd)
        {
            foreach (Event item in _dataContext.Events)
            {
                if (item.Id == eventToAdd.Id)
                {
                    throw new ArgumentException("such event already exists");
                }
            }
            _dataContext.Events.Add(eventToAdd);
        }

        public void DeleteEvent(Event eventToDelete)
        {
            if (!_dataContext.Events.Remove(eventToDelete))
            {
                throw new ArgumentException("such event does not exist");
            }
        }

        public ObservableCollection<Event> GetAllEvents()
        {
            return _dataContext.Events;
        }

        public Event GetEvent(Guid id)
        {
            foreach (Event item in _dataContext.Events)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void UpdateEvent(Event eventToUpdate)
        {
            if (!_dataContext.Events.Contains(eventToUpdate))
            {
                throw new ArgumentException("such event does not exist");
            }

            foreach (Event item in _dataContext.Events)
            {
                if (item.Id == eventToUpdate.Id)
                {
                    item.Status = eventToUpdate.Status;
                    item.WarehouseClient = eventToUpdate.WarehouseClient;
                    item.Description = eventToUpdate.Description;
                }
            }
        }
        #endregion
    }
}
