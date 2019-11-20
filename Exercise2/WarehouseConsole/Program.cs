using ClassWarehouseLibrary;
using Serialization;
using System;
using System.Runtime.Serialization;

namespace WarehouseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            do
            {
                DataContext dataContext = new DataContext();
                DataRepository dataRepository = new DataRepository(new AutoFillFull(), dataContext);
                Console.Clear();
                Console.WriteLine("Insert \"xml\" or \"own\"\n(press any key to exit)");
                choice = Console.ReadLine();
                if (choice == "xml")
                {
                    #region "XmlSerialization"
                    Console.WriteLine("Insert \"s\" - serialize or \"d\" - deserialize");
                    string choice2 = Console.ReadLine();

                    XmlSerialization<DataContext> xmlSerialization = new XmlSerialization<DataContext>("xml-data-context.xml", dataContext);
                    switch (choice2)
                    {
                        case "s":
                            xmlSerialization.serialize();
                            break;
                        case "d":
                            dataContext = xmlSerialization.deserialize();
                            Console.WriteLine("Deserialized file:\n" + dataContext);
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
                    string result;
                    switch (choice2)
                    {
                        case "s":
                            ObjectIDGenerator idGenerator = new ObjectIDGenerator();
                            result = dataContext.Serialize(idGenerator);
                            WriteReadFile.Write("own-serialization", result);
                            //File.WriteAllText("own-serialization", result);
                            break;
                        case "d":
                            //result = File.ReadAllText("own-serialization");
                            result = WriteReadFile.Read("own-serialization");
                            dataContext = dataContext.Deserialize(result);
                            Console.WriteLine("Deserialized file:\n" + dataContext);
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }


                    //przykład z serializacją w OwnSerialization a nie w DataContext
                    //Console.WriteLine("Insert \"s\" - serialize or \"d\" - deserialize");
                    //string choice2 = Console.ReadLine();
                    //string result;
                    //OwnSerialization dataContextSerialization = new OwnSerialization(dataContext);
                    //switch (choice2)
                    //{
                    //    case "s":
                    //        ObjectIDGenerator idGenerator = new ObjectIDGenerator();
                    //        result = dataContextSerialization.Serialize(idGenerator);
                    //        File.WriteAllText("own-serialization", result);
                    //        break;
                    //    case "d":
                    //        result = File.ReadAllText("own-serialization");
                    //        dataContext = dataContextSerialization.Deserialize(result);
                    //        Console.WriteLine("Deserialized file:\n" + dataContext);
                    //        break;
                    //    default:
                    //        Console.WriteLine("Invalid input!");
                    //        break;
                    //}
                    #endregion
                }
                Console.WriteLine("Click any to continue");
                Console.ReadLine();
            } while(choice == "xml" || choice == "own");
        }
    }
}
