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
                if(clientInList.Id == client.Id || clientInList.Email == client.Email)
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
            foreach(Invoice item in _dataContext.Invoices)
            {
                if(item.Id == invoice.Id)
                {
                    throw new ArgumentException();
                }
            }
            _dataContext.Invoices.Add(invoice);
        }

        public void AddProduct(Product product)
        {
            foreach(KeyValuePair<Guid, Product> item in _dataContext.Products)
            {
                if(item.Key == product.Id)
                {
                    throw new ArgumentException();
                }
            }
            _dataContext.Products.Add(product.Id, product);
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
            if (!_dataContext.Invoices.Remove(invoice))
            {
                throw new ArgumentException();
            }
        }

        public void DeleteProduct(Guid key)
        {
            if(!_dataContext.Products.Remove(key)){
                throw new ArgumentException();
            }
        }
        public void DeleteProduct(Product product)
        {
            if (!_dataContext.Products.Remove(product.Id))
            {
                throw new ArgumentException();
            }
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
            return _dataContext.Invoices;
        }

        public Dictionary<Guid, Product> GetAllProducts()
        {
            return _dataContext.Products;
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

        public Client GetClient(String email)
        {
            foreach(Client clientToFind in _dataContext.Clients)
            {
                if(clientToFind.Email == email)
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

        public Invoice GetInvoice(Guid id)
        {
            foreach(Invoice item in _dataContext.Invoices)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            throw new ArgumentException();
        }

        public Invoice GetInvoice(Invoice invoice)
        {
            foreach (Invoice item in _dataContext.Invoices)
            {
                if (item.Id == invoice.Id)
                {
                    return item;
                }
            }
            throw new ArgumentException();
        }

        public Product GetProduct(Guid key)
        {
            foreach(KeyValuePair<Guid, Product> item in _dataContext.Products)
            {
                if(item.Key == key)
                {
                    return item.Value;
                }
            }
            throw new ArgumentException();
        }

        public Product GetProduct(Product product)
        {
            foreach (KeyValuePair<Guid, Product> item in _dataContext.Products)
            {
                if (item.Key == product.Id)
                {
                    return item.Value;
                }
            }
            throw new ArgumentException();
        }

        public void UpdateClient(Guid id, Client newCLientInfo)
        {
            bool findFlag = false;
            foreach(Client clientToUpdate in _dataContext.Clients)
            {
                if(id == clientToUpdate.Id)
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
                throw new ArgumentException();
            }
        }

        public void UpdateClient(String email, Client newCLientInfo)
        {
            bool findFlag = false;
            foreach (Client clientToUpdate in _dataContext.Clients)
            {
                if (clientToUpdate.Email == email)
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
                    statusToUpdate.Product = newStatusInfo.Product;
                    if (statusToUpdate is ItemStatus && newStatusInfo is ItemStatus)
                    {
                        ItemStatus castStatusToUpdate = (ItemStatus)statusToUpdate;
                        ItemStatus castNewStatusInfo = (ItemStatus)newStatusInfo;
                        castStatusToUpdate.Amount = castNewStatusInfo.Amount;
                        changeFlag = true;
                    }
                }
            }

            if (!changeFlag)
            {
                throw new ArgumentException();
            }
        }

        public void UpdateInvoice(Invoice invoice)
        {
            foreach(Invoice item in _dataContext.Invoices)
            {
                if(item.Id == invoice.Id)
                {
                    item.Status = invoice.Status;
                    item.WarehouseClient = invoice.WarehouseClient;
                }
            }
            throw new ArgumentException();
        }

        public void UpdateProduct(Product product)
        {
            foreach(KeyValuePair<Guid, Product> item in _dataContext.Products)
            {
                if(item.Key == product.Id)
                {
                    item.Value.Name = product.Name;
                    item.Value.Description = product.Description;
                }
            }
            throw new ArgumentException();
        }
    }
}
