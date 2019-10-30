using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassWarehouseLibrary;
using System;

namespace WarehouseTest
{
    [TestClass]
    public class ProductCRUDTests
    {
        [TestMethod]
        public void AddProductTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.AreEqual(dataRepository.GetAllProducts().Count, 2);
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                Description = "TestDescription"
            };
            dataRepository.AddProduct(product);
            Assert.AreEqual(dataRepository.GetAllProducts().Count, 3);
        }

        [TestMethod]
        public void DeleteProduct1Test()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.AreEqual(dataRepository.GetAllProducts().Count, 2);
            Guid testId = Guid.NewGuid();
            Product product = new Product
            {
                Id = testId,
                Name = "TestName",
                Description = "TestDescription"
            };
            dataRepository.AddProduct(product);
            Assert.AreEqual(dataRepository.GetAllProducts().Count, 3);
            dataRepository.DeleteProduct(testId);
            Assert.AreEqual(dataRepository.GetAllProducts().Count, 2);
            // rozwiazanie ze strony msdn https://docs.microsoft.com/pl-pl/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019
            Assert.ThrowsException<ArgumentException>(() => dataRepository.DeleteProduct(testId));
        }

        [TestMethod]
        public void DeleteProduct2Test()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.AreEqual(dataRepository.GetAllProducts().Count, 2);
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                Description = "TestDescription"
            };
            dataRepository.AddProduct(product);
            Assert.AreEqual(dataRepository.GetAllProducts().Count, 3);
            dataRepository.DeleteProduct(product);
            Assert.AreEqual(dataRepository.GetAllProducts().Count, 2);
            // rozwiazanie ze strony msdn https://docs.microsoft.com/pl-pl/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019
            Assert.ThrowsException<ArgumentException>(() => dataRepository.DeleteProduct(product));
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.AreEqual(dataRepository.GetAllProducts().Count, 2);
            Guid testId = Guid.NewGuid();
            Product product = new Product
            {
                Id = testId,
                Name = "TestName",
                Description = "TestDescription"
            };
            dataRepository.AddProduct(product);
            Product newProduct = new Product
            {
                Id = testId,
                Name = "NewTestName",
                Description = "NewTestDescription"
            };
            Assert.AreEqual(product.Id, newProduct.Id);
            dataRepository.UpdateProduct(newProduct);
            Assert.AreEqual(testId, dataRepository.GetProduct(testId).Id);
            Assert.AreEqual("NewTestDescription", dataRepository.GetProduct(testId).Description);
            Assert.AreEqual("NewTestName", dataRepository.GetProduct(testId).Name);
            newProduct.Id = Guid.NewGuid();
            Assert.ThrowsException<ArgumentException>(() => dataRepository.UpdateProduct(newProduct));
        }

        [TestMethod]
        public void GetAllProductsTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.AreEqual(dataRepository.GetAllProducts().Count, 2);
        }

        [TestMethod]
        public void GetProductTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Guid testId = Guid.NewGuid();
            Product product = new Product
            {
                Id = testId,
                Name = "TestName",
                Description = "TestDescription"
            };
            dataRepository.AddProduct(product);
            Assert.AreEqual(dataRepository.GetProduct(testId), product);
        }
    }
}
