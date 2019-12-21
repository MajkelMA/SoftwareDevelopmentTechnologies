using System;
using System.Windows;
using ViewModel;
using ViewModel.Interfaces;

namespace View
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window, IWindow
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            AddProductViewModel addProductViewModel = (AddProductViewModel)DataContext;
            addProductViewModel.AddWindow = this;
        }
        public void ShowPopup(string message)
        {
            MessageBox.Show(message);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
