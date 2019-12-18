using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IRepository<T>
    {
        bool Add(T item);
        bool Delete(int id);
        bool Update(T item);
        T Get(int id);
        IQueryable<T> GetAll();
    }
}
