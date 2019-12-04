using LINQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.Data.Linq;

namespace Tests
{
    [TestClass]
    public class LINQTest
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> products = DataService.GetProductsByName("Women's");
            List<Product> products2 = DataService.GetProductsByName("Touring-3000 Yellow, 50");
            List<Product> products3 = DataService.GetProductsByName("test");
            Assert.AreEqual(6, products.Count);
            Assert.AreEqual(1, products2.Count);
            Assert.AreEqual(0, products3.Count);
        }

        [TestMethod]
        public void GetProductByVendorNameTest()
        {
            List<Product> products = DataService.GetProductByVendorName("Comfort Road Bicycles");
            List<Product> products2 = DataService.GetProductByVendorName("");
            Assert.AreEqual(2, products.Count);
            Assert.AreEqual(0, products2.Count);
        }

        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> products = DataService.GetProductNamesByVendorName("Comfort Road Bicycles");
            List<string> products2 = DataService.GetProductNamesByVendorName("");
            Assert.AreEqual(2, products.Count);
            Assert.AreEqual(0, products2.Count);
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> products = DataService.GetProductsWithNRecentReviews(4);
            List<Product> products2 = DataService.GetProductsWithNRecentReviews(0);
            Assert.AreEqual(3, products.Count);
            Assert.AreEqual(0, products2.Count);
        }

        [TestMethod]
        public void GetNProductFromCategoryTest()
        {
            List<Product> products = DataService.GetNProductFromCategory("Bikes", 2);
            Assert.AreEqual(2, products.Count);
            Assert.AreEqual("Bikes", products[0].ProductSubcategory.ProductCategory.Name);
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            string vendorName = DataService.GetProductVendorByProductName("Bearing Ball");
            Assert.AreEqual("Wood Fitness", vendorName);
        }

        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<Product> products = DataService.GetNRecentlyReviewedProducts(4);
            Assert.AreEqual(3, products.Count);
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            decimal cost = DataService.GetTotalStandardCostByCategory("Bikes");
            Assert.AreEqual(92092.8230m, cost);
        }

        [TestMethod]
        public void GetProductNameAndSuppliers_QuerySyntaxTest()
        {
            List<Product> products = new List<Product>() { DataService.GetProductByName("LL Crankarm") };
            List <ProductVendor> productVendors = DataService.GetAllProductVendors();
            string description = products.GetProductNameAndSuppliers_QuerySyntax(productVendors);
            Assert.AreEqual(description, "LL Crankarm - Vision Cycles, Inc." + "\n"
                                       + "LL Crankarm - Proseware, Inc." + "\n");
        }
        
        public void GetProductWithoutCategory_QuerySyntaxTest()
        {
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<Product> table = dataContext.GetTable<Product>();
                List<Product> products = table.ToList();
                products = products.GetProductsWithoutCategory_QuerySyntax();
                Assert.AreEqual(209, products.Count);
            }

        }

        [TestMethod]
        public void GetProductWithoutCategory_MethodSyntaxTest()
        {
            using (TablesDataContext dataContext = new TablesDataContext())
            {
                Table<Product> table = dataContext.GetTable<Product>();
                List<Product> products = table.ToList();
                products = products.GetProductsWithoutCategory_MethodSyntax();
                Assert.AreEqual(209, products.Count);
            }

        }

        [TestMethod]
        public void PaginateTest()
        {
            using(TablesDataContext dataContext = new TablesDataContext())
            {
                Table<Product> table = dataContext.GetTable<Product>();
                List<Product> products = table.ToList();
                List<Product> products2 = products.Paginate(10, 0);
                Assert.AreEqual(10, products2.Count);
                for (int i = 0; i < 10; i++)
                {
                    Assert.AreEqual(products[i], products2[i]);
                }
            }
        } 
    }
}
