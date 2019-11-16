using ClassWarehouseLibrary.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    class DataService
    {
        private IDataRepository _dataRepository;

        private event EventHandler EventeAdded;
        private event EventHandler EventRemoved;

        public void AddEventSub(EventHandler handler)
        {
            _dataRepository.EventAdded += handler;
        }

        public void AddEventUnsub(EventHandler handler)
        {
            _dataRepository.EventAdded -= handler;
        }

        public void RemoveEventSub(EventHandler handler)
        {
            _dataRepository.EventAdded += handler;
        }

        public void RemoveEventUnsub(EventHandler handler)
        {
            _dataRepository.EventAdded -= handler;
        }

        public DataService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        IEnumerable GetAllProducts()
        {
            return _dataRepository.GetAllProducts();
        }
        
        IEnumerable GetAllClients()
        {
            return _dataRepository.GetAllClients();
        }

        IEnumerable GetAllEvents()
        {
            return _dataRepository.GetAllEvents();
        }

        IEnumerable GetInventoryStatuses()
        {
            return _dataRepository.GetAllStatuses();
        }

        IEnumerable<Product> GetClientProducts(Client client)
        {
            List<Product> result = new List<Product>();
            foreach(Event item in _dataRepository.GetAllEvents())
            {
                if(item.WarehouseClient == client)
                {
                    result.Add(item.Status.Product);
                }
            }
            return result;
        }

        IEnumerable<Event> GetClientEvents(Client client)
        {
            List<Event> clientsEvents = new List<Event>();
            foreach(Event item in _dataRepository.GetAllEvents())
            {
                if (item.WarehouseClient.Equals(client))
                {
                    clientsEvents.Add(item);
                }
            }

            return clientsEvents;
        }

        IEnumerable<Event> GetEventsWithProduct(Product product)
        {
            List<Event> result = new List<Event>();
            foreach (Event item in _dataRepository.GetAllEvents())
            {
                if (item.Status.Product == product)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        IEnumerable<Client> GetClientsWhoBoughtProduct(Product product)
        {
            List<Client> clients = new List<Client>();
            foreach(Event item in _dataRepository.GetAllEvents())
            {
                if(item.GetType() == typeof(SellEvent))
                if (item.Status.Product.Equals(product))
                {
                    clients.Add(item.WarehouseClient);
                }
            }
            return clients;
        }

        void AddEvent(Client client, EventStatus status, string description, Type type)
        {
            Event eventToAdd;
            if(type == typeof(DestroyEvent))
            {
                eventToAdd = new DestroyEvent(new Guid(), client, status, description);
                _dataRepository.AddEvent(eventToAdd);
            }
            else if (type == typeof(SellEvent))
            {
                eventToAdd = new SellEvent(new Guid(), client, status, description);
                _dataRepository.AddEvent(eventToAdd);
            }
            else if (type == typeof(BuyEvent))
            {
                eventToAdd = new BuyEvent(new Guid(), client, status, description);
                _dataRepository.AddEvent(eventToAdd);
            }
        }

        void AddProduct(string name ,string description, float price, Type type)
        {
            Product productToAdd = new Product
            {
                Id = new Guid(),
                Description = description,
                Name = name
            };

            _dataRepository.AddProduct(productToAdd);
            _dataRepository.AddStatus(new Status(productToAdd, price, 0, 0));
        }

        void AddStatus(Product product, float nettoPrice, float tax, int amount, Type type)
        {
            _dataRepository.AddStatus(new Status(product, nettoPrice, tax, amount));
        }

        void AddClient(string name, string lastname, DateTime birthday, string email)
        {
            _dataRepository.AddClient(new Client {
                Id = new Guid(),
                Name = name,
                LastName = lastname,
                Birthday = birthday,
                Email = email
            });
        }

        IEnumerable<Product> GetProductWithPriceBetween(float min, float max)
        {
            List<Product> result = new List<Product>();
            foreach(Status item in _dataRepository.GetAllStatuses())
            {
                if(item.NettoPrice >= min && item.NettoPrice <= max)
                {
                    result.Add(item.Product);
                }
            }
            return result;
        }

        IEnumerable<Product> GetProductWithTaxBetween(float min, float max)
        {
            List<Product> products = new List<Product>();
            foreach(Status status in _dataRepository.GetAllStatuses())
            {
                if(status.Tax > min && status.Tax < max)
                {
                    products.Add(status.Product);
                }
            }
            return products;
        }

        IEnumerable<Client> GetClientWithBirthday(int day, int month, int year)
        {
            List<Client> result = new List<Client>();
            DateTime date = new DateTime(year, month, day);
            foreach(Client item in _dataRepository.GetAllClients())
            {
                if(item.Birthday == date)
                {
                    result.Add(item);
                }
            }
            return result;
        }

    }
}
