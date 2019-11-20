using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WarehouseTest
{
    [TestClass]
    public class OwnRecursionSerializationTest
    {
        [TestMethod]
        public void RecursionSerializationTest()
        {
            TestClass1 test1 = new TestClass1();
            TestClass2 test2 = new TestClass2();
            TestClass1 test3 = new TestClass1();
            TestClass2 test4 = new TestClass2();

            test1.TestClass2 = test2;
            test2.TestClass1 = test3;
            test3.TestClass2 = test4;
            test4.TestClass1 = test1;

            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            string result = test1.Serialize(idGenerator);

            Assert.AreEqual(result, 
                                    "WarehouseTest.TestClass1|1|description1|2|\n"
                                  + "WarehouseTest.TestClass2|2|description2|3|\n"
                                  + "WarehouseTest.TestClass1|3|description1|4|\n"
                                  + "WarehouseTest.TestClass2|4|description2|1|\n"
                           );
        }

        [TestMethod]
        public void RecursionDeserializationTest()
        {
            TestClass1 test1 = new TestClass1();
            TestClass2 test2 = new TestClass2();
            TestClass1 test3 = new TestClass1();
            TestClass2 test4 = new TestClass2();

            test1.TestClass2 = test2;
            test2.TestClass1 = test3;
            test3.TestClass2 = test4;
            test4.TestClass1 = test1;

            Assert.AreEqual(test1.TestClass2.TestClass1.TestClass2.TestClass1, test1);
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            string result = test1.Serialize(idGenerator);

            idGenerator = new ObjectIDGenerator();
            TestClass1 deserialized = new TestClass1();
            deserialized.Deserialize(result, idGenerator, new Dictionary<long, object>());

            Assert.AreEqual(deserialized.TestClass2.TestClass1.TestClass2.TestClass1, deserialized);
        }
    }
}
