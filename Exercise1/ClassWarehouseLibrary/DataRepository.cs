using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

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
            throw new NotImplementedException();
        }

        public void AddInventoryStatus(Status inventoryStatus)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void DeleteInventoryStatus(Status inventoryStatus)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<Status> GetAllInventoryStatuses()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Invoice> GetAllInvoices()
        {
            return _dataContext.Invoices;
        }

        public Dictionary<Guid, Product> GetAllProducts()
        {
            return _dataContext.Products;
        }

        public Client GetClient(int id)
        {
            throw new NotImplementedException();
        }

        public Status GetInventoryStatus(int id)
        {
            throw new NotImplementedException();
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

        public void UpdateClient(Client newClientInfo, int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateInventoryStatus(int id, Status newInventoryStatusInfo)
        {
            throw new NotImplementedException();
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
