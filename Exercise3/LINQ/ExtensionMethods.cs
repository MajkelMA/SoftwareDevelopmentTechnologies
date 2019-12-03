using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace LINQ
{
    public static class ExtensionMethods
    {
        public static List<Product> GetProductsWithoutCategory_QuerySyntax(this List<Product> products)
        {
            List<Product> result = (from product in products
                                    where product.ProductSubcategoryID == null
                                    select product).ToList();
            return result;
        }

        public static List<Product> GetProductsWithoutCategory_MethodSyntax(this List<Product> products)
        {
            return products.Where(product => product.ProductSubcategoryID == null).ToList();
        }

        public static List<Product> Paginate(this List<Product> products, int size, int page)
        {
            return products.Skip(page * size).Take(size).ToList();
        }

        public static string GetProductNameAndSuppliers_QuerySyntax(this List<Product> products, List<ProductVendor> productVendors)
        {
            string result = "";
            var linqResult = (from product in products
                              from productVendor in productVendors
                              where product.ProductID.Equals(productVendor.ProductID)
                              select new { productName = product.Name, productVendorName = productVendor.Vendor.Name }).ToList();

            foreach (var item in linqResult)
            {
                result += item.productName + " - " + item.productVendorName + "\n";
            }

            return result;
        }

    }
}