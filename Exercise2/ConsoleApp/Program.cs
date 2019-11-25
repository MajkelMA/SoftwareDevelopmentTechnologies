using ClassLibrary;
using OwnSerialization;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassA classA = new ClassA(1.2f, new DateTime(1997, 1, 1, 0, 0, 0), "testf=frwgdrdetg", null);
            ClassB classB = new ClassB(2.2f, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2f, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new OwnFormatter();
                f.Serialize(s, classA);
            }
            using (FileStream s = new FileStream("test.txt", FileMode.Open))
            {
                IFormatter f = new OwnFormatter();
                ClassA testClass = (ClassA)f.Deserialize(s);
                System.Console.WriteLine(testClass.StringProperty);
            }
            System.Console.Read();

        }
    }
}
