using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassWarehouseLibrary.Entities;
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
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.AreEqual(2, dataRepository.GetAllStatuses().Count);
        }

        [TestMethod]
        public void GetStautsTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Guid id = dataRepository.GetAllStatuses()[0].Id;

            Status status = dataRepository.GetStatus(id);
            Assert.IsTrue(status is ItemStatus);
            Assert.AreEqual(11, status.Amount);
            Assert.AreEqual(11.1, status.NettoPrice, 0.0001);
            Assert.AreEqual(11.1, status.Tax, 0.0001);
        }


        [TestMethod]
        public void AddStatusTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillEmpty());
            dataRepository.AddStatus(new ItemStatus(new Product
            {
                Id =  new Guid(),
                Description = "description",
                Name = "name"
            }, 10, 20, 10));
            Assert.AreEqual(1, dataRepository.GetAllStatuses().Count);
        }

        [TestMethod]
        public void UpdateStatusTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Status status = new ItemStatus(new Product
            {
                Id = new Guid(),
                Description = "description",
                Name = "milk"
            }, 3.99f , 1, 15);

            Guid statusesIdToUpdate = dataRepository.GetAllStatuses()[0].Id;
            dataRepository.UpdateStatus(statusesIdToUpdate, status);

            Status changedStatus = dataRepository.GetStatus(statusesIdToUpdate);
            Assert.IsTrue(changedStatus is ItemStatus);
            Assert.AreEqual(3.99f, changedStatus.NettoPrice, 0.0001);
        }

        [TestMethod]
        public void DeleteStatusTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Status statusToDelete = dataRepository.GetAllStatuses()[0];
            dataRepository.DeleteStatus(statusToDelete);
            Assert.AreEqual(1, dataRepository.GetAllStatuses().Count);
        }
    }
}
