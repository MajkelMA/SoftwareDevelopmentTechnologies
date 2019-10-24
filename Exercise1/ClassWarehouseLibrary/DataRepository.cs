using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using ClassWarehouseLibrary.Entities;

namespace ClassWarehouseLibrary
{
    public class DataRepository : IDataRepository
    {
        private DataContext _dataContext;
        private IAutoFiller _autoFilling;

        public DataRepository(IAutoFiller autoFilling)
        {
            _dataContext = new DataContext();
            _autoFilling = autoFilling;
            _autoFilling.AutoFill(_dataContext);
        }

        public void AddClient(Client client)
        {
           foreach(Client clientInList in _dataContext.Clients)
            {
                if(clientInList.Id == client.Id)
                {
                    throw new ArgumentException();
                }
            }

            _dataContext.Clients.Add(client);
        }

        public void AddStatus(Status status)
        {
            foreach(Status statusInList in _dataContext.Statuses)
            {
                if(statusInList.Id == status.Id)
                {
                    throw new ArgumentException();
                }
            }
            _dataContext.Statuses.Add(status);
        }

        public void AddInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product, int key)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(Client clientToDelete)
        {
            if (!_dataContext.Clients.Remove(clientToDelete))
            {
                throw new ArgumentException();
            }
        }

        public void DeleteStatus(Status status)
        {
            if (!_dataContext.Statuses.Remove(status))
            {
                throw new ArgumentException();
            }
        }

        public void DeleteInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int key)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAllClients()
        {
            return _dataContext.Clients;
        }

        public List<Status> GetAllStatuses()
        {
            return _dataContext.Statuses;
        }

        public ObservableCollection<Invoice> GetAllInvoices()
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Client GetClient(Guid id)
        {
           foreach(Client clientToFind in _dataContext.Clients)
            {
                if(clientToFind.Id == id)
                {
                    return clientToFind;
                }
            }
            throw new ArgumentException();
        }

        public Status GetStatus(Guid id)
        {
            foreach (Status statusToFind in _dataContext.Statuses)
            {
                if(statusToFind.Id == id)
                {
                    return statusToFind;
                }
            }
            throw new ArgumentException();
        }

        public Invoice GetInvoice(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int key)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Guid id, Client newCLientInfo)
        {
            bool findFlag = false;
            foreach(Client clientToUpdate in _dataContext.Clients)
            {
                if(id == clientToUpdate.Id)
                {
                    clientToUpdate.Name = newCLientInfo.Name;
                    clientToUpdate.Lastname = newCLientInfo.Lastname;
                    clientToUpdate.Birthday = newCLientInfo.Birthday;
                    findFlag = true;
                }
            }
            if (!findFlag)
            {
                throw new ArgumentException();
            }
        }

        public void UpdateStatus(Guid id, Status newStatusInfo)
        {
            bool changeFlag = false;
            foreach(Status statusToUpdate in _dataContext.Statuses)
            {
                if(statusToUpdate.Id == id)
                {
                    statusToUpdate.NettoPrice = newStatusInfo.NettoPrice;
                    statusToUpdate.Tax = newStatusInfo.Tax;
                    statusToUpdate.WarehouseProduct = newStatusInfo.WarehouseProduct;
                    if (statusToUpdate is ItemStatus && newStatusInfo is ItemStatus)
                    {
                        ItemStatus castStatusToUpdate = (ItemStatus)statusToUpdate;
                        ItemStatus castNewStatusInfo = (ItemStatus)newStatusInfo;
                        castStatusToUpdate.Amount = castNewStatusInfo.Amount;
                        changeFlag = true;
                    }

                    if(newStatusInfo.GetType() == typeof(WeightStatus))
                    {
                        WeightStatus castStatusToUpdate = (WeightStatus)statusToUpdate;
                        WeightStatus castNewStatusInfo = (WeightStatus)newStatusInfo;
                        castStatusToUpdate.Mass = castNewStatusInfo.Mass;
                        changeFlag = true;
                    }
                }
            }

            if (!changeFlag)
            {
                throw new ArgumentException();
            }
        }

        public void UpdateInvoice(int id, Invoice newInvoiceInfo)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int key, Product newproductInfo)
        {
            throw new NotImplementedException();
        }
    }
}
