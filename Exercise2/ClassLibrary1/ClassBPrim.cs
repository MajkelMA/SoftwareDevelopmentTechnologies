using System;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    [DataContract]
    public class ClassBPrim
    {
        [DataMember]
        public float FloatProperty { get; set; }
        [DataMember]
        public DateTime DateTimeProperty { get; set; }
        [DataMember]
        public string StringProperty { get; set; }
        [DataMember]
        public ClassCPrim ClassCProperty { get; set; }

        public ClassBPrim()
        {

        }

        public ClassBPrim(float floatProperty, DateTime dateTimeProperty, string stringProperty, ClassCPrim classCProperty)
        {
            FloatProperty = floatProperty;
            DateTimeProperty = dateTimeProperty;
            StringProperty = stringProperty;
            ClassCProperty = classCProperty;
        }
    }
}
