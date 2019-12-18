using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IManageWindow GetWindow()
        {
            return new ManageModifyProductWindow();
        }
    }
}
