using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ClassLibrary
{
    public class ClassB : ISerializable
    {
        public float FloatProperty { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public string StringProperty { get; set; }
        public ClassC ClassCProperty { get; set; }
        public ClassB(float floatProperty, DateTime dateTimeProperty, string stringProperty, ClassC classCProperty)
        {
            FloatProperty = floatProperty;
            DateTimeProperty = dateTimeProperty;
            StringProperty = stringProperty;
            ClassCProperty = classCProperty;
        }

        public ClassB(SerializationInfo info, StreamingContext context)
        {
            FloatProperty = info.GetSingle("FloatProperty");
            DateTimeProperty = info.GetDateTime("DateTimeProperty");
            StringProperty = info.GetString("StringProperty");
            ClassCProperty = (ClassC)info.GetValue("ClassCProperty", typeof(ClassB));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FloatProperty", FloatProperty);
            info.AddValue("DateTimeProperty", DateTimeProperty);
            info.AddValue("StringProperty", StringProperty);
            info.AddValue("ClassCProperty", ClassCProperty, typeof(ClassC));
        }
    }
}
