using System.Windows.Input;
using ViewModel;

namespace View.Interfaces
{
    public class MainView : IWindow
    {
        


        public void show()
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.Show();
        }
    }
}
