using System;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    public class ClassC : ISerializable
    {
        public float FloatProperty { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public string StringProperty { get; set; }
        public ClassA ClassAProperty { get; set; }

        public ClassC(float floatProperty, DateTime dateTimeProperty, string stringProperty, ClassA classAProperty)
        {
            FloatProperty = floatProperty;
            DateTimeProperty = dateTimeProperty;
            StringProperty = stringProperty;
            ClassAProperty = classAProperty;
        }

        public ClassC(SerializationInfo info, StreamingContext context)
        {
            FloatProperty = info.GetSingle("FloatProperty");
            DateTimeProperty = info.GetDateTime("DateTimeProperty");
            StringProperty = info.GetString("StringProperty");
            ClassAProperty = (ClassA)info.GetValue("ClassAProperty", typeof(ClassA));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FloatProperty", FloatProperty);
            info.AddValue("DateTimeProperty", DateTimeProperty);
            info.AddValue("StringProperty", StringProperty);
            info.AddValue("ClassAProperty", ClassAProperty, typeof(ClassA));
        }
        public override string ToString()
        {
            return "String property: " + StringProperty + " DateTime property: " + DateTimeProperty + " FloatProperty: " + FloatProperty;
        }
    }
}
