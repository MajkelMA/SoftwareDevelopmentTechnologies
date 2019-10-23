using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace ClassWarehouseLibrary
{
    public class DataRepository
    {
        private DataContext _dataContext;
        private IAutoFiller _autoFilling;

        public DataRepository(DataContext dataContext, IAutoFiller autoFilling)
        {
            _dataContext = dataContext;
            _autoFilling = autoFilling;
            _autoFilling.AutoFill(_dataContext);
        }

        public void AddClient(Client client)
        {
            _dataContext.Clients.Add(client);
        }

        public Client GetClient(int id)
        {
            return _dataContext.Clients[id];
        }

        public List<Client> GetAllClients()
        {
            return _dataContext.Clients;
        }

        public void UpdateClient(Client newClientInfo, int clientId)
        {
            _dataContext.Clients[clientId] = newClientInfo;
        }

        public void DeleteClient(Client clientToDelete)
        {
            if (!_dataContext.Clients.Remove(clientToDelete))
            {
                throw new ArgumentException();
            }
        }

        public void AddProduct(Product product, int key)
        {
            _dataContext.Products.Add(key, product);
        }

        public Product GetProduct(int key)
        {
            return _dataContext.Products[key];
        }

        public Dictionary<int, Product> GetAllProducts()
        {
            return _dataContext.Products;
        }

        public void DeleteProduct(int key)
        {
            if (!_dataContext.Products.Remove(key))
            {
                throw new KeyNotFoundException();
            }
        }

        public void UpdateProduct(int key, Product newProductInfo)
        {
            Product product = null;
            if(!_dataContext.Products.TryGetValue(key, out product))
            {
                throw new KeyNotFoundException();
            }
            else
            {
                product = newProductInfo;
                _dataContext.Products[key] = product;
            }
        }

        public void AddInventoryStatus(InventoryStatus inventoryStatus)
        {
            _dataContext.InventoryStatuses.Add(inventoryStatus);
        }

        public InventoryStatus GetInventoryStatus(int id)
        {
            return _dataContext.InventoryStatuses[id];
        }

        public List<InventoryStatus> GetAllInventoryStatuses()
        {
            return _dataContext.InventoryStatuses;
        }

        public void DeleteInventoryStatus(InventoryStatus inventoryStatus)
        {
            if (!_dataContext.InventoryStatuses.Remove(inventoryStatus))
            {
                throw new ArgumentException();
            }
        }

        public void UpdateInventoryStatus(int id, InventoryStatus newInventoryStatusInfo)
        {
            _dataContext.InventoryStatuses[id] = newInventoryStatusInfo;
        }

        public void AddInvoice(Invoice invoice)
        {
            _dataContext.Invoices.Add(invoice);
        }

        public Invoice GetInvoice(int id)
        {
            return _dataContext.Invoices[id];
        }

        public ObservableCollection<Invoice> GetAllInvoices()
        {
            return _dataContext.Invoices;
        }

        public void DeleteInvoice(Invoice invoice)
        {
            if (!_dataContext.Invoices.Remove(invoice))
            {
                throw new ArgumentException();
            }
        }

        public void UpdateInvoice(int id, Invoice newInvoiceInfo)
        {
            _dataContext.Invoices[id] = newInvoiceInfo;
        }
    }
}
