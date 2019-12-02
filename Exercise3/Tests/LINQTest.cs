using LINQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        public void GetNProductFromCategorytest()
        {
            List<Product> products = DataService.GetNProductFromCategory("Bikes", 2);
            Assert.AreEqual(2, products.Count);
            Assert.AreEqual("Bikes", products[0].ProductSubcategory.ProductCategory.Name);
        }

    }
}
