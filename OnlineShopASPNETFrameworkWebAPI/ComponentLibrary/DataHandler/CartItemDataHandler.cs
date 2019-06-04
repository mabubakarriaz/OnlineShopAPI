using Com.CompanyName.OnlineShop.ComponentLibrary.Data;
using Com.CompanyName.OnlineShop.ComponentLibrary.Entity;
using Com.CompanyName.OnlineShop.ComponentLibrary.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.DataHandler
{
    public class CartItemDataHandler : IDataHandler<CartItem>, IDisposable
    {
        private OnlineShopContext _db = new OnlineShopContext();
        private string _connectionString;

        public CartItemDataHandler()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["yourconnectinstringName"].ConnectionString;
        }
        public CartItemDataHandler(string aConnectionString)
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

        public int Add(CartItem aType)
        {
            int key = -1;
            try
            {
                _db.Entry(aType).State = EntityState.Added;
                _db.SaveChanges();
                key = aType.CartItemId;
            }
            catch (Exception)
            {
                throw;
            }

            return key;
        }

        public int Change(CartItem aType)
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

        public int Remove(CartItem aType)
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

        public IEnumerable<CartItem> Get()
        {
            IEnumerable<CartItem> list = new List<CartItem>();

            try
            {
                list = _db.CartItems.ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        public CartItem Get(int key)
        {
            CartItem entity = new CartItem();

            try
            {
                entity = _db.CartItems.Find(key);
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public IEnumerable<CartItem> Get(string name)
        {
            IEnumerable<CartItem> list = new List<CartItem>();

            try
            {
                list = _db.CartItems.Where(w => w.Product.Name.Contains(name)).ToList();
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

        ~CartItemDataHandler()
        {
            Dispose(false);
        }
    }
}
