using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IDataContext<T>
    {
        IQueryable<T> GetItems();
        bool Add(T item);
        bool Delete(T item);
        bool Update(T item);
        T Get(int id);
    }
}
