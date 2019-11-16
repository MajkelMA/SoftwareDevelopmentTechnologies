using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serialization;

namespace SerializationTest
{
    [TestClass]
    public class RecursionSerializationTest
    {
        [TestMethod]
        public void XmlSerializationTest()
        {
            TestClass1 testClass = new TestClass1();

            //ObjectIDGenerator idGenerator = new ObjectIDGenerator();
            //string result = testClass.Serialize(idGenerator);
            //File.WriteAllText("own-recursive-serialization", result);


            //var serializer = new DataContractSerializer(testClass.GetType());
            //using (FileStream stream = File.Create("Test.Xml"))
            //{
            //    serializer.WriteObject(stream, testClass);
            //}

            //XmlSerializer serializer = new XmlSerializer(typeof(TestClass1));
            //TextWriter writer = new StreamWriter("test-class-test.xml");
            //serializer.Serialize(writer, testClass);
            //writer.Close();


            //XmlSerialization<TestClass1> xmlSerialization = new XmlSerialization<TestClass1>("xml-data-context.xml", testClass);
            //xmlSerialization.serialize();

            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(TestClass1), null, 655360, true, true, null);
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n"
            };
            using (FileStream fileStream = new FileStream("xml-r", FileMode.Create, FileAccess.Write))
            using (XmlWriter xmlWriter = XmlWriter.Create(fileStream, xmlWriterSettings))
            {
                dataContractSerializer.WriteObject(xmlWriter, testClass);
            }
            //testClass = xmlSerialization.deserialize();

        }
    }
}
