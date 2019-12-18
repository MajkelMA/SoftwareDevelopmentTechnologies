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
        public Action CloseWindow { get; set; }
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

        public AddProductViewModel()
        {
            productRepository = new ProductRepostiory();
            AddProductCommand = new MyCommand(AddProduct);
            BackToMainWindowCommand = new MyCommand(BackToMainWindow);
            initDates();
            initComboBox();
        }

        #region Private
        private void AddProduct()
        {
            Product product = new Product();
            if (Name != null)
                product.Name = Name;
            if (ProductNumber != null)
                product.ProductNumber = ProductNumber;
            product.MakeFlag = MakeFlag;
            product.FinishedGoodsFlag = FinishedGoodsFlag;
            if (Color != null)
                product.Color = Color;
            if (SafetyStockLevel != null)
                product.SafetyStockLevel = SafetyStockLevel;
            if (ReorderPoint != null)
                product.ReorderPoint = ReorderPoint;
            if (StandardCost != null)
                product.StandardCost = StandardCost;
            if (ListPrice != null)
                product.ListPrice = ListPrice;
            if (Size != null)
                product.Size = Size;
            if (SizeUnitMeasureCode != null)
                product.SizeUnitMeasureCode = SizeUnitMeasureCode;
            if (WeightUnitMeasureCode != null)
                product.WeightUnitMeasureCode = WeightUnitMeasureCode;
            if (Weight != null)
                product.Weight = Weight;
            if (DaysToManufacture != null)
                product.DaysToManufacture = DaysToManufacture;
            if (ProductLine != null)
                product.ProductLine = ProductLine;
            if (Class != null)
                product.Class = Class;
            if (Style != null)
                product.Style = Style;
            if (ProductSubcategory != null)
                product.ProductSubcategoryID = GetProductSubcategoryID(ProductSubcategory);
            if (ProductModel != null)
                product.ProductModelID = GetProductModelID(ProductModel);
            product.SellStartDate = SellStartDate;
            product.SellEndDate = SellEndDate;
            product.DiscontinuedDate = DiscontinuedDate;
            product.ModifiedDate = ModifiedDate;
            product.rowguid = Guid.NewGuid();

            if (productRepository.Add(product))
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
