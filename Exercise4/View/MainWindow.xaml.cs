using System;
using System.Windows;
using System.Windows.Input;
using View.InterfaceImplementations;
using ViewModel;
using ViewModel.Interfaces;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IManageWindow
    {
        public event MyHandler OnClose;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            MainViewModel mainViewModel = (MainViewModel)DataContext;
            mainViewModel.ManageAddWindow = new ManageAddProductWindow();
            mainViewModel.ManageModifyWindow = new ManageModifyProductWindow();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).ModifyProductCommand.Execute(null);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).AddProductCommand.Execute(null);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).DeleteProductCommand.Execute(null);
        }

        public void ShowPopup(string message)
        {
            MessageBox.Show(message);
        }

        public void SetViewModel<T>(T viewModel) where T : IViewModel
        {
            this.DataContext = viewModel;
            viewModel.CloseWindow = () =>
            {
                if (OnClose != null)
                    OnClose.Invoke();
                this.Close();
            };
        }

        public IManageWindow GetWindow()
        {
            return this;
        }
    }
}
