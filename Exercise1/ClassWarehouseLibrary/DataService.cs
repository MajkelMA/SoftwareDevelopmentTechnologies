using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassWarehouseLibrary
{
    class DataService
    {
        private IDataRepository _dataRepository;

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
            return _dataRepository.GetAllInventoryStatuses();
        }

        // zwraca wszystkie produkty zakupione przez klienta
        IEnumerable<Product> GetClientProducts(Client client)
        {
            ObservableCollection<Invoice> invoices = _dataRepository.GetAllInvoices();
            List<Product> products = new List<Product>();
            foreach(Invoice item in invoices)
            {
                if(item.WarehouseClient.Equals(client))
                {
                    products.AddRange(item.Products);
                }
            }
            return products;
        }

        // zwraca wszystkie faktury klienta - radek
        IEnumerable<Invoice> GetClientInvoices(Client client)
        {
            //TODO
            return null;
        }

        // zwraca wszystkie faktury dotyczace produktu - michal
        IEnumerable<Invoice> GetInvoicesWithProduct(Product product)
        {
            ObservableCollection<Invoice> invoices = _dataRepository.GetAllInvoices();
            List<Invoice> result = new List<Invoice>();
            foreach(Invoice item in invoices)
            {
                if (item.Products.Contains(product))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        // zwraca wszystkich klientow ktorzy kupili dany produkt - radek
        IEnumerable<Client> GetClientsWhoBoughtProduct(Product product)
        {
            //TODO
            return null;
        }

        // dodaje fakture na podstawie klienta i listy produktow - michal
        void AddInvoice(Client client, List<Product> products)
        {
            _dataRepository.AddInvoice(new Invoice(client, products));
        }

        // dodaje produkt na podstawie jego opisu (aktualizuje stan magazynowy) - radek
        void AddProduct(string description, float price)
        {
            //TODO
        }

         //michal
        void AddInventoryStatus(Product product, int state, float nettoPrice, float tax)
        {
            _dataRepository.AddInventoryStatus(new InventoryStatus(product, state, nettoPrice, tax));
        }

        //radek
        void AddClient(string name, string lastname, DateTime birthday)
        {
            //TODO
        }


        //michal
        IEnumerable<Product> GetProductWithPriceBetween(float min, float max)
        {
            List<Product> products = new List<Product>();
            foreach(InventoryStatus item in _dataRepository.GetAllInventoryStatuses())
            {
                //TODO
            }
            return null;
        }

        //radek
        IEnumerable<Product> GetProductWithTaxBetween(float min, float max)
        {
            //TODO
            return null;
        }


        //michal
        IEnumerable<Client> GetClientWithBirthday(int day, int month, int year)
        {
            return null;
        }

    }
}
