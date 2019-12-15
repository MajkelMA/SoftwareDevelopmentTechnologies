using System;
using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            AddProductViewModel addProductViewModel = (AddProductViewModel)DataContext;
            addProductViewModel.CloseWindow = () => this.Hide();
        }
    }
}
