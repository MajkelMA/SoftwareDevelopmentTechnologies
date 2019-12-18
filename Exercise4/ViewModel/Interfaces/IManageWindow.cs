using System;
using ViewModel.Interfaces;

namespace ViewModel
{
    public interface IManageWindow
    {
        void Show();
        void SetViewModel<T>(T viewModel) where T : IViewModel;
        event MyHandler OnClose;
        IManageWindow GetWindow();
    }

    public delegate void MyHandler();
}
