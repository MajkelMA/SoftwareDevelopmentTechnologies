using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ViewModel.Interfaces;

namespace ViewModel
{
    public class ModifyProductViewModel : IViewModel
    {
        #region Properties

        public ICommand ModifyProductCommand { get; private set; }
        public ICommand BackToMainWindowCommand { get; private set; }
        public Action CloseWindow { get; set; }
        public Product Product { get; set; }
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
        public Int16 SafetyStockLevel { get; set; }
        public Int16 ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public decimal Weight { get; set; }
        public int DaysToManufacture { get; set; }
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

        public ModifyProductViewModel()
        {
            productRepository = new ProductRepostiory();
            ModifyProductCommand = new MyCommand(ModifyProduct);
            BackToMainWindowCommand = new MyCommand(BackToMainWindow);
            InitDates();
            InitComboBox();
        }

        public ModifyProductViewModel(Product product) : this()
        {
            Product = product;
            InitModifyProduct();
        }

        #region Private
        private void InitModifyProduct()
        {
            if (Product.Name != null)
                Name = Product.Name;
            if (Product.ProductNumber != null)
                ProductNumber = Product.ProductNumber;
            MakeFlag = Product.MakeFlag;
            FinishedGoodsFlag = Product.FinishedGoodsFlag;
            if (Product.Color != null)
                Color = Product.Color;
            if (Product.SafetyStockLevel != null)
                SafetyStockLevel = Product.SafetyStockLevel;
            if (Product.ReorderPoint != null)
                ReorderPoint = Product.ReorderPoint;
            if (Product.StandardCost != null)
                StandardCost = Product.StandardCost;
            if (Product.ListPrice != null)
                ListPrice = Product.ListPrice;
            if (Product.Size != null)
                Size = Product.Size;
            if (Product.SizeUnitMeasureCode != null)
                SizeUnitMeasureCode = Product.SizeUnitMeasureCode;
            if (Product.WeightUnitMeasureCode != null)
                WeightUnitMeasureCode = Product.WeightUnitMeasureCode;
            if (Product.Weight != null)
                Weight = Product.Weight.Value;
            if (Product.DaysToManufacture != null)
                DaysToManufacture = Product.DaysToManufacture;
            if (Product.ProductLine != null)
                ProductLine = Product.ProductLine;
            if (Product.Class != null)
                Class = Product.Class;
            if (Product.Style != null)
                Style = Product.Style;
            if (Product.ProductSubcategoryID != null)
                ProductSubcategory = GetProductSubcategoryName(Product.ProductSubcategoryID.Value);
            if (Product.ProductModelID != null)
                ProductModel = GetProductModelName(Product.ProductModelID.Value);
            if (Product.SellStartDate != null)
                SellStartDate = Product.SellStartDate;
            if (Product.SellEndDate != null)
                SellEndDate = Product.SellEndDate.Value;
            if (Product.DiscontinuedDate != null)
                DiscontinuedDate = Product.DiscontinuedDate.Value;
        }

        private void ModifyProduct()
        {
            if (Name != null)
                Product.Name = Name;
            if (ProductNumber != null)
                Product.ProductNumber = ProductNumber;
            Product.MakeFlag = MakeFlag;
            Product.FinishedGoodsFlag = FinishedGoodsFlag;
            if (Color != null)
                Product.Color = Color;
            if (SafetyStockLevel != null)
                Product.SafetyStockLevel = SafetyStockLevel;
            if (ReorderPoint != null)
                Product.ReorderPoint = ReorderPoint;
            if (StandardCost != null)
                Product.StandardCost = StandardCost;
            if (ListPrice != null)
                Product.ListPrice = ListPrice;
            if (Size != null)
                Product.Size = Size;
            if (SizeUnitMeasureCode != null)
                Product.SizeUnitMeasureCode = SizeUnitMeasureCode;
            if (WeightUnitMeasureCode != null)
                Product.WeightUnitMeasureCode = WeightUnitMeasureCode;
            if (Weight != null)
                Product.Weight = Weight;
            if (DaysToManufacture != null)
                Product.DaysToManufacture = DaysToManufacture;
            if (ProductLine != null)
                Product.ProductLine = ProductLine;
            if (Class != null)
                Product.Class = Class;
            if (Style != null)
                Product.Style = Style;
            if (ProductSubcategory != null)
                Product.ProductSubcategoryID = GetProductSubcategoryID(ProductSubcategory);
            if (ProductModel != null)
                Product.ProductModelID = GetProductModelID(ProductModel);
            Product.SellStartDate = SellStartDate;
            Product.SellEndDate = SellEndDate;
            Product.DiscontinuedDate = DiscontinuedDate;
            Product.ModifiedDate = ModifiedDate;

            if (productRepository.Update(Product))
            {
                CloseWindow();
            }
        }

        private int GetProductSubcategoryID(string productSubcategoryName)
        {
            List<Product> products = this.productRepository.GetAllProduct();
            return (from product in products
                    where product.ProductSubcategoryID != null && product.ProductSubcategory.Name.Equals(productSubcategoryName)
                    select product.ProductSubcategory.ProductSubcategoryID).First();
        }

        private string GetProductSubcategoryName(int index)
        {
            List<Product> products = this.productRepository.GetAllProduct();
            return (from product in products
                    where product.ProductSubcategoryID != null && product.ProductSubcategoryID == index
                    select product.ProductSubcategory.Name).First();
        }

        private int GetProductModelID(string productModelName)
        {
            List<Product> products = this.productRepository.GetAllProduct();
            return (from product in products
                    where product.ProductModelID != null && product.ProductModel.Name.Equals(productModelName)
                    select product.ProductModel.ProductModelID).First();
        }

        private string GetProductModelName(int index)
        {
            List<Product> products = this.productRepository.GetAllProduct();
            return (from product in products
                    where product.ProductModelID != null && product.ProductModelID == index
                    select product.ProductModel.Name).First();
        }

        private void BackToMainWindow()
        {
            CloseWindow();
        }

        private void InitDates()
        {
            this.SellStartDate = DateTime.Now;
            this.SellEndDate = DateTime.Now;
            this.DiscontinuedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }

        private void InitComboBox()
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
