using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ViewModel
{
    public class AddProductViewModel
    {
        #region Properties

        public ICommand BackToMainWindowCommand { get; private set; }
        public ICommand AddProductCommand { get; private set; }
        public Action CloseWindow{ get; set; }
        private ProductRepostiory productRepository;

        public List<bool> Flags { get; set; }
        public List<string> Colors { get; set; }
        public List<string> SizeUnitMeasureCodes { get; set; }
        public List<string> WeightUnitMeasureCodes { get; set; }
        public List<string> ProductLines { get; set; }
        public List<string> Classes { get; set; }
        public List<string> Styles { get; set; }
        public List<string> ProductSubcategories { get; set; }
        public List<string> ProductModels { get; set; }

        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public string SafetyStockLevel { get; set; }
        public string ReorderPoint { get; set; }
        public string StandardCost { get; set; }
        public string ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public string Weight { get; set; }
        public string DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public string ProductSubcategory { get; set; }
        public string ProductModel { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime SellEndDate { get; set; }
        public DateTime DiscontinuedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        #endregion

        public AddProductViewModel()
        {
            productRepository = new ProductRepostiory();
            AddProductCommand = new RelayCommand(AddProduct);
            BackToMainWindowCommand = new RelayCommand(BackToMainWindow);
            initDates();
            initComboBox();
        }

        #region Private
        private void AddProduct()
        {
            Product product = new Product();
            product.Name = Name;
            product.ProductNumber = ProductNumber;
            product.MakeFlag = MakeFlag;
            product.FinishedGoodsFlag = FinishedGoodsFlag;
            product.Color = Color;
            product.SafetyStockLevel = Int16.Parse(SafetyStockLevel);
            product.ReorderPoint = Int16.Parse(ReorderPoint);
            product.StandardCost = decimal.Parse(StandardCost);
            product.ListPrice = decimal.Parse(ListPrice);
            product.Size = Size;
            product.SizeUnitMeasureCode = SizeUnitMeasureCode;
            product.WeightUnitMeasureCode = WeightUnitMeasureCode;
            product.Weight = decimal.Parse(Weight);
            product.DaysToManufacture = int.Parse(DaysToManufacture);
            product.ProductLine = ProductLine;
            product.Class = Class;
            product.Style = Style;
            product.ProductSubcategoryID = GetProductSubcategoryID(ProductSubcategory);
            product.ProductModelID = GetProductModelID(ProductModel);
            product.SellStartDate = SellStartDate;
            product.SellEndDate = SellEndDate;
            product.DiscontinuedDate = DiscontinuedDate;
            product.ModifiedDate = ModifiedDate;

            if (productRepository.Add(product))
            {
                CloseWindow();
            }
        }

        private int GetProductSubcategoryID(string productSubcategoryName)
        {
            List<Product> products = this.productRepository.GetAllProduct();
            return (from product in products
                    where product.ProductSubcategoryID != null &&  product.ProductSubcategory.Name.Equals(productSubcategoryName)
                    select product.ProductSubcategory.ProductSubcategoryID).First();
        }

        private int GetProductModelID(string productModelName)
        {
            List<Product> products = this.productRepository.GetAllProduct();
            return (from product in products
                    where product.ProductModelID != null && product.ProductModel.Name.Equals(productModelName)
                    select product.ProductModel.ProductModelID).First();
        }

        private void BackToMainWindow()
        {
            CloseWindow();
        }

        private void initDates()
        {
            this.SellStartDate = DateTime.Now;
            this.SellEndDate = DateTime.Now;
            this.DiscontinuedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }

        private void initComboBox()
        {
            List<Product> products = this.productRepository.GetAllProduct();
            this.Flags = new List<bool> { true, false };
            this.Colors = (from product in products
                           select product.Color).Distinct().ToList();

            this.SizeUnitMeasureCodes = (from product in products
                                         where product.SizeUnitMeasureCode != null
                                         select product.SizeUnitMeasureCode).Distinct().ToList();

            this.WeightUnitMeasureCodes = (from product in products
                                           where product.WeightUnitMeasureCode != null
                                           select product.WeightUnitMeasureCode).Distinct().ToList();

            this.ProductLines = (from product in products
                                 where product.ProductLine != null
                                 select product.ProductLine).Distinct().ToList();

            this.Classes = (from product in products
                            where product.Class != null
                            select product.Class).Distinct().ToList();

            this.Styles = (from product in products
                           where product.Style != null
                           select product.Style).Distinct().ToList();

            this.ProductSubcategories = (from product in products
                                         where product.ProductSubcategory != null
                                         select product.ProductSubcategory.Name).Distinct().ToList();

            this.ProductModels = (from product in products
                                  where product.ProductModel != null
                                  select product.ProductModel.Name).Distinct().ToList();
        }
        #endregion

    }
}
