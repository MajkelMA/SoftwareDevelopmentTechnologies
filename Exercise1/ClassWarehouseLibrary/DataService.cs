using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassWarehouseLibrary
{
    class DataService
    {
        private IDataRepository _dataRepository;

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

        // zwraca wszystkie faktury klienta
        IEnumerable<Invoice> GetClientInvoices(Client client)
        {
            //TODO
            return null;
        }

        // zwraca wszystkie faktury dotyczace produktu
        IEnumerable<Invoice> GetInvoicesWithProduct(Product product)
        {
            //TODO
            return null;
        }

        // zwraca wszystkich klientow ktorzy kupili dany produkt
        IEnumerable<Client> GetClientsWhoBoughtProduct(Product product)
        {
            //TODO
            return null;
        }

        // dodaje fakture na podstawie klienta i listy produktow
        void AddInvoice(Client client, List<Product> products)
        {
            //TODO
        }

        // dodaje produkt na podstawie jego opisu

    }
}
