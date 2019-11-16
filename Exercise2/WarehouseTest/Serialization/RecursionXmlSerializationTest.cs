using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WarehouseTest
{
    [TestClass]
    public class RecursionXmlSerializationTest
    {
        [TestMethod]
        public void XmlSerializationTest()
        {
            TestClass2 testClass2 = new TestClass2();
            TestClass1 testClass = new TestClass1()
            {
                TestClass2 = testClass2
            };

            testClass2.TestClass1 = testClass;

            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(TestClass1), null, 655360, true, true, null);
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n"
            };
            using (FileStream fileStream = new FileStream("xml-r.xml", FileMode.Create, FileAccess.Write))
            using (XmlWriter xmlWriter = XmlWriter.Create(fileStream, xmlWriterSettings))
            {
                dataContractSerializer.WriteObject(xmlWriter, testClass);
            }

        }
    }
}
