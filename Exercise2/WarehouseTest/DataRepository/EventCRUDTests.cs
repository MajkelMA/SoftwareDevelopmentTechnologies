using ClassWarehouseLibrary;
using ClassWarehouseLibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace WarehouseTest
{
    [TestClass]
    public class EventCRUDTests
    {
        [TestMethod]
        public void AddEventTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), dataContext);
            Assert.AreEqual(dataRepository.GetAllEvents().Count, 3);

            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "ProductName",
                Description = "ProductDescription"
            };

            Client client = new Client
            {
                Id = Guid.NewGuid(),
                Birthday = new DateTime(),
                Email = "email@gmail.com",
                LastName = "LastName",
                Name = "Name"
            };

            BuyEvent buyEvent = new BuyEvent(Guid.NewGuid(), client, new EventStatus(product, 10f, 10f, 10), "example buy");
            
            dataRepository.AddEvent(buyEvent);
            Assert.AreEqual(dataRepository.GetAllEvents().Count, 4);
            Assert.IsTrue(dataRepository.GetAllEvents().Contains(buyEvent));
            Assert.ThrowsException<ArgumentException>(() => dataRepository.AddEvent(buyEvent));
        }

        [TestMethod]
        public void DeleteEventTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Assert.AreEqual(dataRepository.GetAllEvents().Count, 3);

            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                Description = "TestDescription"
            };

            Client client = new Client
            {
                Id = Guid.NewGuid(),
                Birthday = new DateTime(),
                Email = "email@gmail.com",
                LastName = "LastName",
                Name = "Name"
            };

            SellEvent sellEvent = new SellEvent(new Guid(), client, new EventStatus(product, 10f, 10f, 10), "example");

            dataRepository.AddEvent(sellEvent);
            Assert.AreEqual(dataRepository.GetAllEvents().Count, 4);
            dataRepository.DeleteEvent(sellEvent);
            Assert.AreEqual(dataRepository.GetAllEvents().Count, 3);
            Assert.IsFalse(dataRepository.GetAllEvents().Contains(sellEvent));
            // rozwiazanie ze strony msdn https://docs.microsoft.com/pl-pl/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019
            Assert.ThrowsException<ArgumentException>(() => dataRepository.DeleteEvent(sellEvent));
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Assert.AreEqual(dataRepository.GetAllEvents().Count, 3);
        }

        [TestMethod]
        public void GetEventTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Assert.AreEqual(dataRepository.GetAllEvents().Count, 3);

            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                Description = "TestDescription"
            };

            Client client = new Client
            {
                Id = Guid.NewGuid(),
                Birthday = new DateTime(),
                Email = "email@gmail.com",
                LastName = "LastName",
                Name = "Name"
            };

            Guid testId = Guid.NewGuid();

            DestroyEvent destroyEvent = new DestroyEvent(testId, client, new EventStatus(product, 10f, 10f, 10), "example");

            dataRepository.AddEvent(destroyEvent);
            Assert.IsTrue(dataRepository.GetAllEvents().Contains(destroyEvent));
            Event getEvent = dataRepository.GetEvent(testId);
            Assert.AreEqual(getEvent, destroyEvent);
        }


        [TestMethod]
        public void UpdateEventTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Assert.AreEqual(dataRepository.GetAllEvents().Count, 3);

            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                Description = "TestDescription"
            };

            Client client = new Client
            {
                Id = Guid.NewGuid(),
                Birthday = new DateTime(),
                Email = "email@gmail.com",
                LastName = "LastName",
                Name = "Name"
            };

            SellEvent sellEvent = new SellEvent(new Guid(), client, new EventStatus(product, 10f, 10f, 10), "example");

            Assert.IsFalse(dataRepository.GetAllEvents().Contains(sellEvent));
            dataRepository.AddEvent(sellEvent);
            Assert.IsTrue(dataRepository.GetAllEvents().Contains(sellEvent));
            sellEvent.Status = new EventStatus(product, 10f, 10f, 100);
            dataRepository.UpdateEvent(sellEvent);
            Assert.IsTrue(dataRepository.GetAllEvents().Contains(sellEvent));
            Assert.ThrowsException<ArgumentException>(() => dataRepository.UpdateEvent(new SellEvent(
                    Guid.NewGuid(),
                    client,
                    new EventStatus(product, 10f, 10f, 10),
                    "example"
                )));
        }
    }
}
