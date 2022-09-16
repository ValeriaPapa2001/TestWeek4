using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Core.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(object id);

        IEnumerable<T> Fetch(Func<T, bool> filter = null);

        bool Update(T entity);

        bool DeleteById(object id);

        bool Insert(T entity);
    }
}
