using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.MyProduct
{
    public interface iMyProductDataContext<T>
    {
        void Add(T item);

        void Add(List<T> list);

        bool Delete(int id);

        T Get(int id);

        List<T> GetAll();

        bool Update(T item);
    }
}
