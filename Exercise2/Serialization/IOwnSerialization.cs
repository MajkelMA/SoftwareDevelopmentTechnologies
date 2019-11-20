using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Serialization
{
    public interface IOwnSerialization
    {
        string Serialize(ObjectIDGenerator idGenerator);
        void Deserialize(string[] details, Dictionary<long, Object> objReferences);
    }

    public interface IOwnSerialization<T>
    {
        string Serialize(ObjectIDGenerator idGenerator);
        T Deserialize(string serializationString);
    }
}
