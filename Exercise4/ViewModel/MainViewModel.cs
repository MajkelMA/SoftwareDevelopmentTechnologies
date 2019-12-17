using Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddProductCommand { get; private set; }

        public ICommand ModifyProductCommand { get; private set; }

        public Window AddProductWindow { get; set; }

        public Window ModifyProductWindow { get; set; }

        public ProductRepostiory ProductRepostiory { get; set; }
        private List<Product> products;

        private Product product;
        public Product Product
        {
            get { return product; }
            set
            {
                product = value;
                RaisePropertyChanged("Product");
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
        #endregion

        public MainViewModel()
        {
            AddProductCommand = new MyCommand(ShowAddProductWindow);
            ModifyProductCommand = new MyCommand(ShowModifyProductWindow);
            this.ProductRepostiory = new ProductRepostiory();
            this.ProductRepostiory.ChangeInCollection += OnProductsChanged;
            this.Products = ProductRepostiory.GetAllProduct();
        }

        public void OnProductsChanged()
        {
            MessageBox.Show("Hello, world!");
            this.Products = ProductRepostiory.GetAllProduct();
        }


        #region Private
        private void ShowAddProductWindow()
        {
            AddProductWindow.Show();
        }

        private void ShowModifyProductWindow()
        {
            ProductRepostiory.Add(ProductRepostiory.Get(1));
            ModifyProductWindow.Show();
        }
        #endregion

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
