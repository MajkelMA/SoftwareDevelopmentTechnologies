using ClassWarehouseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace ClassWarehouseLibrary
{
    [DataContract]
    [KnownType(typeof(Product))]
    [KnownType(typeof(Client))]
    [KnownType(typeof(Event))]
    [KnownType(typeof(Status))]
    public class DataContext
    {
        private Dictionary<long, object> _objReferences = new Dictionary<long, object>();

        [DataMember]
        public Dictionary<Guid, Product> Products { get; set; }
        [DataMember]
        public List<Client> Clients { get; set; }
        [DataMember]
        public ObservableCollection<Event> Events { get; set; }
        [DataMember]
        public List<Status> Statuses { get; set; }

        public DataContext()
        {
            Clients = new List<Client>();
            Products = new Dictionary<Guid, Product>();
            Events = new ObservableCollection<Event>();
            Statuses = new List<Status>();
        }

        public override string ToString()
        {
            string result = "Products \n";
            foreach (KeyValuePair<Guid, Product> item in Products)
            {
                result += item.Value.ToString() + "\n";
            }
            result += "Clients \n";
            foreach (Client item in Clients)
            {
                result += item.ToString() + "\n";
            }
            result += "Events \n";
            foreach (Event item in Events)
            {
                result += item.ToString() + "\n";
            }
            result += "Statuses \n";
            foreach (Status item in Statuses)
            {
                result += item.ToString() + "\n";
            }

            return result;
        }

        public string Serialize(ObjectIDGenerator idGenerator)
        {
            string result = "";
            foreach (Client item in this.Clients)
            {
                result += item.Serialize(idGenerator);
            }

            foreach (KeyValuePair<Guid, Product> item in this.Products)
            {
                result += item.Value.Serialize(idGenerator);
            }

            foreach (Status item in this.Statuses)
            {
                result += item.Serialize(idGenerator);
            }

            foreach (Event item in this.Events)
            {
                result += item.Status.Serialize(idGenerator);
                result += item.Serialize(idGenerator);
            }

            return result;
        }

        public DataContext Deserialize(string strToDeserialize)
        {
            this.clear();
            string[] objArray = strToDeserialize.Split('\n');

            foreach (string item in objArray)
            {
                string[] splitObjArray = item.Split('|');
                switch (this.getObjType(splitObjArray[0]))
                {
                    case 0:
                        Client client = new Client();
                        client.Deserialize(splitObjArray, _objReferences);
                        Clients.Add(client);
                        this._objReferences.Add(Int64.Parse(splitObjArray[1]), client);
                        break;
                    case 1:
                        Product product = new Product();
                        product.Deserialize(splitObjArray, _objReferences);
                        Products.Add(product.Id, product);
                        this._objReferences.Add(Int64.Parse(splitObjArray[1]), product);
                        break;
                    case 2:
                        Status status = new Status();
                        status.Deserialize(splitObjArray, _objReferences);
                        Statuses.Add(status);
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
                        Events.Add(buyEvent);
                        this._objReferences.Add(Int64.Parse(splitObjArray[1]), buyEvent);
                        break;
                    case 5:
                        SellEvent sellEvent = new SellEvent();
                        sellEvent.Deserialize(splitObjArray, _objReferences);
                        Events.Add(sellEvent);
                        this._objReferences.Add(Int64.Parse(splitObjArray[1]), sellEvent);
                        break;
                    case 6:
                        DestroyEvent destroyEvent = new DestroyEvent();
                        destroyEvent.Deserialize(splitObjArray, _objReferences);
                        Events.Add(destroyEvent);
                        this._objReferences.Add(Int64.Parse(splitObjArray[1]), destroyEvent);
                        break;
                    default:
                        if (splitObjArray[0] == "")
                            break;
                        throw new SerializationException("Stream to deserialize contains invalid object types");
                }
            }
            return this;
        }

        private void clear()
        {
            Clients.Clear();
            Products.Clear();
            Events.Clear();
            Statuses.Clear();
        }

        private int getObjType(string str)
        {
            List<string> _types = new List<string>() {
            typeof(Client).FullName,
            typeof(Product).FullName,
            typeof(Status).FullName,
            typeof(EventStatus).FullName,
            typeof(BuyEvent).FullName,
            typeof(SellEvent).FullName,
            typeof(DestroyEvent).FullName
            };

            int index = _types.IndexOf(str);
            for (int i = 0; i < _types.Count; i++)
            {
                if (_types[i].Equals(str))
                    index = i;
            }
            return index;
        }

        public override bool Equals(object obj)
        {
            DataContext refObj = (DataContext) obj;
            return refObj.Equals(this);
        }
    }
}
