using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Data
{
    public interface IDataHelper<T>
    {
        int Delete(T entity);

        int Insert(T entity);

        int Update(T entity);

        IEnumerable<T> Select();

        T Select(int key);

        IEnumerable<T> Find(string name);
       
    }
}
