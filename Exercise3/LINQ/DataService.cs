using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace LINQ
{
    public class DataService
    {
        private static TablesDataContext DataContext = new TablesDataContext();
        public static List<Product> GetProductsByName(string namePart)
        {
            Table<Product> products = DataContext.GetTable<Product>();
            List<Product> result = (from product in products
                                    where product.Name.Contains(namePart)
                                    select product).ToList();
            return result;
        }

        public static List<Product> GetProductByVendorName(string vendorName)
        {
            Table<ProductVendor> productVendors = DataContext.GetTable<ProductVendor>();
            List<Product> result = (from productVendor in productVendors
                                    where productVendor.Vendor.Name.Equals(vendorName)
                                    select productVendor.Product).ToList();
            return result;
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            Table<ProductVendor> productVendors = DataContext.GetTable<ProductVendor>();
            List<string> result = (from productVendor in productVendors
                                   where productVendor.Vendor.Name.Equals(vendorName)
                                   select productVendor.Product.Name).ToList();
            return result;
        }

        public static string GetProductVendorByProductName(string productName)
        {
            Table<ProductVendor> productVendors = DataContext.GetTable<ProductVendor>();
            string result = (from productVendor in productVendors
                             where productVendor.Product.Name.Equals(productName)
                             select productVendor.Vendor.Name).Single();
            return result;
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            Table<ProductReview> productReviews = DataContext.GetTable<ProductReview>();

            List<Product> result = (from productReview in productReviews
                                    orderby productReview.ReviewDate descending
                                    select productReview.Product).Take(howManyReviews).ToList();
            return result.Distinct().ToList();
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            Table<ProductReview> productReviews = DataContext.GetTable<ProductReview>();

            List<Product> result = (from productReview in productReviews
                                    orderby productReview.ReviewDate descending
                                    group productReview.Product by productReview.ProductID into g
                                    select g.First())
                        .Take(howManyProducts)
                        .ToList();
            return result;
        }

        public static List<Product> GetNProductFromCategory(string categoryName, int n)
        {
            Table<Product> products = DataContext.GetTable<Product>();
            List<Product> result = (from product in products
                                    orderby product.Name
                                    where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                    select product).Take(n).ToList();
            return result;
        }

        public static decimal GetTotalStandardCostByCategory(ProductCategory category)
        {
            Table<Product> products = DataContext.GetTable<Product>();
            decimal result = (from product in products
                              where product.ProductSubcategory.ProductCategory.Equals(category)
                              select product.StandardCost).Sum();
            return result;
        }

        public static decimal GetTotalStandardCostByCategory(string category)
        {
            Table<Product> products = DataContext.GetTable<Product>();
            decimal result = (from product in products
                              where product.ProductSubcategory.ProductCategory.Name.Equals(category)
                              select product.StandardCost).Sum();
            return result;
        }

    }
}
