using System.Windows;

namespace View
{
    /// <summary>
    /// Interaction logic for ModifyProductWindow.xaml
    /// </summary>
    public partial class ModifyProductWindow : Window
    {
        public ModifyProductWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
