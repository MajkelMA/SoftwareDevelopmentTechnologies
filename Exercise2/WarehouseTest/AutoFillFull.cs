﻿using ClassWarehouseLibrary;
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
            ObservableCollection<Event> events = dataContext.Events;
            List<Status> statuses = dataContext.Statuses;

            #region "Clients"
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

            clients.Add(client1);
            clients.Add(client2);
            #endregion

            #region "Products"
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

            products.Add(product1.Id, product1);
            products.Add(product2.Id, product2);
            #endregion

            #region "Events"
            Status eventStatus1 = new Status(product1, 1.1f, 1.1f, 1);
            Status eventStatus2 = new Status(product2, 2.2f, 2.2f, 2);
            Status eventStatus3 = new Status(product1, 3.3f, 3.3f, 3);

            Event event1 = new DestroyEvent(Guid.NewGuid(), client1, eventStatus1, "example destroy");
            Event event2 = new BuyEvent(Guid.NewGuid(), client1, eventStatus2, "example buy");
            Event event3 = new SellEvent(Guid.NewGuid(), client2, eventStatus3, "example sell");

            events.Add(event1);
            events.Add(event2);
            events.Add(event3);
            #endregion

            #region "Statuses"
            Status status1 = new Status(product2, 4.4f, 4.4f, 4);
            Status status2 = new Status(product2, 4.4f, 4.4f, 4);

            statuses.Add(status1);
            statuses.Add(status2);
            #endregion
        }
    }
}

//using ClassWarehouseLibrary;
//using ClassWarehouseLibrary.Entities;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;

//namespace WarehouseTest
//{
//    class AutoFillFull : IAutoFiller
//    {
//        void IAutoFiller.AutoFill(DataContext dataContext)
//        {
//            List<Client> clients = dataContext.Clients;
//            Dictionary<Guid, Product> products = dataContext.Products;
//            ObservableCollection<Event> events = dataContext.Events;
//            List<Status> statuses = dataContext.Statuses;

//            Client client1 = new Client
//            {
//                Id = Guid.NewGuid(),
//                Name = "Name1",
//                LastName = "LastName1",
//                Birthday = new DateTime(1000, 1, 1),
//                Email = "ex@example.com"
//            };

//            Client client2 = new Client
//            {
//                Id = Guid.NewGuid(),
//                Name = "Name2",
//                LastName = "LastName2",
//                Birthday = new DateTime(2000, 2, 2),
//                Email = "ex2@example.com"
//            };

//            Product product1 = new Product
//            {
//                Id = Guid.NewGuid(),
//                Name = "Product1",
//                Description = "Description1"
//            };

//            Product product2 = new Product
//            {
//                Id = Guid.NewGuid(),
//                Name = "Product2",
//                Description = "Description2"
//            };

//            Status status = new Status(product1, 1.1f, 1.1f, 1);
//            Status status1 = new Status(product2, 1.1f, 1.1f, 1);
//            Status status2 = new Status(product1, 11.1f, 11.1f, 11);
//            Status status3 = new Status(product2, 11.1f, 11.1f, 11);

//            Event event1 = new DestroyEvent(Guid.NewGuid(), client1, status, "example destroy");
//            Event event2 = new BuyEvent(Guid.NewGuid(), client1, status1, "example buy");
//            Event event3 = new SellEvent(Guid.NewGuid(), client2, status1, "example sell");

//            products.Add(product1.Id, product1);
//            products.Add(product2.Id, product2);

//            clients.Add(client1);
//            clients.Add(client2);

//            events.Add(event1);
//            events.Add(event2);
//            events.Add(event3);

//            statuses.Add(status2);
//            statuses.Add(status3);
//        }
//    }
//}