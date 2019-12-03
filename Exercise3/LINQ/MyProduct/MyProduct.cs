using System.ComponentModel;

namespace LINQ.MyProduct
{
    public class MyProduct : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public int productID { get; set; }

        public string name { get; set; }

        public string productNumber { get; set; }

        public MyProduct(Product product)
        {
            productID = product.ProductID;
            name = product.Name;
            productNumber = product.ProductNumber;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
    }
}
