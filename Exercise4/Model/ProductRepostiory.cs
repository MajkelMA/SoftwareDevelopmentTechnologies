﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class ProductRepostiory : IRepository<Product>
    {
        private IDataContext<Product> productsDataContext;

        public ProductRepostiory(IDataContext<Product> dataContext)
        {
            productsDataContext = dataContext;
        }

        public bool Add(Product item)
        {
            return productsDataContext.Add(item);
        }

        public bool Delete(Product item)
        {
            return productsDataContext.Delete(item);
        }

        public Product Get(int id)
        {
            return productsDataContext.Get(id);
        }

        public IQueryable<Product> GetAll()
        {
            return productsDataContext.GetItems<Product>();
        }

        public bool Update(Product item)
        {
            return productsDataContext.Update(item);
        }

        public List<Product> GetProductsByName(string namePart)
        {

            List<Product> result = (from product in GetAll() 
                                    where product.Name.Contains(namePart)
                                    select product).ToList();
            return result;
        }

        public List<Product> GetProductByVendorName(string vendorName)
        {
 
            List<Product> result = (from productVendor in productsDataContext.GetItems<ProductVendor>()
                                    where productVendor.Vendor.Name.Equals(vendorName)
                                    select productVendor.Product).ToList();

            return result;
        }

        public List<string> GetProductNamesByVendorName(string vendorName)
        {

       
            List<string> result = (from productVendor in productsDataContext.GetItems<ProductVendor>()
                                   where productVendor.Vendor.Name.Equals(vendorName)
                                   select productVendor.Product.Name).ToList();

            return result;
        }

        public string GetProductVendorByProductName(string productName)
        { 
            string result = (from productVendor in productsDataContext.GetItems<ProductVendor>()
                             where productVendor.Product.Name.Equals(productName)
                             select productVendor.Vendor.Name).Single();

            return result;
        }

        public List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {

            List<Product> result = (from productReview in productsDataContext.GetItems<ProductReview>()
                                    orderby productReview.ReviewDate descending
                                    select productReview.Product).Take(howManyReviews).ToList();

            return result.Distinct().ToList();
        }

        public List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {

            List<Product> result = (from productReview in productsDataContext.GetItems<ProductReview>()
                                    orderby productReview.ReviewDate descending
                                    group productReview.Product by productReview.ProductID into g
                                    select g.First())
                        .Take(howManyProducts)
                        .ToList();

            return result;
        }

        public List<Product> GetNProductFromCategory(string categoryName, int n)
        {
            List<Product> result = (from product in GetAll()
                                    orderby product.Name
                                    where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                    select product).Take(n).ToList();

            return result;
        }

        public decimal GetTotalStandardCostByCategory(ProductCategory category)
        {
            decimal result = (from product in GetAll()
                              where product.ProductSubcategory.ProductCategory.Equals(category)
                              select product.StandardCost).Sum();

            return result;
        }

        public decimal GetTotalStandardCostByCategory(string category)
        {
            decimal result = (from product in GetAll()
                              where product.ProductSubcategory.ProductCategory.Name.Equals(category)
                              select product.StandardCost).Sum();
            return result;
        }

        public Product GetProductByName(string productName)
        {
            Product result = (from product in GetAll()
                              where product.Name.Equals(productName)
                              select product).Single();
            return result;
        }

        public List<ProductVendor> GetAllProductVendors()
        {

            List<ProductVendor> result = (from productVendor in productsDataContext.GetItems<ProductVendor>()
                                          select productVendor).ToList();
            return result;
        }

        public List<Product> GetAllProduct()
        {
            List<Product> result = (from product in GetAll()
                                    select product).ToList();
            return result;
        }

    }
}
