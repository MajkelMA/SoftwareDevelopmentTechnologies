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

                    //XmlSerialization<ClassA> xmlSerialization = new XmlSerialization<ClassA>("xml-data-context.xml", classA);
                    switch (choice2)
                    {
                        case "s":
                            //xmlSerialization.serialize();

                            break;
                        case "d":
                            //classA = xmlSerialization.deserialize();

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

                            break;
                        case "d":

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
