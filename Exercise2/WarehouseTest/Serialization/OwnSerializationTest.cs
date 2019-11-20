using ClassWarehouseLibrary;
using ClassWarehouseLibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Serialization;

namespace WarehouseTest
{
    [TestClass]
    public class OwnSerializationTest
    {
        [TestMethod]
        public void SerializationTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), dataContext);
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            string result = dataContext.Serialize(idGenerator);
            Assert.AreEqual(dataContext, dataContext.Deserialize(result));
        }

        [TestMethod]
        public void ProductSerializationTest()
        {
            DataContext dataContext = new DataContext();
            Product product = new Product
            {
                Id = Guid.Parse("d668da2f-4848-4114-8e97-17e2ae27b6c7"),
                Name = "TestName",
                Description = "TestDescription"
            };
            dataContext.Products.Add(product.Id, product);

            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            string result = dataContext.Serialize(idGenerator);
            Assert.AreEqual(result, "ClassWarehouseLibrary.Product|1|d668da2f-4848-4114-8e97-17e2ae27b6c7|TestName|TestDescription\n");
        }

        [TestMethod]
        public void ClientSerializationTest()
        {
            DataContext dataContext = new DataContext();
            dataContext.Clients.Add(new Client
            {
                Id = Guid.Parse("d668da2f-4848-4114-8e97-17e2ae27b6c7"),
                Name = "Radoslaw",
                LastName = "Lapciak",
                Birthday = new DateTime(1997, 9, 22),
                Email = "test@test.test"
            });
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            string result = dataContext.Serialize(idGenerator);
            Assert.AreEqual(result, "ClassWarehouseLibrary.Client|1|d668da2f-4848-4114-8e97-17e2ae27b6c7|Radoslaw|Lapciak|22.09.1997 00:00:00|test@test.test\n");
        }

        [TestMethod]
        public void StatusSerializationTest()
        {
            DataContext dataContext = new DataContext();
            Product product = new Product
            {
                Id = Guid.Parse("d668da2f-4848-4114-8e97-17e2ae27b6c7"),
                Name = "TestName",
                Description = "TestDescription"
            };
            dataContext.Products.Add(product.Id, product);
            dataContext.Statuses.Add(new Status
            {
                Id = Guid.Parse("63931412-e479-4573-aa3b-c0c7b2eb7dff"),
                Product = product,
                Amount = 10,
                NettoPrice = 10,
                Tax = 10
            });

            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            string result = dataContext.Serialize(idGenerator);
            Assert.AreEqual(result, "ClassWarehouseLibrary.Product|1|d668da2f-4848-4114-8e97-17e2ae27b6c7|TestName|TestDescription\n"
                                  + "ClassWarehouseLibrary.Status|2|63931412-e479-4573-aa3b-c0c7b2eb7dff|10|10|10|1\n");
        }

        [TestMethod]
        public void EventSerializationTest()
        {
            DataContext dataContext = new DataContext();
            Product product = new Product
            {
                Id = Guid.Parse("d668da2f-4848-4114-8e97-17e2ae27b6c7"),
                Name = "TestName",
                Description = "TestDescription"
            };
            dataContext.Products.Add(product.Id, product);
            Client client = new Client
            {
                Id = Guid.Parse("63931412-e479-4573-aa3b-c0c7b2eb7dff"),
                Name = "Radoslaw",
                LastName = "Lapciak",
                Birthday = new DateTime(1997, 9, 22),
                Email = "test@test.test"
            };
            dataContext.Clients.Add(client);

            BuyEvent buyEvent = new BuyEvent(Guid.Parse("da2dc210-571d-4103-9b42-eafc5b1a247f"), client,
                new EventStatus
                {
                    Id = Guid.Parse("c121dcde-4552-45e9-a8e2-ead09d179bfb"),
                    Product = product,
                    Amount = 10,
                    NettoPrice = 10,
                    Tax = 10
                },
                "example buy");
            dataContext.Events.Add(buyEvent);

            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            string result = dataContext.Serialize(idGenerator);
            Assert.AreEqual(result, "ClassWarehouseLibrary.Client|1|63931412-e479-4573-aa3b-c0c7b2eb7dff|Radoslaw|Lapciak|22.09.1997 00:00:00|test@test.test\n"
                                  + "ClassWarehouseLibrary.Product|2|d668da2f-4848-4114-8e97-17e2ae27b6c7|TestName|TestDescription\n"
                                  + "ClassWarehouseLibrary.EventStatus|3|c121dcde-4552-45e9-a8e2-ead09d179bfb|10|10|10|2\n"
                                  + "ClassWarehouseLibrary.Entities.BuyEvent|4|da2dc210-571d-4103-9b42-eafc5b1a247f|1|3|example buy|\n");
        }

        [TestMethod]
        public void ProductDeserializationTest()
        {
            DataContext dataContext = new DataContext();
            Product product = new Product
            {
                Id = Guid.Parse("d668da2f-4848-4114-8e97-17e2ae27b6c7"),
                Name = "TestName",
                Description = "TestDescription"
            };
            dataContext.Products.Add(product.Id, product);

            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            string result = dataContext.Serialize(idGenerator);

            dataContext.Deserialize(result);

            Assert.AreEqual(product, dataContext.Products[Guid.Parse("d668da2f-4848-4114-8e97-17e2ae27b6c7")]);
        }

        [TestMethod]
        public void ClientDeserializationTest()
        {
            DataContext dataContext = new DataContext();
            Client client = new Client
            {
                Id = Guid.Parse("d668da2f-4848-4114-8e97-17e2ae27b6c7"),
                Name = "Radoslaw",
                LastName = "Lapciak",
                Birthday = new DateTime(1997, 9, 22),
                Email = "test@test.test"
            };
            dataContext.Clients.Add(client);
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            string result = dataContext.Serialize(idGenerator);

            dataContext.Deserialize(result);

            Assert.IsTrue(dataContext.Clients.Contains(client));
        }

        [TestMethod]
        public void StatusDeserializationTest()
        {
            DataContext dataContext = new DataContext();
            Product product = new Product
            {
                Id = Guid.Parse("d668da2f-4848-4114-8e97-17e2ae27b6c7"),
                Name = "TestName",
                Description = "TestDescription"
            };
            dataContext.Products.Add(product.Id, product);
            Status status = new Status
            {
                Id = Guid.Parse("63931412-e479-4573-aa3b-c0c7b2eb7dff"),
                Product = product,
                Amount = 10,
                NettoPrice = 10,
                Tax = 10
            };
            dataContext.Statuses.Add(status);

            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            string result = dataContext.Serialize(idGenerator);

            dataContext.Deserialize(result);

            Assert.IsTrue(dataContext.Statuses.Contains(status));
        }

        [TestMethod]
        public void EventDeserializationTest()
        {
            DataContext dataContext = new DataContext();
            Product product = new Product
            {
                Id = Guid.Parse("d668da2f-4848-4114-8e97-17e2ae27b6c7"),
                Name = "TestName",
                Description = "TestDescription"
            };
            dataContext.Products.Add(product.Id, product);
            Client client = new Client
            {
                Id = Guid.Parse("63931412-e479-4573-aa3b-c0c7b2eb7dff"),
                Name = "Radoslaw",
                LastName = "Lapciak",
                Birthday = new DateTime(1997, 9, 22),
                Email = "test@test.test"
            };
            dataContext.Clients.Add(client);

            BuyEvent buyEvent = new BuyEvent(Guid.Parse("da2dc210-571d-4103-9b42-eafc5b1a247f"), client,
                new EventStatus
                {
                    Id = Guid.Parse("c121dcde-4552-45e9-a8e2-ead09d179bfb"),
                    Product = product,
                    Amount = 10,
                    NettoPrice = 10,
                    Tax = 10
                },
                "example buy");
            dataContext.Events.Add(buyEvent);

            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            string result = dataContext.Serialize(idGenerator);

            dataContext.Deserialize(result);

            Assert.AreEqual(buyEvent.Id, dataContext.Events[0].Id);
            Assert.AreEqual(buyEvent.Status, dataContext.Events[0].Status);
            Assert.AreEqual(buyEvent.WarehouseClient, dataContext.Events[0].WarehouseClient);
            Assert.AreEqual(buyEvent.Description, dataContext.Events[0].Description);
        }
    }
}
