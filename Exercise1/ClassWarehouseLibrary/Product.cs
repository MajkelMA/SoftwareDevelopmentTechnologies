using System;

namespace ClassWarehouseLibrary
{
    public class Product
    {
        public static long NextId = 0;
        public long Id { get; }
        public String Description { get; set; }
    
        public Product(String description)
        {
            Id = NextId;
            NextId++;
            Description = description;
        }
    }
}
