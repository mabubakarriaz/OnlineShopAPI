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
    public class CartDataHandler : IDataHandler<Cart>, IDisposable
    {
        private OnlineShopContext _db = new OnlineShopContext();
        private string _connectionString;

        public CartDataHandler()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["yourconnectinstringName"].ConnectionString;
        }
        public CartDataHandler(string aConnectionString)
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

        public int Add(Cart aType)
        {
            int key = -1;
            try
            {
                _db.Entry(aType).State = EntityState.Added;
                _db.SaveChanges();
                key = aType.CartId;
            }
            catch (Exception)
            {
                throw;
            }

            return key;
        }

        public int Change(Cart aType)
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

        public int Remove(Cart aType)
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

        public IEnumerable<Cart> Get()
        {
            IEnumerable<Cart> list = new List<Cart>();

            try
            {
                list = _db.Carts.ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        public Cart Get(int key)
        {
            Cart entity = new Cart();

            try
            {
                entity = _db.Carts.Find(key);
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public IEnumerable<Cart> Get(string name)
        {
            IEnumerable<Cart> list = new List<Cart>();

            try
            {
                list = _db.Carts.Where(w => w.Customer.Name.Contains(name)).ToList();
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

        ~CartDataHandler()
        {
            Dispose(false);
        }
    }
}
