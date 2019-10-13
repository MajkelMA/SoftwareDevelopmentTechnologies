using ClassWarehouseLibrary;

namespace WarehouseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext _DataContext = new DataContext();
            DataRepository _DataRepository = new DataRepository(_DataContext, new AutoFill());
        }
    }
}
