using System;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    public class ClassA : ISerializable
    {
        public float FloatProperty { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public string StringProperty { get; set; }
        public ClassB ClassBProperty { get; set; }

        public ClassA(float floatProperty, DateTime dateTimeProperty, string stringProperty, ClassB classBProperty)
        {
            FloatProperty = floatProperty;
            DateTimeProperty = dateTimeProperty;
            StringProperty = stringProperty;
            ClassBProperty = classBProperty;
        }

        public ClassA(SerializationInfo info, StreamingContext context)
        {
            FloatProperty = info.GetSingle("FloatProperty");
            DateTimeProperty = info.GetDateTime("DateTimeProperty");
            StringProperty = info.GetString("StringProperty");
            ClassBProperty = (ClassB)info.GetValue("ClassBProperty", typeof(ClassB));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FloatProperty", FloatProperty);
            info.AddValue("DateTimeProperty", DateTimeProperty);
            info.AddValue("StringProperty", StringProperty);
            info.AddValue("ClassBProperty", ClassBProperty, typeof(ClassB));
        }
    }
}
