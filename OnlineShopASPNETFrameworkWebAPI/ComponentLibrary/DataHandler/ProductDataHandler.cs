using Com.CompanyName.OnlineShop.ComponentLibrary.Data;
using Com.CompanyName.OnlineShop.ComponentLibrary.Entity;
using Com.CompanyName.OnlineShop.ComponentLibrary.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.DataHandler
{
    public class ProductDataHandler : IDataHandler<Product>, IDisposable
    {
        private OnlineShopContext _db = new OnlineShopContext();
        private string _connectionString;



        public ProductDataHandler()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShop"].ConnectionString;
        }

        public ProductDataHandler(string aConnectionString)
        {
            ConnectionString = aConnectionString;
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                _connectionString = value;
                _db.Database.Connection.ConnectionString = _connectionString;
            }
        }

        public int Add(Product aType)
        {
            int key = -1;

            try
            {
                _db.Entry(aType).State = EntityState.Added;
                _db.SaveChanges();
                key = aType.ProductId;
            }
            catch (Exception)
            {
                throw;
            }

            return key;
        }

        public int Change(Product aType)
        {
            try
            {
                _db.Entry(aType).State = EntityState.Modified;
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Remove(Product aType)
        {
            try
            {
                _db.Entry(aType).State = EntityState.Deleted;
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Product> Get()
        {
            IEnumerable<Product> list = new List<Product>();

            try
            {
                list = _db.Products.ToList();
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
                entity = _db.Products.Find(key);
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public IEnumerable<Product> Get(string name)
        {
            IEnumerable<Product> list = new List<Product>();

            try
            {
                list = _db.Products.Where(w => w.Name.Contains(name)).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        ~ProductDataHandler()
        {
            Dispose(false);
        }

    }
}
