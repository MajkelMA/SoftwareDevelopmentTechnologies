using ClassWarehouseLibrary;
using ClassWarehouseLibrary.Entities;
using ISerialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Serialization
{
    public class OwnSerialization : IOwnFormatter<DataContext>
    {
        private DataContext _dataContext;
        private List<string> _types = new List<string>() {
            typeof(Client).FullName,
            typeof(Product).FullName,
            typeof(Status).FullName,
            typeof(EventStatus).FullName,
            typeof(BuyEvent).FullName,
            typeof(SellEvent).FullName,
            typeof(DestroyEvent).FullName
        };
        private Dictionary<long, Object> _objReferences = new Dictionary<long, Object>();

        public OwnSerialization(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public string Serialize(ObjectIDGenerator idGenerator)
        {
            string result = "";
            foreach (Client item in _dataContext.Clients)
            {
                result += item.Serialize(idGenerator);
            }

            foreach (KeyValuePair<Guid, Product> item in _dataContext.Products)
            {
                result += item.Value.Serialize(idGenerator);
            }

            foreach (Status item in _dataContext.Statuses)
            {
                result += item.Serialize(idGenerator);
            }

            foreach (Event item in _dataContext.Events)
            {
                result += item.Status.Serialize(idGenerator);
                result += item.Serialize(idGenerator);
            }

            return result;
        }

        public DataContext Deserialize(string strToDeserialize)
        {
            this._dataContext = new DataContext();
            string[] objArray = strToDeserialize.Split('\n');
            
            foreach(string item in objArray)
            {
                string[] splitObjArray = item.Split('|');
                switch (this.getObjType(splitObjArray[0]))
                {
                    case 0:
                        Client client = new Client();
                        client.Deserialize(splitObjArray, _objReferences);
                        this._dataContext.Clients.Add(client);
                        this._objReferences.Add(Int64.Parse(splitObjArray[1]), client);
                        break;
                    case 1:
                        Product product = new Product();
                        product.Deserialize(splitObjArray, _objReferences);
                        this._dataContext.Products.Add(product.Id, product);
                        this._objReferences.Add(Int64.Parse(splitObjArray[1]), product);
                        break;
                    case 2:
                        Status status = new Status();
                        status.Deserialize(splitObjArray, _objReferences);
                        this._dataContext.Statuses.Add(status);
                        this._objReferences.Add(Int64.Parse(splitObjArray[1]), status);
                        break;
                    case 3:
                        EventStatus eventStatus = new EventStatus();
                        eventStatus.Deserialize(splitObjArray, _objReferences);
                        this._objReferences.Add(Int64.Parse(splitObjArray[1]), eventStatus);
                        break;
                    case 4:
                        BuyEvent buyEvent = new BuyEvent();
                        buyEvent.Deserialize(splitObjArray, _objReferences);
                        this._dataContext.Events.Add(buyEvent);
                        this._objReferences.Add(Int64.Parse(splitObjArray[1]), buyEvent);
                        break;
                    case 5:
                        SellEvent sellEvent = new SellEvent();
                        sellEvent.Deserialize(splitObjArray, _objReferences);
                        this._dataContext.Events.Add(sellEvent);
                        this._objReferences.Add(Int64.Parse(splitObjArray[1]), sellEvent);
                        break;
                    case 6:
                        DestroyEvent destroyEvent = new DestroyEvent();
                        destroyEvent.Deserialize(splitObjArray, _objReferences);
                        this._dataContext.Events.Add(destroyEvent);
                        this._objReferences.Add(Int64.Parse(splitObjArray[1]), destroyEvent);
                        break;
                    default:
                        if (splitObjArray[0] == "")
                            break;
                        throw new SerializationException("Stream to deserialize contains invalid object types");
                }
            }
            return _dataContext;
        }

        private int getObjType(string str)
        {

            int index = _types.IndexOf(str);
            for(int i = 0; i < _types.Count; i ++)
            {
                if (_types[i].Equals(str))
                    index = i;
            }
            return index;
        }
    }
}
