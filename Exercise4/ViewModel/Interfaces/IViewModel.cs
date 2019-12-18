using System;

namespace ViewModel.Interfaces
{
    public interface IViewModel
    {
        Action CloseWindow { get; set; }
    }
}
