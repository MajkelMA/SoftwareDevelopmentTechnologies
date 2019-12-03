using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.MyProduct
{
    public class MyProductDataContext : iMyProductDataContext<MyProduct>
    {
        public List<MyProduct> myProducts { get; set; }

        public MyProductDataContext()
        {
            myProducts = new List<MyProduct>();
        }

        public void Add(MyProduct item)
        {
            myProducts.Add(item);
        }

        public bool Delete(int id)
        {
            return myProducts.Remove((from product in myProducts
                                      where product.ProductID.Equals(id)
                                      select product).Single());
        }

        public List<MyProduct> GetAll()
        {
            return myProducts;
        }

        public bool Update(MyProduct item)
        {
            MyProduct myProduct = (from product in myProducts
                                   where product.ProductID.Equals(item.ProductID)
                                   select product).Single();
            if (myProduct != null)
            {
                myProduct.Name = item.Name;
                myProduct.ProductNumber = item.ProductNumber;
                myProduct.ProductReviews = item.ProductReviews;
                myProduct.ProductSubcategory = item.ProductSubcategory;
                return true;
            }
            return false;
        }

        public void Add(List<MyProduct> list)
        {
            myProducts.AddRange(list);
        }

        public MyProduct Get(int id)
        {
            MyProduct myProduct = (from product in myProducts
                                   where product.ProductID.Equals(id)
                                   select product).Single();
            return myProduct;
        }
    }
}
