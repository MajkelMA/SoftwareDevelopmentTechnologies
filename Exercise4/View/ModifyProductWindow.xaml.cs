using System;
using System.Windows;
using ViewModel;

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

        //protected override void OnInitialized(EventArgs e)
        //{
        //    base.OnInitialized(e);
        //    ModifyProductViewModel modifyProductViewModel = (ModifyProductViewModel)DataContext;
        //    modifyProductViewModel.CloseWindow = () => this.Hide();
        //}
    }
}
