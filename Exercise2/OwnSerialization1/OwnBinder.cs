using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace OwnSerialization
{
    public class OwnBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Assembly asm = Assembly.Load(assemblyName);
            return asm.GetType(typeName);
        }

        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            Assembly asm = serializedType.Assembly;
            assemblyName = asm.FullName;
            typeName = serializedType.FullName;

        }
    }
}
