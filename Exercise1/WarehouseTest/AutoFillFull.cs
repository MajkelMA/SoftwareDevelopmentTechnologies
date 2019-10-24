using ClassWarehouseLibrary;
using ClassWarehouseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WarehouseTest
{
    class AutoFillFull : IAutoFiller
    {
        void IAutoFiller.AutoFill(DataContext dataContext)
        {
            List<Client> clients = dataContext.Clients;
            Dictionary<Guid, Product> products = dataContext.Products;
            ObservableCollection<Invoice> invoices = dataContext.Invoices;
            List<Status> statuses = dataContext.Statuses;

            Client client1 = new Client
            {
                Id = Guid.NewGuid(),
                Name = "Name1",
                LastName = "LastName1",
                Birthday = new DateTime(1000, 1, 1)
            };

            Client client2 = new Client
            {
                Id = Guid.NewGuid(),
                Name = "Name2",
                LastName = "LastName2",
                Birthday = new DateTime(2000, 2, 2)
            };

            Product product1 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product1",
                Description = "Description1"
            };

            Product product2 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product2",
                Description = "Description2"
            };

            WeightStatus invoiceWeightStatus1 = new WeightStatus(product1, 1.1f, 1.1f, 1.1);
            ItemStatus invoiceItemStatus1 = new ItemStatus(product2, 1.1f, 1.1f, 1);

            WeightStatus statusesWeightStatus1 = new WeightStatus(product1, 11.1f, 11.1f, 11.1);
            ItemStatus statusesItemStatus1 = new ItemStatus(product2, 11.1f, 11.1f, 11);

            Invoice invoice1 = new Invoice
            {
                Id = Guid.NewGuid(),
                WarehouseClient = client1,
                Status = invoiceWeightStatus1,
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

            statuses.Add(statusesWeightStatus1);
            statuses.Add(statusesItemStatus1);
        }
    }
}
