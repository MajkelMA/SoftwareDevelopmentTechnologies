using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassWarehouseLibrary;

namespace WarehouseTest
{
    [TestClass]
    public class AutoFillRandTests
    {
        [TestMethod]
        public void AutoFillTest()
        {
            DataRepository dataRepository = new DataRepository(new AutoFillRand());
            Assert.AreEqual(dataRepository.GetAllClients().Count, 2);
            Assert.AreEqual(dataRepository.GetAllProducts().Count, 2);
            Assert.AreEqual(dataRepository.GetAllEvents().Count, 2);
            Assert.AreEqual(dataRepository.GetAllStatuses().Count, 2);
        }
    }
}
