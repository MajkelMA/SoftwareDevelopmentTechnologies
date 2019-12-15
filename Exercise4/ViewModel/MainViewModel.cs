using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddProductCommand { get; private set; }
        public Lazy<IWindow> ChildWindow { get; set; }


        public MainViewModel()
        {
            //this.AddProductWindow() += PropertyChanged;
        }

        private void AddProductWindow()
        {
            IWindow _child = ChildWindow.Value;
            _child.show();
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
