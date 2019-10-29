using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using ClassWarehouseLibrary.Entities;
using System.Collections.Specialized;

namespace ClassWarehouseLibrary
{
    public class DataRepository : IDataRepository
    {
        private DataContext _dataContext;
        private IAutoFiller _autoFilling;

        public event EventHandler InvoiceAdded;
        public event EventHandler InvoiceDeleted;

        public DataRepository(IAutoFiller autoFilling)
        {
            _dataContext = new DataContext();
            _autoFilling = autoFilling;
            _autoFilling.AutoFill(_dataContext);

            _dataContext.Invoices.CollectionChanged += InvoicesContexChanged;
        }

        private void InvoicesContexChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                InvoiceAdded?.Invoke(this, new EventArgs());
            }
            else if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                InvoiceDeleted?.Invoke(this, new EventArgs());
            }
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
                if(statusInList.Id == status.Id || statusInList.Product.Equals(status.Product))
                {
                    throw new ArgumentException();
                }
            }
            _dataContext.Statuses.Add(status);
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

        public List<Client> GetAllClients()
        {
            return _dataContext.Clients;
        }

        public List<Status> GetAllStatuses()
        {
            return _dataContext.Statuses;
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
            bool noneUniqueProductFlag = false;

            foreach (Status status in _dataContext.Statuses)
            {
                if(newStatusInfo.Id != status.Id)
                {
                    if (newStatusInfo.Product.Equals(status.Product))
                    {
                        noneUniqueProductFlag = true;
                    }
                }
            }

            foreach(Status statusToUpdate in _dataContext.Statuses)
            {
                if(statusToUpdate.Id == id)
                {
                    statusToUpdate.NettoPrice = newStatusInfo.NettoPrice;
                    statusToUpdate.Tax = newStatusInfo.Tax;
                    statusToUpdate.Product = newStatusInfo.Product;
                    statusToUpdate.Amount = newStatusInfo.Amount;
                    changeFlag = true;
                }
            }

            if ( (!changeFlag) || noneUniqueProductFlag)
            {
                throw new ArgumentException();
            }
        }

        public void AddProduct(Product product)
        {
            foreach (KeyValuePair<Guid, Product> item in _dataContext.Products)
            {
                if (item.Key == product.Id)
                {
                    throw new ArgumentException();
                }
            }
            _dataContext.Products.Add(product.Id, product);
        }

        public void DeleteProduct(Guid key)
        {
            if (!_dataContext.Products.Remove(key))
            {
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

        public void UpdateProduct(Product product)
        {
            if (!_dataContext.Products.ContainsKey(product.Id))
            {
                throw new ArgumentException();
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
            foreach (KeyValuePair<Guid, Product> item in _dataContext.Products)
            {
                if (item.Key == key)
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

        public void AddInvoice(Invoice invoice)
        {
            foreach (Invoice item in _dataContext.Invoices)
            {
                if (item.Id == invoice.Id)
                {
                    throw new ArgumentException();
                }
            }
            _dataContext.Invoices.Add(invoice);
        }

        public void DeleteInvoice(Invoice invoice)
        {
            if (!_dataContext.Invoices.Remove(invoice))
            {
                throw new ArgumentException();
            }
        }

        public ObservableCollection<Invoice> GetAllInvoices()
        {
            return _dataContext.Invoices;
        }

        public Invoice GetInvoice(Guid id)
        {
            foreach (Invoice item in _dataContext.Invoices)
            {
                if (item.Id == id)
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

        public void UpdateInvoice(Invoice invoice)
        {
            if (!_dataContext.Invoices.Contains(invoice))
            {
                throw new ArgumentException();
            }

            foreach (Invoice item in _dataContext.Invoices)
            {
                if (item.Id == invoice.Id)
                {
                    item.Status = invoice.Status;
                    item.WarehouseClient = invoice.WarehouseClient;
                }
            }
        }

    }
}
