using Com.CompanyName.OnlineShop.ComponentLibrary.Data;
using Com.CompanyName.OnlineShop.ComponentLibrary.DataHelper;
using Com.CompanyName.OnlineShop.Entity.ComponentLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.DataHandler
{
    public class ProductDataHandler : IDataHandler<Product>
    {
        public ProductDataHandler()
        {
            ConnectionString= ConfigurationManager.ConnectionStrings["yourconnectinstringName"].ConnectionString;
        }

        public string ConnectionString { get; set; }

        public int Add(Product aType)
        {
           
            int key = -1;

            try
            {
                key = new ProductDataHelper(ConnectionString).Insert(aType);
            }
            catch (Exception)
            {
                throw;
            }

            return key;
        }

        public void Change(Product aType)
        {
            try
            {
                new ProductDataHelper(ConnectionString).Update(aType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(Product aType)
        {
            try
            {
                new ProductDataHelper(ConnectionString).Delete(aType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Product> Get()
        {
            List<Product> list = new List<Product>();

            try
            {
                list = (List<Product>) new ProductDataHelper(ConnectionString).Select();
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        public Product Get(int key)
        {
            Product entity = new Product();

            try
            {
                entity = new ProductDataHelper(ConnectionString).Select(key);
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public IEnumerable<Product> Get(string name)
        {
            List<Product> list = new List<Product>();

            try
            {
                list = (List<Product>)new ProductDataHelper(ConnectionString).Find(name);
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

    }
}
