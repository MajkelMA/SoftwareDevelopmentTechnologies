using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WarehouseTest
{
    class TestClass1
    {
        #region "Top"
        public TestClass2 TestClass2 { get; set; }
        public string Test1 { get; set; }

        public TestClass1()
        {

        }
        #endregion

        public string Serialize(ObjectIDGenerator idGenerator)
        {
            string result = this.GetType().FullName + "|"
                   + idGenerator.GetId(this, out bool firstTime) + "|"
                   + Test1 + "|"
                   + idGenerator.GetId(TestClass2, out bool firstTime2) + "|";
            result += "\n";
            if (firstTime2)
            {
                result += TestClass2.Serialize(idGenerator);
            }
            return result;
        }

        public void Deserialize(string details, ObjectIDGenerator idGenerator, Dictionary<long, object> objReferences)
        {
            string[] splitedDetials = details.Split('\n');
            details = "";
            for (int i = 1; i < splitedDetials.Length; i++)
            {
                details += splitedDetials[i];
                if (splitedDetials[i] != "") details += '\n';
            }

            splitedDetials = splitedDetials[0].Split('|');

            idGenerator.GetId(this, out bool firstTime);
            if (firstTime)
            {
                objReferences.Add(Int64.Parse(splitedDetials[1]), this);
                this.Test1 = splitedDetials[2];
            }
            if (TestClass2 == null)
            {
                if (objReferences.ContainsKey(Int64.Parse(splitedDetials[3])))
                    TestClass2 = (TestClass2)objReferences[Int64.Parse(splitedDetials[3])];
                else
                {
                    TestClass2 = new TestClass2();
                    TestClass2.Deserialize(details, idGenerator, objReferences);
                }
            }
        }
    }

    class TestClass2
    {
        #region "Top"
        public TestClass1 TestClass1 { get; set; }

        public string Test2 { get; set; }

        public TestClass2()
        {

        }
        #endregion

        public string Serialize(ObjectIDGenerator idGenerator)
        {
            string result = this.GetType().FullName + "|"
                    + idGenerator.GetId(this, out bool firstTime) + "|"
                    + Test2 + "|"
                    + idGenerator.GetId(TestClass1, out bool firstTime2) + "|";
            result += "\n";
            if (firstTime2)
            {
                result += TestClass1.Serialize(idGenerator);
            }
            return result;
        }

        public void Deserialize(string details, ObjectIDGenerator idGenerator, Dictionary<long, object> objReferences)
        {
            string[] splitedDetials = details.Split('\n');
            details = "";
            for (int i = 1; i < splitedDetials.Length; i++)
            {
                details += splitedDetials[i];
                if (splitedDetials[i] != "") details += '\n';
            }

            splitedDetials = splitedDetials[0].Split('|');

            idGenerator.GetId(this, out bool firstTime);
            if (firstTime)
            {
                objReferences.Add(Int64.Parse(splitedDetials[1]), this);
                this.Test2 = splitedDetials[2];
            }
            if (TestClass1 == null)
            {
                if (objReferences.ContainsKey(Int64.Parse(splitedDetials[3])))
                    TestClass1 = (TestClass1)objReferences[Int64.Parse(splitedDetials[3])];
                else
                {
                    TestClass1 = new TestClass1();
                    TestClass1.Deserialize(details, idGenerator, objReferences);
                }
            }
        }
    }
}
