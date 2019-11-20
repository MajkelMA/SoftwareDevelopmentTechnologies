using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassWarehouseLibrary;
using System;

namespace WarehouseTest
{
    [TestClass]
    public class StatusCRUDTests
    {
        [TestMethod]
        public void GetAllStatusesTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Assert.AreEqual(2, dataRepository.GetAllStatuses().Count);
        }

        [TestMethod]
        public void GetStautsTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Guid id = dataRepository.GetAllStatuses()[0].Id;
            Status status = dataRepository.GetStatus(id);
            Assert.IsTrue(status is Status);
            Assert.AreEqual(4, status.Amount);
            Assert.AreEqual(4.4, status.NettoPrice, 0.0001);
            Assert.AreEqual(4.4, status.Tax, 0.0001);

            dataRepository.AddStatus(new Status(new Product
            {
                Id = Guid.NewGuid(),
                Description = "description",
                Name = "name"
            }, 10, 10, 10));

            status = dataRepository.GetAllStatuses()[dataRepository.GetAllStatuses().Count-1];
            Assert.IsTrue(status is Status);
        }


        [TestMethod]
        public void AddStatusTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillEmpty(), new DataContext());
            dataRepository.AddStatus(new Status(new Product
            {
                Id = Guid.NewGuid(),
                Description = "description",
                Name = "name"
            }, 10, 20, 10));
            Assert.AreEqual(1, dataRepository.GetAllStatuses().Count);
        }

        [TestMethod]
        public void UpdateStatusTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Guid statusesIdToUpdate = dataRepository.GetAllStatuses()[0].Id;

            Status status = new Status(new Product
            {
                Id = Guid.NewGuid(),
                Description = "description",
                Name = "milk"
            }, 3.99f, 1, 15);

            status.Id = statusesIdToUpdate;
            dataRepository.UpdateStatus(status);

            Status changedStatus = dataRepository.GetStatus(statusesIdToUpdate);
            Assert.IsTrue(changedStatus is Status);
            Assert.AreEqual(3.99f, changedStatus.NettoPrice, 0.0001);
        }

        [TestMethod]
        public void DeleteStatusTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Status statusToDelete = dataRepository.GetAllStatuses()[0];
            dataRepository.DeleteStatus(statusToDelete);
            Assert.AreEqual(1, dataRepository.GetAllStatuses().Count);
        }

        [TestMethod]
        public void AddStatusNoneUniqueIdExceptionTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Guid nonUniqueId = dataRepository.GetAllStatuses()[0].Id;
            Status statusToAdd = new Status(new Product
            {
                Id = Guid.NewGuid(),
                Name = "Milk",
                Description = "from cow"
            }, 11.1f, 1, 15);

            statusToAdd.Id = nonUniqueId;

            Assert.ThrowsException<ArgumentException>(() => dataRepository.AddStatus(statusToAdd));
        }

        [TestMethod]
        public void AddStatusNoneUniqueProductExceptionTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Product product = dataRepository.GetAllStatuses()[0].Product;
            Status status = new Status(product, 15.3f, 12, 30);
            Assert.ThrowsException<ArgumentException>(() => dataRepository.AddStatus(status));
        }

        [TestMethod]
        public void GetStatusReturnsNull()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Status status =  dataRepository.GetStatus(new Guid());
            Assert.AreEqual(null, status);
        }

        [TestMethod]
        public void DeleteStatusIdExceptionTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Status statusInfo = dataRepository.GetAllStatuses()[0];
            Status newStatusInfo = new Status(statusInfo.Product, 10, 10, 1)
            {
                Id = Guid.NewGuid()
        };

            Assert.ThrowsException<ArgumentException>(() => dataRepository.UpdateStatus(newStatusInfo));
        }   

        [TestMethod]
        public void UpdateStatusNoneUniqueProductExceptionTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Product product = dataRepository.GetAllStatuses()[0].Product;
            Guid idStatusToUpdate = dataRepository.GetAllStatuses()[1].Id;
            Status newStatusInfo = new Status(product, 10, 10, 111)
            {
                Id = idStatusToUpdate
            };

            Assert.ThrowsException<ArgumentException>(() => dataRepository.UpdateStatus(newStatusInfo));
        }

        [TestMethod]
        public void DeleteStatusExceptionTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull(), new DataContext());
            Status status = dataRepository.GetAllStatuses()[0];
            Status statusToDelete = new Status(status.Product, 10, 10, 24)
            {
                Id = Guid.NewGuid()
        };
            Assert.ThrowsException<ArgumentException>(() => dataRepository.DeleteStatus(statusToDelete));
        }
    }
}
