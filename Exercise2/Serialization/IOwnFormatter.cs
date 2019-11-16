using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Serialization
{
    public interface IOwnFormatter
    {
        string Serialize(ObjectIDGenerator idGenerator);
        void Deserialize(string[] details, Dictionary<long, Object> objReferences);
    }

    public interface IOwnFormatter<T>
    {
        string Serialize(ObjectIDGenerator idGenerator);
        T Deserialize(string serializationStream);
    }
}
