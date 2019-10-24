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
            //TODO
            return null;
        }
        
        //radek
        IEnumerable GetAllClients()
        {
            //TODO
            return null;
        }


        //michal
        IEnumerable GetAllInvoices()
        {
            //TODO
            return null;
        }


        //radek
        IEnumerable GetInventoryStatuses()
        {
            //TODO
            return null;
        }
        //michal
        // zwraca wszystkie produkty zakupione przez klienta
        IEnumerable<Product> GetClientProducts(Client client)
        {
            //TODO
            return null;
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
            //TODO
            return null;
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
            //TODO
        }

        // dodaje produkt na podstawie jego opisu (aktualizuje stan magazynowy) - radek
        void AddProduct(string description, float price)
        {
            //TODO
        }

         //michal
        void AddInventoryStatus(Product product, int state, float nettoPrice, float tax)
        {
            //TODO
        }

        //radek
        void AddClient(string name, string lastname, DateTime birthday)
        {
            //TODO
        }


        //michal
        IEnumerable<Product> GetProductWithPriceBetween(float min, float max)
        {
            //TODO
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
            //TODO
            return null;
        }

    }
}
