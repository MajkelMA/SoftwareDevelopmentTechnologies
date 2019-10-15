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
            Assert.AreEqual(dataContext.Invoices[0].Produscts, invoiceGetTest.Produscts);
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
