using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
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
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                InvoiceAdded?.Invoke(this, new EventArgs());
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                InvoiceDeleted?.Invoke(this, new EventArgs());
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

        #region InvoiceRegion
        public void AddInvoice(Invoice invoice)
        {
            foreach (Invoice item in _dataContext.Invoices)
            {
                if (item.Id == invoice.Id)
                {
                    throw new ArgumentException("such invoice already exists");
                }
            }
            _dataContext.Invoices.Add(invoice);
        }

        public void DeleteInvoice(Invoice invoice)
        {
            if (!_dataContext.Invoices.Remove(invoice))
            {
                throw new ArgumentException("such invoice does not exist");
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
            return null;
        }

        public void UpdateInvoice(Invoice invoice)
        {
            if (!_dataContext.Invoices.Contains(invoice))
            {
                throw new ArgumentException("such invoice does not exist");
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
        #endregion
    }
}
