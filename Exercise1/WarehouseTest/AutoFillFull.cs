using ClassWarehouseLibrary;
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
            ObservableCollection<Invoice> invoice = dataContext.Invoices;
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

            Product product3 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product3",
                Description = "Description3"
            };

            Product product4 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product4",
                Description = "Description4"
            };



            //Invoice invoice1 = new Invoice
            //{
            //    Id = Guid.NewGuid(),
            //    WarehouseClient = client1,
            //    Status = 
            //};
        }
    }
}
