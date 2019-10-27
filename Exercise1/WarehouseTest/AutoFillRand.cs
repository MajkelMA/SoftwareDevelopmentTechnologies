using ClassWarehouseLibrary;
using ClassWarehouseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WarehouseTest
{
    class AutoFillRand : IAutoFiller
    {
        public void AutoFill(DataContext dataContext)
        {
            List<Client> clients = dataContext.Clients;
            Dictionary<Guid, Product> products = dataContext.Products;
            ObservableCollection<Invoice> invoices = dataContext.Invoices;
            List<Status> statuses = dataContext.Statuses;

            Client client1 = new Client
            {
                Id = Guid.NewGuid(),
                Name = Rand.GetRandString(),
                LastName = Rand.GetRandString(),
                Birthday = new DateTime(1000, 1, 1),
                Email = Rand.GetRandString() + "@example.com"
            };

            Client client2 = new Client
            {
                Id = Guid.NewGuid(),
                Name = Rand.GetRandString(),
                LastName = Rand.GetRandString(),
                Birthday = new DateTime(2000, 2, 2),
                Email = Rand.GetRandString() + "@example.com"
            };

            Product product1 = new Product
            {
                Id = Guid.NewGuid(),
                Name = Rand.GetRandString(),
                Description = Rand.GetRandString()
            };

            Product product2 = new Product
            {
                Id = Guid.NewGuid(),
                Name = Rand.GetRandString(),
                Description = Rand.GetRandString()
            };

            ItemStatus invoiceItemStatus = new ItemStatus(product1, 1.1f, 1.1f, 1);
            ItemStatus invoiceItemStatus1 = new ItemStatus(product2, 1.1f, 1.1f, 1);

            ItemStatus statusesItemtStatus = new ItemStatus(product1, 11.1f, 11.1f, 11);
            ItemStatus statusesItemStatus1 = new ItemStatus(product2, 11.1f, 11.1f, 11);

            Invoice invoice1 = new Invoice
            {
                Id = Guid.NewGuid(),
                WarehouseClient = client1,
                Status = invoiceItemStatus,
            };

            Invoice invoice2 = new Invoice
            {
                Id = Guid.NewGuid(),
                WarehouseClient = client2,
                Status = invoiceItemStatus1,
            };

            products.Add(product1.Id, product1);
            products.Add(product2.Id, product2);

            clients.Add(client1);
            clients.Add(client2);

            invoices.Add(invoice1);
            invoices.Add(invoice2);

            statuses.Add(statusesItemtStatus);
            statuses.Add(statusesItemStatus1);
        }
    }

    class Rand
    {
        internal static string GetRandString()
        {
            String chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random(Guid.NewGuid().GetHashCode());
            char[] newString = new char[random.Next(4, 25)];

            for (int i = 0; i < newString.Length; i++)
            {
                newString[i] = chars[random.Next(chars.Length)];
            }

            return new String(newString);
        }
    }
}
