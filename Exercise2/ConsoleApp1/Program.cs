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
            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Insert \"xml\" or \"own\"\n(press any key to exit)");
                choice = Console.ReadLine();
                if (choice == "xml")
                {
                    #region "XmlSerialization"
                    Console.WriteLine("Insert \"s\" - serialize or \"d\" - deserialize");
                    string choice2 = Console.ReadLine();
                    switch (choice2)
                    {
                        case "s":
                            ClassAPrim classAPrim = new ClassAPrim(1.2f, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
                            ClassBPrim classBPrim = new ClassBPrim(2.2f, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
                            ClassCPrim classCPrim = new ClassCPrim(3.2f, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

                            classAPrim.ClassBProperty = classBPrim;
                            classBPrim.ClassCProperty = classCPrim;
                            classCPrim.ClassAProperty = classAPrim;

                            Console.WriteLine("Insert \"A\" - serialize ClassA, \"B\" - serialize ClassB or \"C\" - serialize ClassC");
                            choice2 = Console.ReadLine();
                            switch (choice2)
                            {
                                case "A":
                                    XmlSerialization<ClassAPrim> xmlClassA = new XmlSerialization<ClassAPrim>("xml-a.xml", classAPrim);
                                    xmlClassA.serialize();
                                    break;
                                case "B":
                                    XmlSerialization<ClassBPrim> xmlClassB = new XmlSerialization<ClassBPrim>("xml-b.xml", classBPrim);
                                    xmlClassB.serialize();
                                    break;
                                case "C":
                                    XmlSerialization<ClassCPrim> xmlClassC = new XmlSerialization<ClassCPrim>("xml-c.xml", classCPrim);
                                    xmlClassC.serialize();
                                    break;
                                default:
                                    Console.WriteLine("Invalid input!");
                                    break;
                            }
                            break;
                        case "d":
                            Console.WriteLine("Insert \"A\" - deserialize ClassA, \"B\" - deserialize ClassB or \"C\" - deserialize ClassC");
                            choice2 = Console.ReadLine();
                            switch (choice2)
                            {
                                case "A":
                                    XmlSerialization<ClassAPrim> xmlClassA = new XmlSerialization<ClassAPrim>("xml-a.xml", new ClassAPrim());
                                    ClassAPrim deserializedClassA = xmlClassA.deserialize();
                                    if (deserializedClassA.ClassBProperty.ClassCProperty.ClassAProperty == deserializedClassA)
                                        Console.WriteLine("Deserialization is completed!");
                                    break;
                                case "B":
                                    XmlSerialization<ClassBPrim> xmlClassB = new XmlSerialization<ClassBPrim>("xml-b.xml", new ClassBPrim());
                                    ClassBPrim deserializedClassB = xmlClassB.deserialize();
                                    if (deserializedClassB.ClassCProperty.ClassAProperty.ClassBProperty == deserializedClassB)
                                        Console.WriteLine("Deserialization is completed!");
                                    break;
                                case "C":
                                    XmlSerialization<ClassCPrim> xmlClassC = new XmlSerialization<ClassCPrim>("xml-c.xml", new ClassCPrim());
                                    ClassCPrim deserializedClassC = xmlClassC.deserialize();
                                    if (deserializedClassC.ClassAProperty.ClassBProperty.ClassCProperty == deserializedClassC)
                                        Console.WriteLine("Deserialization is completed!");
                                    break;
                                default:
                                    Console.WriteLine("Invalid input!");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                    #endregion
                }
                else if (choice == "own")
                {
                    #region "OwnSerialization"
                    Console.WriteLine("Insert \"s\" - serialize or \"d\" - deserialize");
                    string choice2 = Console.ReadLine();
                    switch (choice2)
                    {
                        case "s":
                            ClassA classA = new ClassA(1.2f, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
                            ClassB classB = new ClassB(2.2f, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
                            ClassC classC = new ClassC(3.2f, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

                            classA.ClassBProperty = classB;
                            classB.ClassCProperty = classC;
                            classC.ClassAProperty = classA;

                            Console.WriteLine("Insert \"A\" - serialize ClassA, \"B\" - serialize ClassB or \"C\" - serialize ClassC");
                            choice2 = Console.ReadLine();
                            switch (choice2)
                            {
                                case "A":
                                    using (FileStream s = new FileStream("own-a.txt", FileMode.Create))
                                    {
                                        IFormatter f = new OwnFormatter();
                                        f.Serialize(s, classA);
                                    }
                                    break;
                                case "B":
                                    using (FileStream s = new FileStream("own-b.txt", FileMode.Create))
                                    {
                                        IFormatter f = new OwnFormatter();
                                        f.Serialize(s, classB);
                                    }
                                    break;
                                case "C":
                                    using (FileStream s = new FileStream("own-c.txt", FileMode.Create))
                                    {
                                        IFormatter f = new OwnFormatter();
                                        f.Serialize(s, classC);
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid input!");
                                    break;
                            }
                            break;
                        case "d":
                            Console.WriteLine("Insert \"A\" - deserialize ClassA, \"B\" - deserialize ClassB or \"C\" - deserialize ClassC");
                            choice2 = Console.ReadLine();
                            switch (choice2)
                            {
                                case "A":
                                    using (FileStream s = new FileStream("own-a.txt", FileMode.Open))
                                    {
                                        IFormatter f = new OwnFormatter();
                                        ClassA testClass = (ClassA)f.Deserialize(s);
                                        if (testClass.ClassBProperty.ClassCProperty.ClassAProperty == testClass)
                                            Console.WriteLine("Deserialization is completed!");
                                    }
                                    break;
                                case "B":
                                    using (FileStream s = new FileStream("own-b.txt", FileMode.Open))
                                    {
                                        IFormatter f = new OwnFormatter();
                                        ClassB testClass = (ClassB)f.Deserialize(s);
                                        if (testClass.ClassCProperty.ClassAProperty.ClassBProperty == testClass)
                                            Console.WriteLine("Deserialization is completed!");
                                    }
                                    break;
                                case "C":
                                    using (FileStream s = new FileStream("own-c.txt", FileMode.Open))
                                    {
                                        IFormatter f = new OwnFormatter();
                                        ClassC testClass = (ClassC)f.Deserialize(s);
                                        if (testClass.ClassAProperty.ClassBProperty.ClassCProperty == testClass)
                                            Console.WriteLine("Deserialization is completed!");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid input!");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                    #endregion
                }
                Console.WriteLine("Click any to continue");
                Console.ReadLine();
            } while (choice == "xml" || choice == "own");

            System.Console.Read();
        }
    }
}
