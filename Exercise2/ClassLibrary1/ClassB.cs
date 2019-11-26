﻿using System;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    [DataContract]
    public class ClassB : ISerializable
    {
        [DataMember]
        public float FloatProperty { get; set; }
        [DataMember]
        public DateTime DateTimeProperty { get; set; }
        [DataMember]
        public string StringProperty { get; set; }
        [DataMember]
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
            ClassCProperty = (ClassC)info.GetValue("ClassCProperty", typeof(ClassC));
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
