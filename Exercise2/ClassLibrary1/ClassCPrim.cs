using System;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    [DataContract]
    public class ClassCPrim
    {
        [DataMember]
        public float FloatProperty { get; set; }
        [DataMember]
        public DateTime DateTimeProperty { get; set; }
        [DataMember]
        public string StringProperty { get; set; }
        [DataMember]
        public ClassAPrim ClassAProperty { get; set; }

        public ClassCPrim()
        {

        }

        public ClassCPrim(float floatProperty, DateTime dateTimeProperty, string stringProperty, ClassAPrim classAProperty)
        {
            FloatProperty = floatProperty;
            DateTimeProperty = dateTimeProperty;
            StringProperty = stringProperty;
            ClassAProperty = classAProperty;
        }
    }
}
