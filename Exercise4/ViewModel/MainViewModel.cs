﻿using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            AddProductCommand = new RelayCommand(ShowAddProductWindow);
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
