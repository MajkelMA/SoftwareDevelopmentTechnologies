using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ViewModel.Interfaces;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Product _Product;
        private List<Product> products;
        #endregion

        #region Properties
        public ICommand AddProductCommand { get; private set; }
        public ICommand ModifyProductCommand { get; private set; }
        public ICommand DeleteProductCommand { get; private set; }
        public ICommand ChangeSelectedProduct { get; private set; }
        public IWindow MainWindow { get; set; }
        public IWindow AddWindow { get; set; }
        public ProductRepostiory ProductRepository { get; set; }
        public Product Product
        {
            get { return _Product; }
            set
            {
                _Product = value;
                RaisePropertyChanged("Product");
                ChangeSelectedProduct.Execute(null);
            }
        }
        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                RaisePropertyChanged("Products");

            }
        }
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

        #region Selected Product Field
        private string _Name;
        private string _ProductNumber;
        private bool _MakeFlag;
        private bool _FinishedGoodsFlag;
        private string _Color;
        private Int16 _SafetyStockLevel;
        private Int16 _ReorderPoint;
        private decimal _StandardCost;
        private decimal _ListPrice;
        private string _Size;
        private string _SizeUnitMeasureCode;
        private string _WeightUnitMeasureCode;
        private decimal? _Weight;
        private int _DaysToManufacture;
        private string _ProductLine;
        private string _Class;
        private string _Style;
        private string _ProductSubcategory;
        private string _ProductModel;
        private DateTime _SellStartDate;
        private DateTime? _SellEndDate;
        private DateTime? _DiscontinuedDate;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }
        public string ProductNumber
        {
            get
            {
                return _ProductNumber;
            }
            set
            {
                _ProductNumber = value;
                RaisePropertyChanged("ProductNumber");
            }
        }
        public bool MakeFlag
        {
            get
            {
                return _MakeFlag;
            }
            set
            {
                _MakeFlag = value;
                RaisePropertyChanged("MakeFlag");
            }
        }
        public bool FinishedGoodsFlag
        {
            get
            {
                return _FinishedGoodsFlag;
            }
            set
            {
                _FinishedGoodsFlag = value;
                RaisePropertyChanged("FinishedGoodsFlag");
            }
        }
        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
                RaisePropertyChanged("Color");
            }
        }
        public Int16 SafetyStockLevel
        {
            get
            {
                return _SafetyStockLevel;
            }
            set
            {
                _SafetyStockLevel = value;
                RaisePropertyChanged("SafetyStockLevel");
            }
        }
        public Int16 ReorderPoint
        {
            get
            {
                return _ReorderPoint;
            }
            set
            {
                _ReorderPoint = value;
                RaisePropertyChanged("ReorderPoint");
            }
        }
        public decimal StandardCost
        {
            get
            {
                return _StandardCost;
            }
            set
            {
                _StandardCost = value;
                RaisePropertyChanged("StandardCost");
            }
        }
        public decimal ListPrice
        {
            get
            {
                return _ListPrice;
            }
            set
            {
                _ListPrice = value;
                RaisePropertyChanged("ListPrice");
            }
        }
        public string Size
        {
            get
            {
                return _Size;
            }
            set
            {
                _Size = value;
                RaisePropertyChanged("Size");
            }
        }
        public string SizeUnitMeasureCode
        {
            get
            {
                return _SizeUnitMeasureCode;
            }
            set
            {
                _SizeUnitMeasureCode = value;
                RaisePropertyChanged("SizeUnitMeasureCode");
            }
        }
        public string WeightUnitMeasureCode
        {
            get
            {
                return _WeightUnitMeasureCode;
            }
            set
            {
                _WeightUnitMeasureCode = value;
                RaisePropertyChanged("WeightUnitMeasureCode");
            }
        }
        public decimal? Weight
        {
            get
            {
                return _Weight;
            }
            set
            {
                _Weight = value;
                RaisePropertyChanged("Weight");
            }
        }
        public int DaysToManufacture
        {
            get
            {
                return _DaysToManufacture;
            }
            set
            {
                _DaysToManufacture = value;
                RaisePropertyChanged("DaysToManufacture");
            }
        }
        public string ProductLine
        {
            get
            {
                return _ProductLine;
            }
            set
            {
                _ProductLine = value;
                RaisePropertyChanged("ProductLine");
            }
        }
        public string Class
        {
            get
            {
                return _Class;
            }
            set
            {
                _Class = value;
                RaisePropertyChanged("Class");
            }
        }
        public string Style
        {
            get
            {
                return _Style;
            }
            set
            {
                _Style = value;
                RaisePropertyChanged("Style");
            }
        }
        public string ProductSubcategory
        {
            get
            {
                return _ProductSubcategory;
            }
            set
            {
                _ProductSubcategory = value;
                RaisePropertyChanged("ProductSubcategory");
            }
        }
        public string ProductModel
        {
            get
            {
                return _ProductModel;
            }
            set
            {
                _ProductModel = value;
                RaisePropertyChanged("ProductModel");
            }
        }
        public DateTime SellStartDate
        {
            get
            {
                return _SellStartDate;
            }
            set
            {
                _SellStartDate = value;
                RaisePropertyChanged("SellStartDate");
            }
        }
        public DateTime? SellEndDate
        {
            get
            {
                return _SellEndDate;
            }
            set
            {
                _SellEndDate = value;
                RaisePropertyChanged("SellEndDate");
            }
        }
        public DateTime? DiscontinuedDate
        {
            get
            {
                return _DiscontinuedDate;
            }
            set
            {
                _DiscontinuedDate = value;
                RaisePropertyChanged("DiscontinuedDate");
            }
        }
        #endregion

        #region CheckBox
        private bool _ColorCheck;
        private bool _SizeCheck;
        private bool _SizeUnitMeasureCodeCheck;
        private bool _WeightUnitMeasureCodeCheck;
        private bool _WeightCheck;
        private bool _ProductLineCheck;
        private bool _ClassCheck;
        private bool _StyleCheck;
        private bool _ProductSubcategoryCheck;
        private bool _ProductModelCheck;
        private bool _SellEndDateCheck;
        private bool _DiscontinuedDateCheck;

        public bool ColorCheck
        {
            get
            {
                return _ColorCheck;
            }
            set
            {
                _ColorCheck = value;
                RaisePropertyChanged("ColorCheck");
            }
        }
        public bool SizeCheck
        {
            get { return _SizeCheck; }
            set
            {
                _SizeCheck = value;
                RaisePropertyChanged("SizeCheck");
            }
        }
        public bool SizeUnitMeasureCodeCheck
        {
            get
            {
                return _SizeUnitMeasureCodeCheck;
            }
            set
            {
                _SizeUnitMeasureCodeCheck = value;
                RaisePropertyChanged("SizeUnitMeasureCodeCheck");
            }
        }
        public bool WeightUnitMeasureCodeCheck
        {
            get
            {
                return _WeightUnitMeasureCodeCheck;
            }
            set
            {
                _WeightUnitMeasureCodeCheck = value;
                RaisePropertyChanged("WeightUnitMeasureCodeCheck");
            }
        }
        public bool WeightCheck
        {
            get
            {
                return _WeightCheck;
            }
            set
            {
                _WeightCheck = value;
                RaisePropertyChanged("WeightCheck");
            }
        }
        public bool ProductLineCheck
        {
            get
            {
                return _ProductLineCheck;
            }
            set
            {
                _ProductLineCheck = value;
                RaisePropertyChanged("ProductLineCheck");
            }
        }
        public bool ClassCheck
        {
            get
            {
                return _ClassCheck;
            }
            set
            {
                _ClassCheck = value;
                RaisePropertyChanged("ClassCheck");
            }
        }
        public bool StyleCheck
        {
            get
            {
                return _StyleCheck;
            }
            set
            {
                _StyleCheck = value;
                RaisePropertyChanged("StyleCheck");
            }
        }
        public bool ProductSubcategoryCheck
        {
            get
            {
                return _ProductSubcategoryCheck;
            }
            set
            {
                _ProductSubcategoryCheck = value;
                RaisePropertyChanged("ProductSubcategoryCheck");
            }
        }
        public bool ProductModelCheck
        {
            get
            {
                return _ProductModelCheck;
            }
            set
            {
                _ProductModelCheck = value;
                RaisePropertyChanged("ProductModelCheck");
            }
        }
        public bool SellEndDateCheck
        {
            get
            {
                return _SellEndDateCheck;
            }
            set
            {
                _SellEndDateCheck = value;
                RaisePropertyChanged("SellEndDateCheck");
            }
        }
        public bool DiscontinuedDateCheck
        {
            get
            {
                return _DiscontinuedDateCheck;
            }
            set
            {
                _DiscontinuedDateCheck = value;
                RaisePropertyChanged("DiscontinuedDateCheck");
            }
        }
        #endregion

        public MainViewModel()
        {
            AddProductCommand = new MyCommand(AddProduct);
            ModifyProductCommand = new MyCommand(ModifyProduct);
            DeleteProductCommand = new MyCommand(DeleteProduct);
            ChangeSelectedProduct = new MyCommand(OnProductChanged);

            ProductRepository = new ProductRepostiory();
            ProductRepository.ChangeInCollection += OnProductsChanged;

            Products = ProductRepository.GetAllProduct();
            Product = new Product();
            Product.SellStartDate = DateTime.Now;
            InitComboBox();
            if (Product != null)
                InitModifyProduct();
        }

        #region Add Product region
        private void AddProduct()
        {
            Product productToAdd = new Product();
            SaveDataToProduct(productToAdd, out string message);
            if (message != "")
            {
                MainWindow.ShowPopup(message);

            }
            else if (ProductRepository.Add(productToAdd))
            {
                MainWindow.ShowPopup("Add success");
            }
            else
            {
                MainWindow.ShowPopup("Add failed");
            }
        }
        #endregion

        #region Delete Product region
        private void DeleteProduct()
        {
            if (Product.ProductID != 0)
            {
                if (ProductRepository.Delete(Product.ProductID))
                {
                    MainWindow.ShowPopup("Delete success");
                }
                else
                {
                    MainWindow.ShowPopup("Delete failed");
                }
            }
            else
            {
                MainWindow.ShowPopup("please, Select a product");
            }
        }
        #endregion

        #region Modify Product methods
        private void ModifyProduct()
        {
            SaveDataToProduct(Product, out string message);
            if (message != "")
            {

                MainWindow.ShowPopup(message);
            }
            else if (ProductRepository.Update(Product))
            {
                MainWindow.ShowPopup("Product modified succefully!");
            }
            else
            {
                MainWindow.ShowPopup("Product modify failed!");
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


        private void SaveDataToProduct(Product product, out string message)
        {
            message = "";

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
            product.ModifiedDate = DateTime.Now;

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
        }
        #endregion

        #region Private Method (Subcategory and Model)
        private int GetProductSubcategoryID(string productSubcategoryName)
        {
            List<Product> products = ProductRepository.GetAllProduct();
            return (from product in products
                    where product.ProductSubcategoryID != null && product.ProductSubcategory.Name.Equals(productSubcategoryName)
                    select product.ProductSubcategory.ProductSubcategoryID).First();
        }

        private string GetProductSubcategoryName(int index)
        {
            List<Product> products = ProductRepository.GetAllProduct();
            return (from product in products
                    where product.ProductSubcategoryID != null && product.ProductSubcategoryID == index
                    select product.ProductSubcategory.Name).First();
        }

        private int GetProductModelID(string productModelName)
        {
            List<Product> products = ProductRepository.GetAllProduct();
            return (from product in products
                    where product.ProductModelID != null && product.ProductModel.Name.Equals(productModelName)
                    select product.ProductModel.ProductModelID).First();
        }

        private string GetProductModelName(int index)
        {
            List<Product> products = ProductRepository.GetAllProduct();
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
            {
                Color = null;
                ColorCheck = false;
            }

            if (Product.Size != null)
            {
                Size = Product.Size;
                SizeCheck = true;
            }
            else
            {
                Size = null;
                SizeCheck = false;
            }

            if (Product.SizeUnitMeasureCode != null)
            {
                SizeUnitMeasureCode = Product.SizeUnitMeasureCode;
                SizeUnitMeasureCodeCheck = true;
            }
            else
            {
                SizeUnitMeasureCode = null;
                SizeUnitMeasureCodeCheck = false;
            }

            if (Product.WeightUnitMeasureCode != null)
            {
                WeightUnitMeasureCode = Product.WeightUnitMeasureCode;
                WeightUnitMeasureCodeCheck = true;
            }
            else
            {
                WeightUnitMeasureCode = null;
                WeightUnitMeasureCodeCheck = false;
            }

            if (Product.Weight != null)
            {
                Weight = Product.Weight.Value;
                WeightCheck = true;
            }
            else
            {
                Weight = null;
                WeightCheck = false;
            }

            if (Product.ProductLine != null)
            {
                ProductLine = Product.ProductLine;
                ProductLineCheck = true;
            }
            else
            {
                ProductLine = null;
                ProductLineCheck = false;
            }

            if (Product.Class != null)
            {
                Class = Product.Class;
                ClassCheck = true;
            }
            else
            {
                Class = null;
                ClassCheck = false;
            }

            if (Product.Style != null)
            {
                Style = Product.Style;
                StyleCheck = true;
            }
            else
            {
                Style = null;
                StyleCheck = false;
            }

            if (Product.ProductSubcategoryID != null)
            {
                ProductSubcategory = GetProductSubcategoryName(Product.ProductSubcategoryID.Value);
                ProductSubcategoryCheck = true;
            }
            else
            {
                ProductSubcategory = null;
                ProductSubcategoryCheck = false;
            }

            if (Product.ProductModelID != null)
            {
                ProductModel = GetProductModelName(Product.ProductModelID.Value);
                ProductModelCheck = true;
            }
            else
            {
                ProductModel = null;
                ProductModelCheck = false;
            }

            if (Product.SellEndDate != null)
            {
                SellEndDate = Product.SellEndDate.Value;
                SellEndDateCheck = true;
            }
            else
            {
                SellEndDate = null;
                SellEndDateCheck = false;
            }

            if (Product.DiscontinuedDate != null)
            {
                DiscontinuedDate = Product.DiscontinuedDate.Value;
                DiscontinuedDateCheck = true;
            }
            else
            {
                DiscontinuedDate = null;
                DiscontinuedDateCheck = false;
            }

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

        }

        private void InitComboBox()
        {
            List<Product> products = ProductRepository.GetAllProduct();
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

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnProductChanged()
        {
            if (Product != null)
                InitModifyProduct();
        }

        public void OnProductsChanged()
        {
            this.Products = ProductRepository.GetAllProduct();
        }
        #endregion
    }
}
