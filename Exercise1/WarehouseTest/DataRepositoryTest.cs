using System;
using System.Collections.Generic;
using ClassWarehouseLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;


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
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillEmpty());
            Assert.AreEqual(0, dataContext.Clients.Count);
            dataRepository.AddClient(new Client("Test", "Testowy", new DateTime(1999, 4, 12)));
            Assert.AreEqual(1, dataContext.Clients.Count);
        }

        [TestMethod]
        public void GetClientTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            Client testClient = dataRepository.GetClient(0);
            Assert.AreEqual("Radoslaw", testClient.Name);
            Assert.AreEqual("Lapciak", testClient.Lastname);
            Assert.AreEqual(new DateTime(1997, 9, 22), testClient.Birthday);
            Assert.AreEqual(typeof(Client), testClient.GetType());
        }

        [TestMethod]
        public void GetAllClientsTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            List<Client> clientsList = dataRepository.GetAllClients();
            Assert.AreEqual(2, clientsList.Count);
            Assert.AreEqual(typeof(List<Client>), clientsList.GetType());
        }

        [TestMethod]
        public void UpdateClientTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            dataRepository.UpdateClient(new Client("Test", "Testowksi", new DateTime(2000, 12, 12)), 0);
            Client updateClient = dataRepository.GetClient(0);
            Assert.AreEqual("Test", updateClient.Name);
            Assert.AreEqual("Testowksi", updateClient.Lastname);
            Assert.AreEqual(new DateTime(2000, 12, 12), updateClient.Birthday);
        }

        [TestMethod]
        public void DeleteClientTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            Client clientToDelete = dataRepository.GetClient(0);
            dataRepository.DeleteClient(clientToDelete);
            Assert.AreEqual(1, dataRepository.GetAllClients().Count);
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
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillEmpty());
            InventoryStatus inventoryStatus = new InventoryStatus(new Product("product"), 10, 10, 10);
            Assert.AreEqual(0, dataRepository.GetAllInventoryStatuses().Count);
            dataRepository.AddInventoryStatus(inventoryStatus);
            Assert.AreEqual(1, dataRepository.GetAllInventoryStatuses().Count);
        }

        [TestMethod]
        public void GetInventoryStatusTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            InventoryStatus inventoryStatus = dataRepository.GetInventoryStatus(0);
            Assert.AreEqual(inventoryStatus.Product.Description, "Product0");
            Assert.AreEqual(inventoryStatus.State, 10);
            Assert.AreEqual(inventoryStatus.NettoPrice, 100);
            Assert.AreEqual(inventoryStatus.Tax, 15);
        }

        [TestMethod]
        public void GetAllInventoryStatusesTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            Assert.AreEqual(dataRepository.GetAllInventoryStatuses().Count, 2);
            Assert.AreEqual(dataRepository.GetAllInventoryStatuses().GetType(), typeof(System.Collections.Generic.List<InventoryStatus>));
        }

        [TestMethod]
        public void DeleteInventoryStatusTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillEmpty());
            Assert.AreEqual(0, dataRepository.GetAllInventoryStatuses().Count);
            InventoryStatus inventoryStatus = new InventoryStatus(new Product("product"), 10, 10, 10);
            dataRepository.AddInventoryStatus(inventoryStatus);
            Assert.AreEqual(1, dataRepository.GetAllInventoryStatuses().Count);
            dataRepository.DeleteInventoryStatus(inventoryStatus);
            Assert.AreEqual(0, dataRepository.GetAllInventoryStatuses().Count);
        }

        [TestMethod]
        public void UpdateInventoryStatusTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            InventoryStatus inventoryStatus = dataRepository.GetInventoryStatus(0);
            Assert.AreEqual(inventoryStatus.Product.Description, "Product0");
            Assert.AreEqual(inventoryStatus.State, 10);
            Assert.AreEqual(inventoryStatus.NettoPrice, 100);
            Assert.AreEqual(inventoryStatus.Tax, 15);
            inventoryStatus = new InventoryStatus(new Product("product"), 10, 10, 10);
            dataRepository.UpdateInventoryStatus(0, inventoryStatus);
            inventoryStatus = dataRepository.GetInventoryStatus(0);
            Assert.AreEqual(inventoryStatus.Product.Description, "product");
            Assert.AreEqual(inventoryStatus.State, 10);
            Assert.AreEqual(inventoryStatus.NettoPrice, 10);
            Assert.AreEqual(inventoryStatus.Tax, 10);
        }

        [TestMethod]
        public void AddInvoiceTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillEmpty());
            Invoice invoiceToAdd = new Invoice(new Client("Test", "Testowski", new DateTime(1997, 9, 22)), new List<Product>());
            dataRepository.AddInvoice(invoiceToAdd);
            Assert.AreEqual(1, dataContext.Invoices.Count);
        }

        [TestMethod]
        public void GetInvoiceTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            Invoice invoiceGetTest = dataRepository.GetInvoice(0);
            Assert.AreEqual(dataContext.Invoices[0].Products, invoiceGetTest.Products);
            Assert.AreEqual(dataContext.Invoices[0].WarehouseClient, invoiceGetTest.WarehouseClient);
            Assert.AreEqual(typeof(Invoice), invoiceGetTest.GetType());
        }

        [TestMethod]
        public void GetAllInvoicesTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            ObservableCollection<Invoice> allInvoices = dataRepository.GetAllInvoices();
            Assert.AreEqual(2, allInvoices.Count);
            Assert.AreEqual(typeof(ObservableCollection<Invoice>), allInvoices.GetType());
        }

        [TestMethod]
        public void DeleteInvoiceTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            Invoice invoiceToDelete = dataRepository.GetInvoice(0);
            dataRepository.DeleteInvoice(invoiceToDelete);
            Assert.AreEqual(1, dataRepository.GetAllInvoices().Count);
        }

        [TestMethod]
        public void UpdateInvoiceTest()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new AutoFillFull());
            List<Product> productsList = new List<Product>();
            Client newClientInInvoice = new Client("Test", "Testowski", new DateTime(1995, 5, 12));
            dataRepository.UpdateInvoice(0, new Invoice(newClientInInvoice, productsList));
            Assert.AreEqual("Test", dataRepository.GetInvoice(0).WarehouseClient.Name);
            Assert.AreEqual("Testowski", dataRepository.GetInvoice(0).WarehouseClient.Lastname);
            Assert.AreEqual(new DateTime(1995, 5, 12), dataRepository.GetInvoice(0).WarehouseClient.Birthday);
        }
    }
}
