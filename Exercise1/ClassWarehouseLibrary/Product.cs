using System;
using System.Collections.Generic;

namespace ClassWarehouseLibrary
{
    public class Product
    {
        public String Description { get; set; }
    
        public Product(String description)
        {
            Description = description;
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Description == product.Description;
        }

        public override int GetHashCode()
        {
            return -1440511887 + EqualityComparer<string>.Default.GetHashCode(Description);
        }
    }

}
