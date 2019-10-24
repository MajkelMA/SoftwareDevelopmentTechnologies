using System;
using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    public class Product
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return product != null &&
                   Id.Equals(product.Id) &&
                   Name == product.Name &&
                   Description == product.Description;
        }

        public override int GetHashCode()
        {
            var hashCode = 1829809407;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            return hashCode;
        }
    }
}
