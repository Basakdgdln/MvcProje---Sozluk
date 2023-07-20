using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLAyer.Abstract
{
    public interface IRepository<T>
    {

        List<T> List();
        // void Update(T item);

        // p: parametre
        void Update(T p);
        void Delete(T p);
        void Insert(T p);

        T Get(Expression<Func<T, bool>> filter);

        List<T> List(Expression<Func<T, bool>> Filter);

    }
}
