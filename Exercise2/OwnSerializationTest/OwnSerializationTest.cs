using System;
using System.IO;
using System.Runtime.Serialization;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OwnSerialization;

namespace UnitTestProject1
{
    [TestClass]
    public class OwnSerializationTest
    {
        [TestMethod]
        public void ClassASerializationATest()
        {
            ClassA classA = new ClassA(1.2f, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
            ClassB classB = new ClassB(2.2f, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2f, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new OwnFormatter();
                f.Serialize(s, classA);
            }

            string result = File.ReadAllText("test.txt");
            Assert.AreEqual(result, "ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|ClassLibrary.ClassA|1|System.Single=FloatProperty=1.20|System.DateTime=DateTimeProperty=31.12.1996 23:00:00|System.String=StringProperty=\"TestA\"|ClassLibrary.ClassB=ClassBProperty=2\n"
                                  + "ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|ClassLibrary.ClassB|2|System.Single=FloatProperty=2.20|System.DateTime=DateTimeProperty=31.01.1997 23:00:00|System.String=StringProperty=\"testB\"|ClassLibrary.ClassC=ClassCProperty=3\n"
                                  + "ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|ClassLibrary.ClassC|3|System.Single=FloatProperty=3.20|System.DateTime=DateTimeProperty=28.02.1997 23:00:00|System.String=StringProperty=\"testC\"|ClassLibrary.ClassA=ClassAProperty=1\n"
            );
            File.Delete("test.txt");
        }

        [TestMethod]
        public void ClassBSerializationTest()
        {
            ClassA classA = new ClassA(1.2f, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
            ClassB classB = new ClassB(2.2f, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2f, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new OwnFormatter();
                f.Serialize(s, classB);
            }

            string result = File.ReadAllText("test.txt");
            Assert.AreEqual(result, "ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|ClassLibrary.ClassB|1|System.Single=FloatProperty=2.20|System.DateTime=DateTimeProperty=31.01.1997 23:00:00|System.String=StringProperty=\"testB\"|ClassLibrary.ClassC=ClassCProperty=2\n"
                                  + "ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|ClassLibrary.ClassC|2|System.Single=FloatProperty=3.20|System.DateTime=DateTimeProperty=28.02.1997 23:00:00|System.String=StringProperty=\"testC\"|ClassLibrary.ClassA=ClassAProperty=3\n"
                                  + "ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|ClassLibrary.ClassA|3|System.Single=FloatProperty=1.20|System.DateTime=DateTimeProperty=31.12.1996 23:00:00|System.String=StringProperty=\"TestA\"|ClassLibrary.ClassB=ClassBProperty=1\n"
            );
            File.Delete("test.txt");
        }

        [TestMethod]
        public void ClassCSerializationTest()
        {
            ClassA classA = new ClassA(1.2f, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
            ClassB classB = new ClassB(2.2f, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2f, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new OwnFormatter();
                f.Serialize(s, classC);
            }

            string result = File.ReadAllText("test.txt");
            Assert.AreEqual(result, "ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|ClassLibrary.ClassC|1|System.Single=FloatProperty=3.20|System.DateTime=DateTimeProperty=28.02.1997 23:00:00|System.String=StringProperty=\"testC\"|ClassLibrary.ClassA=ClassAProperty=2\n"
                                  + "ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|ClassLibrary.ClassA|2|System.Single=FloatProperty=1.20|System.DateTime=DateTimeProperty=31.12.1996 23:00:00|System.String=StringProperty=\"TestA\"|ClassLibrary.ClassB=ClassBProperty=3\n"
                                  + "ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|ClassLibrary.ClassB|3|System.Single=FloatProperty=2.20|System.DateTime=DateTimeProperty=31.01.1997 23:00:00|System.String=StringProperty=\"testB\"|ClassLibrary.ClassC=ClassCProperty=1\n"
            );
            File.Delete("test.txt");
        }

        [TestMethod]
        public void ClassADeserializationATest()
        {
            ClassA classA = new ClassA(1.2f, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
            ClassB classB = new ClassB(2.2f, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2f, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new OwnFormatter();
                f.Serialize(s, classA);
            }

            using (FileStream s = new FileStream("test.txt", FileMode.Open))
            {
                IFormatter f = new OwnFormatter();
                ClassA testClass = (ClassA)f.Deserialize(s);
                Assert.IsTrue(testClass.ClassBProperty.ClassCProperty.ClassAProperty == testClass);
            }

            File.Delete("test.txt");
        }

        [TestMethod]
        public void ClassBDeserializationTest()
        {
            ClassA classA = new ClassA(1.2f, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
            ClassB classB = new ClassB(2.2f, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2f, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new OwnFormatter();
                f.Serialize(s, classB);
            }

            using (FileStream s = new FileStream("test.txt", FileMode.Open))
            {
                IFormatter f = new OwnFormatter();
                ClassB testClass = (ClassB)f.Deserialize(s);
                Assert.IsTrue(testClass.ClassCProperty.ClassAProperty.ClassBProperty == testClass);
            }

            File.Delete("test.txt");
        }

        [TestMethod]
        public void ClassCDeserializationTest()
        {
            ClassA classA = new ClassA(1.2f, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
            ClassB classB = new ClassB(2.2f, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2f, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new OwnFormatter();
                f.Serialize(s, classC);
            }

            using (FileStream s = new FileStream("test.txt", FileMode.Open))
            {
                IFormatter f = new OwnFormatter();
                ClassC testClass = (ClassC)f.Deserialize(s);
                Assert.IsTrue(testClass.ClassAProperty.ClassBProperty.ClassCProperty == testClass);
            }

            File.Delete("test.txt");
        }
    }
}
