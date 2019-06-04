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
    public class CustomerDataHandler : IDataHandler<Customer>, IDisposable
    {
        private OnlineShopContext _db = new OnlineShopContext();
        private string _connectionString;



        public CustomerDataHandler()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["yourconnectinstringName"].ConnectionString;
        }

        public CustomerDataHandler(string aConnectionString)
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

        public int Add(Customer aType)
        {
            int key = -1;

            try
            {
                _db.Entry(aType).State = EntityState.Added;
                _db.SaveChanges();
                key = aType.CustomerId;
            }
            catch (Exception)
            {
                throw;
            }

            return key;
        }

        public int Change(Customer aType)
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

        public int Remove(Customer aType)
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

        public IEnumerable<Customer> Get()
        {
            IEnumerable<Customer> list = new List<Customer>();

            try
            {
                list = _db.Customers.ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        public Customer Get(int key)
        {
            Customer entity = new Customer();

            try
            {
                entity = _db.Customers.Find(key);
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public IEnumerable<Customer> Get(string name)
        {
            IEnumerable<Customer> list = new List<Customer>();

            try
            {
                list = _db.Customers.Where(w => w.Name.Contains(name)).ToList();
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

        ~CustomerDataHandler()
        {
            Dispose(false);
        }

    }
}
