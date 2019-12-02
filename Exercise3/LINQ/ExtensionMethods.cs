using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public static class ExtensionMethods
    {
        public static List<Product> GetProductsWithoutCategory_QuerySyntax(this List<Product> products)
        {
            List<Product> result = (from product in products
                                    where product.ProductSubcategory == null
                                    select product).ToList();
            return result;
        }

        public static List<Product> GetProductsWithoutCategory_MethodSyntax(this List<Product> products)
        {
            return products.Where(product => product.ProductSubcategory == null).ToList();
        }
    }
}
