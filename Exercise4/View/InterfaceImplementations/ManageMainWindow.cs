using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Interfaces;

namespace View.InterfaceImplementations
{
    class ManageMainWindow : IManageWindow
    {
        public event MyHandler OnClose;

        public IManageWindow GetWindow()
        {
            throw new NotImplementedException();
        }

        public void SetViewModel<T>(T viewModel) where T : IViewModel
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void ShowPopup(string message)
        {
            throw new NotImplementedException();
        }
    }
}
