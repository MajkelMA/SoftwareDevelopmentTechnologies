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
            Assert.AreEqual(new DateTime(1997, 9, 22), testClient.Birthday);
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
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillEmpty());
            Assert.AreEqual(0, dataRepository.GetAllProducts().Count);
            dataRepository.AddProduct(new Product("product"), 1);
            Assert.AreEqual(1, dataRepository.GetAllProducts().Count);
        }

        [TestMethod]
        public void GetProductTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            Assert.AreEqual(2, dataRepository.GetAllProducts().Count);
            Product product = dataRepository.GetProduct(0);
            Assert.AreEqual("Product0", product.Description);
            Assert.AreEqual(product.GetType(), typeof(Product));
        }

        [TestMethod]
        public void GetAllProductsTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            Assert.AreEqual(2, dataRepository.GetAllProducts().Count);
            Assert.AreEqual(dataRepository.GetAllProducts().GetType(), typeof(System.Collections.Generic.Dictionary<int, Product>));
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillEmpty());
            Assert.AreEqual(0, dataRepository.GetAllProducts().Count);
            Product product = new Product("product");
            dataRepository.AddProduct(product, 1);
            Assert.AreEqual(1, dataRepository.GetAllProducts().Count);
            dataRepository.DeleteProduct(1);
            Assert.AreEqual(0, dataRepository.GetAllProducts().Count);
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            Assert.AreEqual(dataRepository.GetProduct(0).Description, "Product0");
            Product product = new Product("new product");
            dataRepository.UpdateProduct(0, product);
            Assert.AreEqual(dataRepository.GetProduct(0).Description, "new product");
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
