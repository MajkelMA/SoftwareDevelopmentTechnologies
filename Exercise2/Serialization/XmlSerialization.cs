using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Serialization
{
    public class XmlSerialization<T>
    {
        private string _fileName;
        private T _obj;

        public XmlSerialization(string fileName, T obj)
        {
            this._fileName = fileName;
            this._obj = obj;
        }

        public void serialize()
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(T), null, Int32.MaxValue, false, true, null, null);
            XmlWriter writer = XmlWriter.Create(this._fileName, new XmlWriterSettings() { Indent = true });
            ser.WriteObject(writer, this._obj);
            writer.Close();
        }

        public T deserialize()
        {
            FileStream fs = new FileStream(this._fileName, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(T));
            this._obj = (T)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();
            return this._obj;
        }
    }
}
