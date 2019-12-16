using Model;
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

        public DataContext DataContext
        {
            get => _dataContext;
            set
            {
                _dataContext = value;
            }
        }
        #endregion

        public MainViewModel()
        {
            AddProductCommand = new MyCommand(ShowAddProductWindow);
        }

        #region Private
        private DataContext _dataContext;
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
