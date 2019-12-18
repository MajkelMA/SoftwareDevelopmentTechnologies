using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Interfaces;

namespace ViewModel
{
    public class AddProductViewModel : IViewModel
    {
        #region Properties
        public ICommand BackToMainWindowCommand { get; private set; }
        public ICommand AddProductCommand { get; private set; }
        public Action CloseWindow { get; set; }
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
        public DateTime ModifiedDate { get; set; }
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

        public AddProductViewModel()
        {
            AddProductCommand = new MyCommand(AddProduct);
            BackToMainWindowCommand = new MyCommand(BackToMainWindow);
        }

        public AddProductViewModel(ProductRepostiory productRepostiory, IMyPopup myPopup) : this()
        {
            this.productRepository = productRepostiory;
            ValidatorPopup = myPopup;
            InitDates();
            InitComboBox();
        }

        #region Private
        private void AddProduct()
        {
            string message = "";

            Product product = new Product();
            CheckCheckBox(product);

            if (Name != null && Name != "")
                product.Name = Name;
            else
                message += "Name is empty\n";

            if (ProductNumber != null)
                product.ProductNumber = ProductNumber;
            else
                message += "Product number is empty\n";

            product.MakeFlag = MakeFlag;
            product.FinishedGoodsFlag = FinishedGoodsFlag;
            product.SafetyStockLevel = SafetyStockLevel;
            product.ReorderPoint = ReorderPoint;
            product.StandardCost = StandardCost;
            product.ListPrice = ListPrice;
            product.DaysToManufacture = DaysToManufacture;

            product.SellStartDate = SellStartDate;

            if (SellEndDateCheck == true)
            {
                if (SellEndDate > SellStartDate)
                    product.SellEndDate = SellEndDate;
                else
                    message += "Sell end date is after sell start date\n";
            }

            if (DiscontinuedDateCheck == true)
            {
                product.DiscontinuedDate = DiscontinuedDate;
            }

            product.ModifiedDate = ModifiedDate;
            product.rowguid = Guid.NewGuid();

            if (message != "")
            {
                ValidatorPopup.ShowPopup(message);
            }
            else if (productRepository.Add(product))
            {
                ValidatorPopup.ShowPopup("Product added succefully!");
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
        #endregion

        #region Init
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
