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
    }
}
