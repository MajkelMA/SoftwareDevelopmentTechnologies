using ClassWarehouseLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WarehouseConsoleApp
{
    class AutoFill : IAutoFilling
    {
        void IAutoFilling.AutoFill(DataContext dataContext)
        {
            List<Client> Clients = dataContext.Clients;
            Dictionary<int, Product> Products = dataContext.Products;
            ObservableCollection<Invoice> Invoices = dataContext.Invoices;
            List<InventoryStatus> InventoryStatuses = dataContext.InventoryStatuses;

            Client Client0 = new Client("Radoslaw", "Lapciak", birthday: new DateTime(1997, 9, 22));
            Client Client1 = new Client("Michal", "Bilicki", birthday: new DateTime(1998, 1, 30));

            Product Product0 = new Product("Product0");
            Product Product1 = new Product("Product1");

            List<Product> List0 = new List<Product>();
            List<Product> List1 = new List<Product>();

            Clients.Add(Client0);
            Clients.Add(Client1);

            Products.Add(0, Product0);
            Products.Add(1, Product1);

            List0.Add(Product0);
            List1.Add(Product1);

            Invoice Invoice0 = new Invoice(Client0, List0);
            Invoice Invoice1 = new Invoice(Client1, List1);

            Invoices.Add(Invoice0);
            Invoices.Add(Invoice1);

            //TO CHANGE!!!!!
            InventoryStatus InventoryStatus0 = new InventoryStatus(Product0, 10, 100, 15);
            InventoryStatus InventoryStatus1 = new InventoryStatus(Product1, 5, 70, 20);

            InventoryStatuses.Add(InventoryStatus0);
            InventoryStatuses.Add(InventoryStatus1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
