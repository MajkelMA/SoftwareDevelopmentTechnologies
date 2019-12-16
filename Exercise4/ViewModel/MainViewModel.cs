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

        public Window Window { get; set; }

        public ProductRepostiory ProductRepostiory { get; set; }
        private List<Product> products;
        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
            }
        }


        #endregion

        public MainViewModel()
        {
            AddProductCommand = new MyCommand(ShowAddProductWindow);
            this.ProductRepostiory = new ProductRepostiory();
            this.Products = ProductRepostiory.GetAllProduct();
        }

        #region Private
        private void ShowAddProductWindow()
        {
            Window.Show();
        }
        #endregion

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
