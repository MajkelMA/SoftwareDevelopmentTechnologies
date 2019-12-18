using System;
using ViewModel.Interfaces;

namespace ViewModel
{
    public interface IManageWindow : IMyPopup
    {
        void Show();
        void SetViewModel<T>(T viewModel) where T : IViewModel;
        event MyHandler OnClose;
        IManageWindow GetWindow();
        void ShowPopup(string message);
    }

    public delegate void MyHandler();
}
