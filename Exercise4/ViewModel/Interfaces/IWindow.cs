using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface IWindow
    {
        void Show();
        void Close();
        void ShowPopup(string message);
    }
}
