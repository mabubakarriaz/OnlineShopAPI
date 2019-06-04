using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Data
{
    public interface IDataHandler<T>
    {
        string ConnectionString { get; set; }

        int Add(T aType);

        int Change(T aType);

        int Remove(T aType);

        IEnumerable<T> Get();

        T Get(int key);

        IEnumerable<T> Get(string name);
    }
}
