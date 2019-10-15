using System;
using ClassWarehouseLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WarehouseTest
{
    [TestClass]
    public class DataRepositoryTest
    {
        [TestMethod]
        public void DataRepositoryConstructorTest()
        {
        }

        [TestMethod]
        public void AddClientTest()
        {
            DataContext _DataContext = new DataContext();
            DataRepository _DataRepository = new DataRepository(_DataContext, new AutoFillEmpty());
            Assert.AreEqual(0, _DataContext.Clients.Count);
            _DataRepository.AddClient(new Client("Test", "Testowy", new DateTime(1999, 4, 12)));
            Assert.AreEqual(1, _DataContext.Clients.Count);
        }

        [TestMethod]
        public void GetClientTest()
        {
            DataContext _DataContext = new DataContext();
            DataRepository _DataRepository = new DataRepository(_DataContext, new AutoFillFull());
            Client testClient = _DataRepository.GetClient(0);
            Assert.AreEqual("Radoslaw", testClient.Name);
            Assert.AreEqual("Lapciak", testClient.Lastname);
            Assert.AreEqual(new DateTime(1997, 9, 22), testClient.Birthdey);
        }

        [TestMethod]
        public void GetAllClientsTest()
        {

        }

        [TestMethod]
        public void UpdateClientTest()
        {

        }

        [TestMethod]
        public void DeleteClientTest()
        {

        }

        [TestMethod]
        public void AddProductTest()
        {

        }

        [TestMethod]
        public void GetProductTest()
        {

        }

        [TestMethod]
        public void GetAllProductsTest()
        {

        }

        [TestMethod]
        public void DeleteProductTest()
        {

        }

        [TestMethod]
        public void UpdateProductTest()
        {

        }

        [TestMethod]
        public void AddInventoryStatusTest()
        {

        }

        [TestMethod]
        public void GetInventoryStatusTest()
        {

        }

        [TestMethod]
        public void GetAllInventoryStatusesTest()
        {

        }

        [TestMethod]
        public void DeleteInventoryStatusTest()
        {

        }

        [TestMethod]
        public void UpdateInventoryStatusTest()
        {

        }

        [TestMethod]
        public void AddInvoiceTest()
        {

        }

        [TestMethod]
        public void GetInvoiceTest()
        {

        }

        [TestMethod]
        public void GetAllInvoicesTest()
        {

        }

        [TestMethod]
        public void DeleteInvoiceTest()
        {

        }

        [TestMethod]
        public void UpdateInvoiceTest()
        {

        }
    }
}
