using ClassWarehouseLibrary;
using ClassWarehouseLibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WarehouseTest
{
    [TestClass]
    public class InvoiceCRUDTests
    {
        [TestMethod]
        public void AddInvoiceTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.AreEqual(dataRepository.GetAllInvoices().Count, 2);

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

            Invoice invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                Status = new ItemStatus(product, 10f, 10f, 10),
                WarehouseClient = client
            };

            dataRepository.AddInvoice(invoice);
            Assert.AreEqual(dataRepository.GetAllInvoices().Count, 3);
            Assert.IsTrue(dataRepository.GetAllInvoices().Contains(invoice));
            Assert.ThrowsException<ArgumentException>(() => dataRepository.AddInvoice(invoice));
        }

        [TestMethod]
        public void DeleteInvoiceTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.AreEqual(dataRepository.GetAllInvoices().Count, 2);

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

            Invoice invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                Status = new ItemStatus(product, 10f, 10f, 10),
                WarehouseClient = client
            };

            dataRepository.AddInvoice(invoice);
            Assert.AreEqual(dataRepository.GetAllInvoices().Count, 3);
            dataRepository.DeleteInvoice(invoice);
            Assert.AreEqual(dataRepository.GetAllInvoices().Count, 2);
            Assert.IsFalse(dataRepository.GetAllInvoices().Contains(invoice));
            // rozwiazanie ze strony msdn https://docs.microsoft.com/pl-pl/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019
            Assert.ThrowsException<ArgumentException>(() => dataRepository.DeleteInvoice(invoice));
        }

        [TestMethod]
        public void GetAllInvoicesTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.AreEqual(dataRepository.GetAllInvoices().Count, 2);
        }

        [TestMethod]
        public void GetInvoiceTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.AreEqual(dataRepository.GetAllInvoices().Count, 2);

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

            Invoice invoice = new Invoice
            {
                Id = testId,
                Status = new ItemStatus(product, 10f, 10f, 10),
                WarehouseClient = client
            };

            dataRepository.AddInvoice(invoice);
            Assert.IsTrue(dataRepository.GetAllInvoices().Contains(invoice));
            Invoice getInvoice = dataRepository.GetInvoice(testId);
            Assert.AreEqual(getInvoice, invoice);
        }


        [TestMethod]
        public void UpdateInvoiceTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.AreEqual(dataRepository.GetAllInvoices().Count, 2);

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

            Invoice invoice = new Invoice
            {
                Id = Guid.NewGuid(),
                Status = new ItemStatus(product, 10f, 10f, 10),
                WarehouseClient = client
            };

            Assert.IsFalse(dataRepository.GetAllInvoices().Contains(invoice));
            dataRepository.AddInvoice(invoice);
            Assert.IsTrue(dataRepository.GetAllInvoices().Contains(invoice));
            invoice.Status = new ItemStatus(product, 10f, 10f, 100);
            dataRepository.UpdateInvoice(invoice);
            Assert.IsTrue(dataRepository.GetAllInvoices().Contains(invoice));
            Assert.ThrowsException<ArgumentException>(() => dataRepository.UpdateInvoice(new Invoice
            {
                Id = Guid.NewGuid(),
                Status = new ItemStatus(product, 10f, 10f, 10),
                WarehouseClient = client
            }));
        }
    }
}
