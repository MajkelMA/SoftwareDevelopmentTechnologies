using System;

namespace ClassWarehouseLibrary
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Id.Equals(product.Id) &&
                   Name == product.Name &&
                   Description == product.Description;
        }
    }
}
