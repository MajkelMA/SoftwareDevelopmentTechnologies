using System;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    [DataContract]
    public class ClassAPrim
    {
        [DataMember]
        public float FloatProperty { get; set; }
        [DataMember]
        public DateTime DateTimeProperty { get; set; }
        [DataMember]
        public string StringProperty { get; set; }
        [DataMember]
        public ClassBPrim ClassBProperty { get; set; }

        public ClassAPrim()
        {

        }

        public ClassAPrim(float floatProperty, DateTime dateTimeProperty, string stringProperty, ClassBPrim classBProperty)
        {
            FloatProperty = floatProperty;
            DateTimeProperty = dateTimeProperty;
            StringProperty = stringProperty;
            ClassBProperty = classBProperty;
        }
    }
}
