using System.Windows;
using ViewModel;
using ViewModel.Interfaces;

namespace View.InterfaceImplementations
{
    class ManageAddProductWindow : IManageWindow
    {
        public event MyHandler OnClose;
        private AddProductWindow _addProductWindow;

        public ManageAddProductWindow()
        {
            _addProductWindow = new AddProductWindow();
        }

        public IManageWindow GetWindow()
        {
            return new ManageAddProductWindow();
        }

        public void SetViewModel<T>(T viewModel) where T : IViewModel
        {
            _addProductWindow.DataContext = viewModel;
            viewModel.CloseWindow = () =>
            {
                if (OnClose != null)
                    OnClose.Invoke();
                _addProductWindow.Close();
            };
        }

        public void Show()
        {
            _addProductWindow.Show();
        }

        public void ShowPopup(string message)
        {
            MessageBox.Show(message);
        }
    }
}
