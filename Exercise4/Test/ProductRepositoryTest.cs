using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestClass]
        public class LINQTest
        {
            ProductRepostiory ProductRepostiory = new ProductRepostiory();
            [TestMethod]
            public void GetTest()
            {
                Product product = ProductRepostiory.Get(1);
                Assert.AreEqual(1, product.ProductID);
            }

            [TestMethod]
            public void GetProductsByNameTest()
            {
                List<Product> products = ProductRepostiory.GetProductsByName("Women's");
                List<Product> products2 = ProductRepostiory.GetProductsByName("Touring-3000 Yellow, 50");
                List<Product> products3 = ProductRepostiory.GetProductsByName("test");
                Assert.AreEqual(6, products.Count);
                Assert.AreEqual(1, products2.Count);
                Assert.AreEqual(0, products3.Count);
            }

            [TestMethod]
            public void GetProductByVendorNameTest()
            {
                List<Product> products = ProductRepostiory.GetProductByVendorName("Comfort Road Bicycles");
                List<Product> products2 = ProductRepostiory.GetProductByVendorName("");
                Assert.AreEqual(2, products.Count);
                Assert.AreEqual(0, products2.Count);
            }

            [TestMethod]
            public void GetProductNamesByVendorNameTest()
            {
                List<string> products = ProductRepostiory.GetProductNamesByVendorName("Comfort Road Bicycles");
                List<string> products2 = ProductRepostiory.GetProductNamesByVendorName("");
                Assert.AreEqual(2, products.Count);
                Assert.AreEqual(0, products2.Count);
            }

            [TestMethod]
            public void GetProductsWithNRecentReviewsTest()
            {
                List<Product> products = ProductRepostiory.GetProductsWithNRecentReviews(4);
                List<Product> products2 = ProductRepostiory.GetProductsWithNRecentReviews(0);
                Assert.AreEqual(3, products.Count);
                Assert.AreEqual(0, products2.Count);
            }

            [TestMethod]
            public void GetNProductFromCategoryTest()
            {
                List<Product> products = ProductRepostiory.GetNProductFromCategory("Bikes", 2);
                Assert.AreEqual(2, products.Count);
                Assert.AreEqual("Bikes", products[0].ProductSubcategory.ProductCategory.Name);
            }

            [TestMethod]
            public void GetProductVendorByProductNameTest()
            {
                string vendorName = ProductRepostiory.GetProductVendorByProductName("Bearing Ball");
                Assert.AreEqual("Wood Fitness", vendorName);
            }

            [TestMethod]
            public void GetNRecentlyReviewedProductsTest()
            {
                List<Product> products = ProductRepostiory.GetNRecentlyReviewedProducts(4);
                Assert.AreEqual(3, products.Count);
            }

            [TestMethod]
            public void GetTotalStandardCostByCategoryTest()
            {
                decimal cost = ProductRepostiory.GetTotalStandardCostByCategory("Bikes");
                Assert.AreEqual(92092.8230m, cost);
            }


            public void GetProductWithoutCategory_QuerySyntaxTest()
            {
                using (TablesDataContext dataContext = new TablesDataContext())
                {
                    Table<Product> table = dataContext.GetTable<Product>();
                    List<Product> products = table.ToList();
                    Assert.AreEqual(209, products.Count);
                }

            }
        
        }
    }
}
