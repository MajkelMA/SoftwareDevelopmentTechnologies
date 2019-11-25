using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace OwnSerialization
{
    public class OwnFormatter : Formatter
    {
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }
        public override ISurrogateSelector SurrogateSelector { get; set; }

        public OwnFormatter()
        {
            Binder = new OwnBinder();
            Context = new StreamingContext(StreamingContextStates.File);
        }

        public override object Deserialize(Stream serializationStream)
        {
            ReadDeserializeInfoAndCreateReferences(serializationStream);
            foreach (string row in DeserializeInfo)
            {
                string[] splitDataRow = row.Split('|');
                Type objectDeserializeType = GetTypeFromSplitDeserializeInfoRow(splitDataRow);
                SerializationInfo info = new SerializationInfo(objectDeserializeType, new FormatterConverter());
                GetSerializationInfoFromDeserializeInfoRow(info, splitDataRow);
                Type[] constructorTypes = { info.GetType(), Context.GetType() };
                object[] constuctorParameters = { info, Context };
                References[splitDataRow[2]].GetType().GetConstructor(constructorTypes).Invoke(References[splitDataRow[2]], constuctorParameters);

            }

            return References["1"];
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            if (graph is ISerializable data)
            {
                SerializationInfo info = new SerializationInfo(graph.GetType(), new FormatterConverter());
                Binder.BindToName(graph.GetType(), out string assemblyName, out string typeName);
                DataRow += assemblyName + "|" + typeName + "|" + this.m_idGenerator.GetId(graph, out bool firstTime);
                data.GetObjectData(info, Context);

                foreach (SerializationEntry item in info)
                {
                    WriteMember(item.Name, item.Value);
                }

                SaveAndCleanDataRow();
                while (this.m_objectQueue.Count != 0)
                {
                    this.Serialize(null, this.m_objectQueue.Dequeue());
                }

                SaveToStream(serializationStream);
            }
            else
            {
                throw new ArgumentException("graph is not Iserializable");
            }
        }

        #region WriteRegion

        protected override void WriteDateTime(DateTime val, string name)
        {
            DataRow += "|" + val.GetType() + "=" + name + "=" + val.ToUniversalTime().ToString();
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType.Equals(typeof(String)))
            {
                WriteString(obj, name);
            }
            else
            {
                WriteObject(obj, name, memberType);
            }
        }

        protected void WriteString(object obj, string name)
        {
            DataRow += "|" + obj.GetType() + "=" + name + "=" + "\"" + (String)obj + "\"";
        }

        protected void WriteObject(object obj, string name, Type type)
        {
            if (obj != null)
            {
                DataRow += "|" + obj.GetType() + "=" + name + "=" + this.m_idGenerator.GetId(obj, out bool firstTime).ToString();
                if (firstTime)
                {
                    this.m_objectQueue.Enqueue(obj);
                }
            }
            else
            {
                DataRow += "|" + "null" + "=" + name + "=-1";
            }
        }

        protected override void WriteSingle(float val, string name)
        {
            DataRow += "|" + val.GetType() + "=" + name + "=" + val.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
        }
        #endregion

        #region notimplemented
        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region private
        private string DataRow = "";
        private List<string> DataToSave = new List<string>();
        private List<string> DeserializeInfo = new List<string>();
        private Dictionary<string, object> References = new Dictionary<string, object>();


        private void SaveAndCleanDataRow()
        {
            DataToSave.Add(DataRow + "\n");
            DataRow = "";
        }

        private void SaveToStream(Stream serializationStream)
        {
            if (serializationStream != null)
            {
                using (StreamWriter writer = new StreamWriter(serializationStream))
                {
                    foreach (string line in DataToSave)
                        writer.Write(line);
                }
            }
        }

        private void ReadDeserializeInfoAndCreateReferences(Stream serializationStream)
        {
            if (serializationStream != null)
            {
                using (StreamReader reader = new StreamReader(serializationStream))
                {
                    String line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        DeserializeInfo.Add(line);
                    }
                }
                CreateReferences();
            }
        }

        private void CreateReferences()
        {
            foreach (string item in DeserializeInfo)
            {
                String[] splits = item.Split('|');
                References.Add(splits[2], FormatterServices.GetSafeUninitializedObject(Binder.BindToType(splits[0], splits[1])));
            }
        }

        private Type GetTypeFromSplitDeserializeInfoRow(string[] splitDeserializeRow)
        {
            return Binder.BindToType(splitDeserializeRow[0], splitDeserializeRow[1]);
        }

        private void GetSerializationInfoFromDeserializeInfoRow(SerializationInfo info, string[] splitedDeserializationInfoRow)
        {
            for (int i = 3; i < splitedDeserializationInfoRow.Length; i++)
            {
                string[] data = splitedDeserializationInfoRow[i].Split('=');
                Type typeToSave = Binder.BindToType(splitedDeserializationInfoRow[0], data[0]);
                if(typeToSave == null)
                {
                    if (!data[0].Equals("null"))
                    { 
                        SaveParsedValueToSerializationInfo(info, Type.GetType(data[0]), data[1], data[2]);
                    }
                    else
                    {
                        info.AddValue(data[1], null);
                    }

                }
                else
                {
                    if (!data[2].Equals("-1"))
                    {
                        info.AddValue(data[1], References[data[2]], typeToSave);
                    }
                }
            }
        }

        private void SaveParsedValueToSerializationInfo(SerializationInfo info, Type type, string name, string val)
        {
            switch (type.ToString())
            {
                case "System.Single":
                    info.AddValue(name, Single.Parse(val, System.Globalization.CultureInfo.InvariantCulture));
                    break;
                case "System.DateTime":
                    info.AddValue(name, DateTime.Parse(val));
                    break;
                case "System.String":
                    info.AddValue(name, val);
                    break;
            }
        }
        #endregion
    }
}
