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
        public IMyPopup ValidatorPopup { get; set; }
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
        #endregion

        #region Field Properties
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
        #endregion

        #region CheckBox
        public bool ColorCheck { get; set; }
        public bool SizeCheck { get; set; }
        public bool SizeUnitMeasureCodeCheck { get; set; }
        public bool WeightUnitMeasureCodeCheck { get; set; }
        public bool WeightCheck { get; set; }
        public bool ProductLineCheck { get; set; }
        public bool ClassCheck { get; set; }
        public bool StyleCheck { get; set; }
        public bool ProductSubcategoryCheck { get; set; }
        public bool ProductModelCheck { get; set; }
        public bool SellEndDateCheck { get; set; }
        public bool DiscontinuedDateCheck { get; set; }
        #endregion

        public ModifyProductViewModel()
        {
            productRepository = new ProductRepostiory();
            ModifyProductCommand = new MyCommand(ModifyProduct);
            BackToMainWindowCommand = new MyCommand(BackToMainWindow);
            InitComboBox();
        }

        public ModifyProductViewModel(Product product, IMyPopup myPopup) : this()
        {
            ValidatorPopup = myPopup;
            Product = product;
            InitModifyProduct();
        }

        #region Modify Product methods
        private void ModifyProduct()
        {
            string message = "";
            
            CheckCheckBox(Product);

            if (Name != null && Name != "")
                Product.Name = Name;
            else
                message += "Name is empty\n";

            if (ProductNumber != null)
                Product.ProductNumber = ProductNumber;
            else
                message += "Product number is empty\n";

            Product.MakeFlag = MakeFlag;
            Product.FinishedGoodsFlag = FinishedGoodsFlag;
            Product.SafetyStockLevel = SafetyStockLevel;
            Product.ReorderPoint = ReorderPoint;
            Product.StandardCost = StandardCost;
            Product.ListPrice = ListPrice;
            Product.DaysToManufacture = DaysToManufacture;
            Product.ModifiedDate = DateTime.Now;

            Product.SellStartDate = SellStartDate;

            if (SellEndDateCheck == true)
            {
                if (SellEndDate > SellStartDate)
                    Product.SellEndDate = SellEndDate;
                else
                    message += "Sell end date is after sell start date\n";
            }

            if (DiscontinuedDateCheck == true)
            {
                Product.DiscontinuedDate = DiscontinuedDate;
            }

            if (message != "")
            {
                ValidatorPopup.ShowPopup(message);
            }
            else if (productRepository.Update(Product))
            {
                ValidatorPopup.ShowPopup("Product modified succefully!");
                CloseWindow();
            }
        }

        private void CheckCheckBox(Product product)
        {
            if (ColorCheck == false)
                product.Color = null;
            else
                product.Color = Color;

            if (SizeCheck == false)
                product.Size = null;
            else
                product.Size = Size;

            if (ProductLineCheck == false)
                product.ProductLine = null;
            else
                product.ProductLine = ProductLine;

            if (ClassCheck == false)
                product.Class = null;
            else
                product.Class = Class;

            if (StyleCheck == false)
                product.Style = null;
            else
                product.Style = Style;

            if (ProductSubcategoryCheck == false)
                ProductSubcategory = null;
            else
                product.ProductSubcategoryID = GetProductSubcategoryID(ProductSubcategory);

            if (ProductModelCheck == false)
                ProductModel = null;
            else
                product.ProductModelID = GetProductModelID(ProductModel);
        }
        #endregion

        #region Private Method (Subcategory and Model)
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
        #endregion

        #region Init
        private void InitModifyProduct()
        {
            if (Product.Color != null)
            {
                Color = Product.Color;
                ColorCheck = true;
            }
            else
                ColorCheck = false;

            if (Product.Size != null)
            {
                Size = Product.Size;
                SizeCheck = true;
            }
            else
                SizeCheck = false;

            if (Product.SizeUnitMeasureCode != null)
            {
                SizeUnitMeasureCode = Product.SizeUnitMeasureCode;
                SizeUnitMeasureCodeCheck = true;
            }
            else
                SizeUnitMeasureCodeCheck = false;

            if (Product.WeightUnitMeasureCode != null)
            {
                WeightUnitMeasureCode = Product.WeightUnitMeasureCode;
                WeightUnitMeasureCodeCheck = true;
            }
            else
                WeightUnitMeasureCodeCheck = false;

            if (Product.Weight != null)
            {
                Weight = Product.Weight.Value;
                WeightCheck = true;
            }
            else
                WeightCheck = false;

            if (Product.ProductLine != null)
            {
                ProductLine = Product.ProductLine;
                ProductLineCheck = true;
            }
            else
                ProductLineCheck = false;

            if (Product.Class != null)
            {
                Class = Product.Class;
                ClassCheck = true;
            }
            else
                ClassCheck = false;

            if (Product.Style != null)
            {
                Style = Product.Style;
                StyleCheck = true;
            }
            else
                StyleCheck = false;

            if (Product.ProductSubcategoryID != null)
            {
                ProductSubcategory = GetProductSubcategoryName(Product.ProductSubcategoryID.Value);
                ProductSubcategoryCheck = true;
            }
            else
                ProductSubcategoryCheck = false;

            if (Product.ProductModelID != null)
            {
                ProductModel = GetProductModelName(Product.ProductModelID.Value);
                ProductModelCheck = true;
            }
            else
                ProductModelCheck = false;

            ProductNumber = Product.ProductNumber;
            Name = Product.Name;
            MakeFlag = Product.MakeFlag;
            FinishedGoodsFlag = Product.FinishedGoodsFlag;
            SafetyStockLevel = Product.SafetyStockLevel;
            ReorderPoint = Product.ReorderPoint;
            StandardCost = Product.StandardCost;
            ListPrice = Product.ListPrice;
            DaysToManufacture = Product.DaysToManufacture;
            SellStartDate = Product.SellStartDate;

            if (Product.SellEndDate != null)
                SellEndDate = Product.SellEndDate.Value;

            if (Product.DiscontinuedDate != null)
                DiscontinuedDate = Product.DiscontinuedDate.Value;
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

        private void BackToMainWindow()
        {
            CloseWindow();
        }
    }
}
