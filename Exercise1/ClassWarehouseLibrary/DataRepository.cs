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
            throw new NotImplementedException();
        }

        public void AddProduct(Product product, int key)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void DeleteProduct(int key)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Dictionary<int, Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Client GetClient(int id)
        {
            throw new NotImplementedException();
        }

        public Status GetInventoryStatus(int id)
        {
            throw new NotImplementedException();
        }

        public Invoice GetInvoice(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int key)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Client newClientInfo, int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateInventoryStatus(int id, Status newInventoryStatusInfo)
        {
            throw new NotImplementedException();
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
