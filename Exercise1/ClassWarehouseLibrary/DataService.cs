using ClassWarehouseLibrary.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    class DataService
    {
        private IDataRepository _dataRepository;

        private event EventHandler InvoiceAdded;
        private event EventHandler InvoiceRemoved;

        public void AddInvoiceSub(EventHandler handler)
        {
            _dataRepository.InvoiceAdded += handler;
        }

        public void AddInvoiceUnsub(EventHandler handler)
        {
            _dataRepository.InvoiceAdded -= handler;
        }

        public void RemoveInvoiceSub(EventHandler handler)
        {
            _dataRepository.InvoiceAdded += handler;
        }

        public void RemoveInvoiceUnsub(EventHandler handler)
        {
            _dataRepository.InvoiceAdded -= handler;
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

        IEnumerable GetAllInvoices()
        {
            return _dataRepository.GetAllInvoices();
        }

        IEnumerable GetInventoryStatuses()
        {
            return _dataRepository.GetAllStatuses();
        }

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

        void AddInvoice(Client client, Status status)
        {
            _dataRepository.AddInvoice(new Invoice
            {
                Id = Guid.NewGuid(),
                Status = status,
                WarehouseClient = client
            });
        }

        void AddProduct(string name ,string description, float price, Type type)
        {
            Product productToAdd = new Product
            {
                Id = new Guid(),
                Description = description,
                Name = name
            };

            if (type == typeof(ItemStatus))
            {
                _dataRepository.AddProduct(productToAdd);
                _dataRepository.AddStatus(new ItemStatus(productToAdd, price, 0, 0));
            }
            else if(type == typeof(PackageStatus))
            {
                _dataRepository.AddProduct(productToAdd);
                _dataRepository.AddStatus(new PackageStatus(productToAdd, price, 0, 0));
            }
        }

        void AddStatus(Product product, float nettoPrice, float tax, int amount, Type type)
        {
            if (type == typeof(ItemStatus))
            {
                _dataRepository.AddStatus(new ItemStatus(product, nettoPrice, tax, amount));
            }
            if(type == typeof(PackageStatus))
            {
                _dataRepository.AddStatus(new PackageStatus(product, nettoPrice, tax, amount));
            }
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
