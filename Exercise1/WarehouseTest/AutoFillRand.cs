﻿using ClassWarehouseLibrary;
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
            ObservableCollection<Event> events = dataContext.Events;
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

            ItemStatus itemStatus = new ItemStatus(product1, 1.1f, 1.1f, 1);
            ItemStatus itemStatus1 = new ItemStatus(product2, 1.1f, 1.1f, 1);
            ItemStatus itemStatus2 = new ItemStatus(product1, 11.1f, 11.1f, 11);
            ItemStatus itemStatus3 = new ItemStatus(product2, 11.1f, 11.1f, 11);

            Event event1 = new BuyEvent(new Guid(), client1, itemStatus, "buy example");
            Event event2 = new SellEvent(new Guid(), client2, itemStatus1, "sell example");

            products.Add(product1.Id, product1);
            products.Add(product2.Id, product2);

            clients.Add(client1);
            clients.Add(client2);

            events.Add(event1);
            events.Add(event2);

            statuses.Add(itemStatus2);
            statuses.Add(itemStatus3);
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
