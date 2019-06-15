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
    public class CategoryDataHandler : IDataHandler<Category>, IDisposable
    {
        private OnlineShopContext _db = new OnlineShopContext();
        private string _connectionString;

        public CategoryDataHandler()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["OnlineShop"].ConnectionString;
        }
        public CategoryDataHandler(string aConnectionString)
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

        public int Add(Category aType)
        {
            int key = -1;
            try
            {
                _db.Entry(aType).State = EntityState.Added;
                _db.SaveChanges();
                key = aType.CategoryId;
            }
            catch (Exception)
            {
                throw;
            }

            return key;
        }

        public int Change(Category aType)
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

        public int Remove(Category aType)
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

        public IEnumerable<Category> Get()
        {
            IEnumerable<Category> list = new List<Category>();

            try
            {
                list = _db.Categories.ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        public Category Get(int key)
        {
            Category entity = new Category();

            try
            {
                entity = _db.Categories.Find(key);
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public bool Exists(int key)
        {
            return Get(key).CategoryId > 0;
        }

        public IEnumerable<Category> Find(string name)
        {
            IEnumerable<Category> list = new List<Category>();

            try
            {
                list = _db.Categories.Where(w => w.CategoryName.Contains(name)).ToList();
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

        ~CategoryDataHandler()
        {
            Dispose(false);
        }
    }
}
