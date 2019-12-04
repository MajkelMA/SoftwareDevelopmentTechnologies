using System.ComponentModel;
using System.Data.Linq;

namespace LINQ.MyProduct
{
    public class MyProduct
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public EntitySet<ProductReview> ProductReviews { get; set; }
        public int? ProductSubcategoryID { get; set; }
        public ProductSubcategory ProductSubcategory { get; set; }
        public decimal StandardCost { get; set; }

        public MyProduct(Product product) 
        {
            this.ProductID = product.ProductID;
            this.Name = product.Name;
            this.ProductNumber = product.ProductNumber;
            this.ProductReviews = product.ProductReviews;
             this.ProductSubcategoryID = product.ProductSubcategoryID;
            this.ProductSubcategory = product.ProductSubcategory;
            this.StandardCost = product.StandardCost;
        }

        public override bool Equals(object obj)
        {
            MyProduct product = (MyProduct)obj;
            return this.ProductID.Equals(product.ProductID);
        }



    }
}
