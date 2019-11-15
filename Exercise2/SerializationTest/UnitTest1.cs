using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SerializationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void XmlSerializationTest()
        {
            TestClass1 testClass = new TestClass1();
            var serializer = new DataContractSerializer(testClass.GetType());
            using (FileStream stream = File.Create("Test.Xml"))
            {
                serializer.WriteObject(stream, testClass);
            }

            //XmlSerializer serializer = new XmlSerializer(typeof(TestClass1));
            //TextWriter writer = new StreamWriter("test-class-test.xml");
            //serializer.Serialize(writer, testClass);
            //writer.Close();
        }
    }
}
