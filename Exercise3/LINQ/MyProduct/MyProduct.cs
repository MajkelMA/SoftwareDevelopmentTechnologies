using System.ComponentModel;
using System.Data.Linq;

namespace LINQ.MyProduct
{
    public class MyProduct : Product
    {
        //public int productID { get; set; }

        //public string name { get; set; }

        //public string productNumber { get; set; }

        public MyProduct(Product product)
        {
            this.ProductID = product.ProductID;
            this.Name = product.Name;
            this.ProductNumber = product.ProductNumber;
            this.ProductReviews = product.ProductReviews;
            this.ProductSubcategory = product.ProductSubcategory;
        }

        public override bool Equals(object obj)
        {
            MyProduct product = (MyProduct)obj;
            return this.ProductID.Equals(product.ProductID);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
    }
}
