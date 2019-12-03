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
                                      where product.productID.Equals(id)
                                      select product).Single());
        }

        public List<MyProduct> GetAll()
        {
            return myProducts;
        }

        public bool Update(MyProduct item)
        {
            MyProduct myProduct = (from product in myProducts
                                   where product.productID.Equals(item.productID)
                                   select product).Single();
            if (myProduct != null)
            {
                myProduct = item;
                return true;
            }
            return false;
        }
    }
}
