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
        private List<MyProduct> insertProductsFromBase(int number)
        {
            return (from product in DataService.GetAllProduct()
                    orderby product.Name ascending
                    select new MyProduct(product)).Take(number).ToList();
        }

        [TestMethod]
        public void DataContextDeleteTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext();
            myProductDataContext.Add(insertProductsFromBase(100));
            Assert.AreEqual(myProductDataContext.GetAll().Count, 100);

            myProductDataContext.Delete((new MyProduct(DataService.GetProductByName("Adjustable Race")).ProductID));
            Assert.AreEqual(myProductDataContext.GetAll().Count, 99);
        }

        [TestMethod]
        public void DataContextUpdateTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext();
            myProductDataContext.Add(insertProductsFromBase(100));

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
            myProductDataContext.Add(insertProductsFromBase(100));
            Assert.AreEqual(myProductDataContext.GetAll().Count, 100);
        }

        [TestMethod]
        public void DataContextGetAllTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext();
            myProductDataContext.Add(insertProductsFromBase(100));
            Assert.AreEqual(myProductDataContext.GetAll().Count, 100);
        }

        [TestMethod]
        public void GetNMyProductFromCategoryTest()
        {
            MyProductDataContext myProductDataContext = new MyProductDataContext();
            myProductDataContext.Add(insertProductsFromBase(100));
            Assert.AreEqual(myProductDataContext.GetAll().Count, 100);
            MyProductRepository myProductRepository = new MyProductRepository(myProductDataContext);
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryStringTest()
        {

        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {

        }

        [TestMethod]
        public void GetProductsByName()
        {

        }
    }
}
