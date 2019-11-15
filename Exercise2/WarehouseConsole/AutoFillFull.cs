using ClassWarehouseLibrary;
using ClassWarehouseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WarehouseConsole
{
    class AutoFillFull : IAutoFiller
    {
        void IAutoFiller.AutoFill(DataContext dataContext)
        {
            List<Client> clients = dataContext.Clients;
            Dictionary<Guid, Product> products = dataContext.Products;
            ObservableCollection<Event> events = dataContext.Events;
            List<Status> statuses = dataContext.Statuses;

            Client client1 = new Client
            {
                Id = Guid.NewGuid(),
                Name = "Name1",
                LastName = "LastName1",
                Birthday = new DateTime(1000, 1, 1),
                Email = "ex@example.com"
            };

            Client client2 = new Client
            {
                Id = Guid.NewGuid(),
                Name = "Name2",
                LastName = "LastName2",
                Birthday = new DateTime(2000, 2, 2),
                Email = "ex2@example.com"
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

            ItemStatus invoiceItemStatus = new ItemStatus(product1, 1.1f, 1.1f, 1);
            ItemStatus invoiceItemStatus1 = new ItemStatus(product2, 1.1f, 1.1f, 1);

            ItemStatus statusesItemtStatus = new ItemStatus(product1, 11.1f, 11.1f, 11);
            ItemStatus statusesItemStatus1 = new ItemStatus(product2, 11.1f, 11.1f, 11);

            Event event1 = new DestroyEvent(Guid.NewGuid(), client1, invoiceItemStatus, "example destroy");
            Event event2 = new BuyEvent(Guid.NewGuid(), client1, invoiceItemStatus1, "example buy");
            Event event3 = new SellEvent(Guid.NewGuid(), client2, invoiceItemStatus1, "example sell");

            products.Add(product1.Id, product1);
            products.Add(product2.Id, product2);

            clients.Add(client1);
            clients.Add(client2);

            events.Add(event1);
            events.Add(event2);
            events.Add(event3);

            statuses.Add(statusesItemtStatus);
            statuses.Add(statusesItemStatus1);
        }
    }
}
