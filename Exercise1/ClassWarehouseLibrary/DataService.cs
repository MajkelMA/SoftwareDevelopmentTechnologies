using ClassWarehouseLibrary.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    class DataService
    {
        private IDataRepository _dataRepository;

        public DataService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        //miichal
        IEnumerable GetAllProducts()
        {
            return _dataRepository.GetAllProducts();
        }
        
        //radek
        IEnumerable GetAllClients()
        {
            return _dataRepository.GetAllClients();
        }

        //michal
        IEnumerable GetAllInvoices()
        {
            return _dataRepository.GetAllInvoices();
        }

        //radek
        IEnumerable GetInventoryStatuses()
        {
            return _dataRepository.GetAllStatuses();
        }

        //michal
        // zwraca wszystkie produkty zakupione przez klienta
        IEnumerable<Product> GetClientProducts(Client client)
        {
            List<Product> result = new List<Product>();
            foreach(Invoice item in _dataRepository.GetAllInvoices())
            {
                if(item.WarehouseClient == client)
                {
                    result.Add(item.Status.Product);
                }
            }
            return result;
        }

        // zwraca wszystkie faktury klienta - radek
        IEnumerable<Invoice> GetClientInvoices(Client client)
        {
            List<Invoice> clientsInvoices = new List<Invoice>();
            foreach(Invoice invoice in _dataRepository.GetAllInvoices())
            {
                if (invoice.WarehouseClient.Equals(client))
                {
                    clientsInvoices.Add(invoice);
                }
            }

            return clientsInvoices;
        }

        // zwraca wszystkie faktury dotyczace produktu - michal
        IEnumerable<Invoice> GetInvoicesWithProduct(Product product)
        {
            List<Invoice> result = new List<Invoice>();
            foreach (Invoice item in _dataRepository.GetAllInvoices())
            {
                if (item.Status.Product == product)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        // zwraca wszystkich klientow ktorzy kupili dany produkt - radek
        IEnumerable<Client> GetClientsWhoBoughtProduct(Product product)
        {
            List<Client> clients = new List<Client>();
            foreach(Invoice invoice in _dataRepository.GetAllInvoices())
            {
                if (invoice.Status.Product.Equals(product))
                {
                    clients.Add(invoice.WarehouseClient);
                }
            }
            return clients;
        }

        // dodaje fakture na podstawie klienta i statusu produktu - michal
        void AddInvoice(Client client, Status status)
        {
            _dataRepository.AddInvoice(new Invoice
            {
                Id = Guid.NewGuid(),
                Status = status,
                WarehouseClient = client
            });
        }

        // dodaje produkt na podstawie jego opisu (aktualizuje stan magazynowy) - radek
        void AddProduct(string name ,string description, float price)
        {
            Product productToAdd = new Product
            {
                Id = new Guid(),
                Description = description,
                Name = name
            };
            _dataRepository.AddProduct(productToAdd);
            _dataRepository.AddStatus(new ItemStatus(productToAdd, price, 0, 0));
        }

         //michal
        void AddStatus(Product product, float nettoPrice, float tax, int amount)
        {
            _dataRepository.AddStatus(new ItemStatus(product, nettoPrice, tax, amount));
        }

        //radek
        void AddClient(string name, string lastname, DateTime birthday)
        {
            _dataRepository.AddClient(new Client {
                Name = name,
                LastName = lastname,
                Birthday = birthday
            });
        }


        //michal
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

        //radek
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


        //michal
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
