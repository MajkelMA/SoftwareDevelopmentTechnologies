using System.Windows;
using ViewModel;
using ViewModel.Interfaces;

namespace View.InterfaceImplementations
{
    class ManageModifyProductWindow : IManageWindow
    {
        public event MyHandler OnClose;
        private ModifyProductWindow _modifyProductWindow;

        public ManageModifyProductWindow()
        {
            _modifyProductWindow = new ModifyProductWindow();
        }

        public IManageWindow GetWindow()
        {
            return new ManageModifyProductWindow();
        }

        public void SetViewModel<T>(T viewModel) where T : IViewModel
        {
            _modifyProductWindow.DataContext = viewModel;
            viewModel.CloseWindow = () =>
            {
                if (OnClose != null)
                    OnClose.Invoke();
                _modifyProductWindow.Close();
            };
        }

        public void Show()
        {
            _modifyProductWindow.Show();
        }

        public void ShowPopup(string message)
        {
            MessageBox.Show(message);
        }
    }
}
