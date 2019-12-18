using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
   public class DataContextTests
    {
        private DataContext dataContext = new DataContext();
        [TestMethod]
        public void AddProductTest()
        {
            Product product = new Product();
            int size = dataContext.GetItems().Count();
            Assert.IsFalse(dataContext.Add(product));


            product.rowguid = new Guid();
            product.Name = "Testowy";
            product.ProductNumber = "TX-1111";
            product.MakeFlag = true;
            product.FinishedGoodsFlag = true;
            product.Color = null;
            product.SafetyStockLevel = 100;
            product.ReorderPoint = 100;
            product.StandardCost = 100;
            product.ListPrice = 100;
            product.Size = "S";
            product.SizeUnitMeasureCode = "CM";
            product.WeightUnitMeasureCode = "LB";
            product.Weight = 100;
            product.DaysToManufacture = 100;
            product.ProductLine = "M";
            product.Class = "H";
            product.Style = "M";
            product.ProductSubcategoryID = 1;
            product.ProductModelID = 1;
            product.SellStartDate = DateTime.Today;
            product.SellEndDate = DateTime.Today.AddDays(1);
            product.ModifiedDate = DateTime.Today;
            dataContext.Add(product);

            Assert.AreEqual(size + 1, dataContext.GetItems().Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            List<Product> products = dataContext.GetItems().ToList();
            Product product = products.Last();
            product.Weight = 101;
            Assert.IsTrue(dataContext.Update(product));
            products = dataContext.GetItems().ToList();
            product = products.Last();
            Assert.AreEqual(101, product.Weight);
        }

        [TestMethod]
        public void GetTest()
        {
            Product product = dataContext.Get(1);
            Assert.AreEqual(1, product.ProductID);
        }

		[TestMethod]
		public void DeleteProductTest()
        {
            List<Product> products = dataContext.GetItems().ToList();
            int size = dataContext.GetItems().Count();
            dataContext.Delete(products[products.Count-1]);
            Assert.AreEqual(size - 1, dataContext.GetItems().Count());

        }
    }
}
