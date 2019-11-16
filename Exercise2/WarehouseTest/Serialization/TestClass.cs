using System.Runtime.Serialization;

namespace WarehouseTest
{
    [DataContract(IsReference = true)]
    class TestClass1
    {
        [DataMember]
        public TestClass2 TestClass2 { get; set; }

        public TestClass1()
        {

        }

        //public string Serialize(ObjectIDGenerator idGenerator)
        //{
        //    return this.GetType().FullName + "|"
        //           + idGenerator.GetId(this, out bool firstTime) + "|"
        //           + test1 + "\n";
        //}

        //public TestClass1 Deserialize(string serializationStream)
        //{
        //    throw new System.NotImplementedException();
        //}
    }

    [DataContract(IsReference = true)]
    class TestClass2
    {
        [DataMember]
        public TestClass1 TestClass1 { get; set; }

        public TestClass2()
        {

        }

        //public string Serialize(ObjectIDGenerator idGenerator)
        //{
        //    return this.GetType().FullName + "|"
        //           + idGenerator.GetId(this, out bool firstTime) + "|"
        //           + test2 + "\n";
        //}

        //public TestClass2 Deserialize(string serializationStream)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
