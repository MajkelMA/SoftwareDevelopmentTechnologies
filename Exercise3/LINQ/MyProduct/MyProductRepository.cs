using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.MyProduct
{
    public class MyProductRepository
    {
        private iMyProductDataContext<MyProduct> myProductDataContext { get; }

        public MyProductRepository(iMyProductDataContext<MyProduct> myProductDataContext)
        {
            this.myProductDataContext = myProductDataContext;
        }

        public List<MyProduct> GetMyProducts()
        {
            return myProductDataContext.GetAll();
        }

        public List<MyProduct> GetProductsByName(string productName)
        {
            List<MyProduct> result = (from product in myProductDataContext.GetAll()
                                      where product.Name.Contains(productName)
                                      select product).ToList();

            return result;
        }

        public List<MyProduct> GetNMyProductFromCategory(string categoryName, int n)
        {
            List<MyProduct> result = (from product in myProductDataContext.GetAll()
                                      where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                      select product).Take(n).ToList();
            return result;
        }

        public decimal GetTotalStandardCostByCategory(ProductCategory category)
        {
            decimal result = (from product in myProductDataContext.GetAll()
                              where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Equals(category)
                              select product.StandardCost).Sum();
            return result;
        }

        public decimal GetTotalStandardCostByCategory(string category)
        {
            decimal result = (from product in myProductDataContext.GetAll()
                              where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name.Contains(category)
                              select product.StandardCost).Sum();
            return result;
        }
    }
}
