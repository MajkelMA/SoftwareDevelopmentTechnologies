using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace LINQ
{
    public class DataService
    {
    
        public static List<Product> GetProductsByName(string namePart)
        {
            List<Product> result;
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                result = (from product in products
                          where product.Name.Contains(namePart)
                          select product).ToList();
            }
            return result;
        }

        public static List<Product> GetProductByVendorName(string vendorName)
        {
            List<Product> result;
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<ProductVendor> productVendors = dataContext.GetTable<ProductVendor>();
                result = (from productVendor in productVendors
                                        where productVendor.Vendor.Name.Equals(vendorName)
                                        select productVendor.Product).ToList();
            }
            return result;
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            List<string> result;
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<ProductVendor> productVendors = dataContext.GetTable<ProductVendor>();
                result = (from productVendor in productVendors
                               where productVendor.Vendor.Name.Equals(vendorName)
                               select productVendor.Product.Name).ToList();
            }
            return result;
        }

        public static string GetProductVendorByProductName(string productName)
        {
            string result;
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<ProductVendor> productVendors = dataContext.GetTable<ProductVendor>();
                result = (from productVendor in productVendors
                               where productVendor.Product.Name.Equals(productName)
                               select productVendor.Vendor.Name).Single();
            }
            return result;
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            List<Product> result;
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<ProductReview> productReviews = dataContext.GetTable<ProductReview>();
                result = (from productReview in productReviews
                               orderby productReview.ReviewDate descending
                               select productReview.Product).Take(howManyReviews).ToList();
            }
            return result.Distinct().ToList();
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            List<Product> result;
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<ProductReview> productReviews = dataContext.GetTable<ProductReview>();
                result = (from productReview in productReviews
                               orderby productReview.ReviewDate descending
                               group productReview.Product by productReview.ProductID into g
                               select g.First())
                            .Take(howManyProducts)
                            .ToList();
            }
            return result;
        }

        public static List<Product> GetNProductFromCategory(string categoryName, int n)
        {
            List<Product> result;
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                result = (from product in products
                          orderby product.Name
                          where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                          select product).Take(n).ToList();
            }
            return result;
        }

        public static decimal GetTotalStandardCostByCategory(ProductCategory category)
        {
            decimal result;
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                result = (from product in products
                               where product.ProductSubcategory.ProductCategory.Equals(category)
                               select product.StandardCost).Sum();
            }
            return result;
        }

        public static decimal GetTotalStandardCostByCategory(string category)
        {
            decimal result;
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                result = (from product in products
                               where product.ProductSubcategory.ProductCategory.Name.Equals(category)
                               select product.StandardCost).Sum();
            }
            return result;
        }

        public static Product GetProductByName(string productName)
        {
            Product result;
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                result = (from product in products
                                  where product.Name.Equals(productName)
                                  select product).Single();
            }
            return result;
        }

        public static List<ProductVendor> GetAllProductVendors()
        {
            List<ProductVendor> result;
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<ProductVendor> productVendors = dataContext.GetTable<ProductVendor>();
                result = (from productVendor in productVendors
                               select productVendor).ToList();
            }
            return result;
        }

        public static List<Product> GetAllProduct()
        {
            List<Product> result;
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<Product> products = dataContext.GetTable<Product>();
                result = (from product in products
                              select product).ToList();
            }
            return result;
        }
    }
}
