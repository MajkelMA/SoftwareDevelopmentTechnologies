using ISerialization;
using System.Runtime.Serialization;

namespace SerializationTest
{
    [DataContract(IsReference = true)]
    class TestClass1
    {
        [DataMember]
        public TestClass2 testClass2 { set; get; }

        public TestClass1()
        {
            this.testClass2 = new TestClass2();
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

    [DataContract(IsReference = false)]
    class TestClass2
    {
        [DataMember]
        public TestClass1 testClass1 { set; get; }

        public TestClass2()
        {
            this.testClass1 = new TestClass1();
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
