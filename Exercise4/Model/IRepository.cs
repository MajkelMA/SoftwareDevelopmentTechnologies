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
        bool Delete(string id);
        T Get(string id);
        void Update(T item);
    }
}
