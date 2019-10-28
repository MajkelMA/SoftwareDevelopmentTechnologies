using ClassWarehouseLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassWarehouseLibrary.Entities;
using System;


namespace WarehouseTest
{

    [TestClass]
    public class ClientCRUDTests
    {
        [TestMethod]
        public void GetAllClientTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.AreEqual(2, dataRepository.GetAllClients().Count);
        }

        [TestMethod]
        public void AddClientTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.AreEqual(2, dataRepository.GetAllClients().Count);
            
            dataRepository.AddClient(new Client
            {
                Id = new Guid(),
                Name = "Radoslaw",
                LastName = "Lapciak",
                Birthday = new DateTime(1997, 9, 22),
                Email = "test@test.test"
            });

            Assert.AreEqual(3, dataRepository.GetAllClients().Count);
        }

        [TestMethod]
        public void GetClientByGuidTest()
        {
            Guid clientId = new Guid();
            Client clientToAdd = new Client
            {
                Id = clientId,
                Name = "Radoslaw",
                LastName = "Lapciak",
                Birthday = new DateTime(1997, 9, 22),
                Email = "test@test.tet"
            };
            DataRepository dataRepository = new DataRepository(new AutoFillEmpty());
            dataRepository.AddClient(clientToAdd);
            Client client = dataRepository.GetClient(clientId);
            Assert.AreEqual("Radoslaw", client.Name);
            Assert.AreEqual("Lapciak", client.LastName);
            Assert.AreEqual(new DateTime(1997, 9, 22), client.Birthday);
        }

        [TestMethod]
        public void GetClientByEmailTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Client client = dataRepository.GetClient("ex@example.com");
            Assert.AreEqual("Name1", client.Name);
            Assert.AreEqual("LastName1", client.LastName);
            Assert.AreEqual(new DateTime(1000, 1, 1), client.Birthday);
        }

        [TestMethod]
        public void UpdateClientByGuidTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillEmpty());
            Guid clientId = new Guid();
            Client client = new Client
            {
                Id = clientId,
                Name = "test",
                LastName = "test",
                Birthday = new DateTime(1000, 10, 10),
                Email = "test@example.com"
            };

            dataRepository.AddClient(client);

            client = new Client
            {
                Id = clientId,
                Name = "Test2",
                LastName = "test2",
                Birthday = new DateTime(2000, 1, 1),
                Email = "test2@example.com"
            };

            dataRepository.UpdateClient(clientId, client);
            client = dataRepository.GetClient(clientId);

            Assert.AreEqual("Test2", client.Name);
            Assert.AreEqual("test2", client.LastName);
            Assert.AreEqual(new DateTime(2000, 1, 1), client.Birthday);
            Assert.AreEqual("test2@example.com", client.Email);
        }

        [TestMethod]
        public void UpdateClentByEmailTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Client client = new Client
            {
                Name = "Radoslaw",
                LastName = "Lapciak",
                Birthday = new DateTime(1997, 9, 22),
                Email = "ex@example.com"
            };

            dataRepository.UpdateClient("ex@example.com", client);
            Client updatedClient = dataRepository.GetClient("ex@example.com");
            Assert.AreEqual("Radoslaw", updatedClient.Name);
            Assert.AreEqual("Lapciak", updatedClient.LastName);
            Assert.AreEqual(new DateTime(1997, 9, 22), updatedClient.Birthday);

        }

        [TestMethod]
        public void DeleteClientTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Client clientToDelete = dataRepository.GetClient("ex@example.com");
            dataRepository.DeleteClient(clientToDelete);
            Assert.AreEqual(1, dataRepository.GetAllClients().Count);
        }

        [TestMethod]
        public void AddClientNoneUniqueIdException()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillEmpty());
            Guid clientId = new Guid();
            Client clientToAdd = new Client
            {
                Id = clientId,
                Name = "test",
                LastName = "testowski",
                Birthday = new DateTime(2000, 10, 10),
                Email = "example@eexample.com"
            };

            dataRepository.AddClient(clientToAdd);
            clientToAdd = new Client
            {
                Id = clientId,
                Name = "test",
                LastName = "testowski2",
                Birthday = new DateTime(1000, 10, 10),
                Email = "kl@examplecom"
            };
            // rozwiazanie ze strony msdn https://docs.microsoft.com/pl-pl/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019
            Assert.ThrowsException<ArgumentException>(() => dataRepository.AddClient(clientToAdd));
        }

        [TestMethod]
        public void AddClientNoneUniqueEmailException()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.ThrowsException<ArgumentException>(() => dataRepository.AddClient(new Client
            {
                Id = new Guid(),
                Name = "test",
                LastName = "testtowski",
                Birthday = new DateTime(2000, 10, 10),
                Email = "ex@example.com"
            }));
        }

        [TestMethod]
        public void GetClientByIdException()
        {
            Guid clientsIdToFind = new Guid();
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.ThrowsException<ArgumentException>(() => dataRepository.GetClient(clientsIdToFind));
        }

        [TestMethod]
        public void GetClientByEmailException()
        {
            String clientsEmailToFind = "test@test.test";
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.ThrowsException<ArgumentException>(() => dataRepository.GetClient(clientsEmailToFind));
        }

        [TestMethod]
        public void UpdateClientByIdException()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Guid clientId = new Guid();
            Assert.ThrowsException<ArgumentException>(() => dataRepository.UpdateClient(new Guid(), new Client
            {
                Id = clientId,
                Name = "test",
                LastName = "test",
                Birthday = new DateTime(10, 10, 10),
                Email = "test@test.com"
            }));
        }

        [TestMethod]
        public void UpdateClientByEmailException()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.ThrowsException<ArgumentException>(() => dataRepository.UpdateClient("test@test.test", new Client
            {
                Id = new Guid(),
                Name = "test",
                LastName = "Testowski",
                Birthday = new DateTime(20, 10, 10),
                Email = "vg@t.pl"
            }));
        }

        [TestMethod]
        public void DeleteClientExceptionTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillFull());
            Assert.ThrowsException<ArgumentException>(() => dataRepository.DeleteClient(new Client
            {
                Id = new Guid(),
                Name = "test",
                LastName = "testowski",
                Birthday = new DateTime(1997, 9, 22),
                Email = "test@test.test"
            }));
        }
    }

}
