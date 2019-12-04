using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQ.MyProduct;
using LINQ;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class LINQMyProductTest
    {
        private List<MyProduct> insertProductsFromBase()
        {
            var test = (from product in DataService.GetAllProduct()
                    select new MyProduct(product)).ToList();


            return test;

            //return (from product in DataService.GetAllProduct()
            //        orderby product.Name ascending
            //        select new MyProduct(product)).Take(number).ToList();
        }

        [TestMethod]
        public void DataContextDeleteTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext();
            myProductDataContext.Add(insertProductsFromBase());
            Assert.AreEqual(myProductDataContext.GetAll().Count, 504);

            myProductDataContext.Delete((new MyProduct(DataService.GetProductByName("Adjustable Race")).ProductID));
            Assert.AreEqual(myProductDataContext.GetAll().Count, 503);
        }

        [TestMethod]
        public void DataContextUpdateTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext();
            myProductDataContext.Add(insertProductsFromBase());

            MyProduct myProduct = new MyProduct(DataService.GetProductByName("Adjustable Race"));

            Assert.AreEqual(myProductDataContext.Get(myProduct.ProductID).Name, "Adjustable Race");

            myProduct.Name = "test name";

            if(myProductDataContext.Update(myProduct) == true)
            {
                Assert.AreEqual(myProductDataContext.Get(myProduct.ProductID).Name, "test name");
            }
        }

        [TestMethod]
        public void DataContextAddTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext();
            myProductDataContext.Add(new MyProduct(DataService.GetProductByName("Adjustable Race")));
            Assert.AreEqual(myProductDataContext.GetAll().Count, 1);
        }

        [TestMethod]
        public void DataContextAddRangeTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext();
            myProductDataContext.Add(insertProductsFromBase());
            Assert.AreEqual(myProductDataContext.GetAll().Count, 504);
        }

        [TestMethod]
        public void DataContextGetAllTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext();
            myProductDataContext.Add(insertProductsFromBase());
            Assert.AreEqual(myProductDataContext.GetAll().Count, 504);
        }

        [TestMethod]
        public void GetNMyProductFromCategoryTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext();
            myProductDataContext.Add(insertProductsFromBase());
            MyProductRepository myProductRepository = new MyProductRepository(myProductDataContext);

            List<MyProduct> list = myProductRepository.GetNMyProductFromCategory("Bikes", 3);
            Assert.AreEqual(list.Count, 3);
            Assert.AreEqual(list[0].ProductSubcategory.ProductCategory.Name, "Bikes");
            Assert.AreEqual(list[1].ProductSubcategory.ProductCategory.Name, "Bikes");
            Assert.AreEqual(list[2].ProductSubcategory.ProductCategory.Name, "Bikes");
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryStringTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext();
            myProductDataContext.Add(insertProductsFromBase());
            MyProductRepository myProductRepository = new MyProductRepository(myProductDataContext);

            decimal cost = myProductRepository.GetTotalStandardCostByCategory("Bikes");
            Assert.AreEqual(92092.8230m, cost);
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext();
            myProductDataContext.Add(insertProductsFromBase());
            MyProductRepository myProductRepository = new MyProductRepository(myProductDataContext);

            List<MyProduct> list = myProductRepository.GetNMyProductFromCategory("Bikes", 1);
            ProductCategory productCategory = list[0].ProductSubcategory.ProductCategory;

            decimal cost = myProductRepository.GetTotalStandardCostByCategory(productCategory);
            Assert.AreEqual(92092.8230m, cost);
        }

        [TestMethod]
        public void GetProductsByName()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext();
            myProductDataContext.Add(insertProductsFromBase());
            MyProductRepository myProductRepository = new MyProductRepository(myProductDataContext);
            List<MyProduct> products = myProductRepository.GetProductsByName("Women's");
            List<MyProduct> products2 = myProductRepository.GetProductsByName("Touring-3000 Yellow, 50");
            List<MyProduct> products3 = myProductRepository.GetProductsByName("test");
            Assert.AreEqual(6, products.Count);
            Assert.AreEqual(1, products2.Count);
            Assert.AreEqual(0, products3.Count);
        }
    }
}
