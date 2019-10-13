using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    class DataRepository
    {
        private DataContext _DataContext;

        public DataRepository(DataContext DataContext)
        {
            _DataContext = DataContext;
        }

        public void AddClient(Client client)
        {
            _DataContext.Clients.Add(client);
        }

        public Client GetClient(int id)
        {
            return _DataContext.Clients[id];
        }

        public List<Client> GetAllClients()
        {
            return _DataContext.Clients;
        }

        public void UpdateClient(Client newClientInfo, int clientId)
        {
            _DataContext.Clients[clientId] = newClientInfo;
        }

        public void DeleteClient(Client clientToDelete)
        {
            _DataContext.Clients.Remove(clientToDelete);
        }

        public void AddProduct(Product product, int key)
        {
            _DataContext.Products.Add(key, product);
        }

        public Product GetProduct(int key)
        {
            return _DataContext.Products[key];
        }

        public Dictionary<int, Product> GetAllProducts()
        {
            return _DataContext.Products;
        }

        public void DeleteProduct(int key)
        {
            _DataContext.Products.Remove(key);
        }

        public void UpdateProduct(int key, Product newProductInfo)
        {
            _DataContext.Products[key] = newProductInfo;
        }

        public void AddInventoryStatus(InventoryStatus inventoryStatus)
        {
            _DataContext.InventoryStatuses.Add(inventoryStatus);
        }

        public InventoryStatus GetInventoryStatus(int id)
        {
            return _DataContext.InventoryStatuses[id];
        }

        public List<InventoryStatus> GetAllInventoryStatuses()
        {
            return _DataContext.InventoryStatuses;
        }

        public void DeleteInventoryStatus(InventoryStatus inventoryStatus)
        {
            _DataContext.InventoryStatuses.Remove(inventoryStatus);
        }

        public void UpdateInventoryStatus(int id, InventoryStatus newInventoryStatusInfo)
        {
            _DataContext.InventoryStatuses[id] = newInventoryStatusInfo;
        }

    }
}
