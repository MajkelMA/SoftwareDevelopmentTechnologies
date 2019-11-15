using System.Runtime.Serialization;

namespace SerializationTest
{
    [DataContract(IsReference = true)]
    class TestClass1
    {
        [DataMember]
        public TestClass3 testClass3;
        public string test1 { set; get; }

        public TestClass1()
        {
            this.test1 = "TestClas1";
            this.testClass3 = new TestClass3();
        }
    }

    [DataContract(IsReference = true)]
    class TestClass2
    {
        [DataMember]
        public TestClass1 testClass1;
        public string test2 { set; get; }

        public TestClass2()
        {
            this.test2 = "TestClas2";
            this.testClass1 = new TestClass1();
        }
    }

    [DataContract(IsReference = true)]
    class TestClass3
    {
        [DataMember]
        public TestClass2 testClass2;
        public string test3 { set; get; }

        public TestClass3()
        {
            this.test3 = "TestClas3";
            this.testClass2 = new TestClass2();
        }
    }
}
