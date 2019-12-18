using System.Windows;
using ViewModel.Interfaces;

namespace View
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window, IMyPopup
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        public void ShowPopup(string message)
        {
            MessageBox.Show(message);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
