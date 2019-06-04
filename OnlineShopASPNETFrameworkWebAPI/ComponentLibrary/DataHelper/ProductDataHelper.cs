using Com.CompanyName.OnlineShop.ComponentLibrary.Data;
using Com.CompanyName.OnlineShop.Entity.ComponentLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.DataHelper
{
    internal class ProductDataHelper : IDataHelper<Product>
    {
        private string _ConnectionString { get; set; }
        public ProductDataHelper(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        private readonly string SP_INSERT = "dbo.usp_Product_INSERT";
        private readonly string SP_UPDATE = "dbo.usp_Product_UPDATE";
        private readonly string SP_DELETE = "dbo.usp_Product_DELETE";

        private readonly string SP_SELECT = "dbo.usp_Product_SELECT";
        //private readonly string SP_SELECTBy = "dbo.usp_Product_SELECTBy";
        private readonly string VW_SELECT = "Select * from dbo.vw_Products";
        private readonly string SP_SEARCH = "dbo.usp_Product_SEARCH";

        public int Delete(Product entity)
        {
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ProductId", entity.ProductId)
            };

            return QueryExecute.StoredProcedureScalar(_ConnectionString, SP_DELETE, SP_Parameters);
        }

        public int Insert(Product entity)
        {
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ProductId", entity.ProductId)
                ,new SqlParameter("@Name", entity.Name)
                ,new SqlParameter("@Description", entity.Description)
            };

            return QueryExecute.StoredProcedureScalar(_ConnectionString, SP_INSERT, SP_Parameters);
        }

        public int Update(Product entity)
        {
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ProductId", entity.ProductId)
                ,new SqlParameter("@Name", entity.Name)
                ,new SqlParameter("@Description", entity.Description)
            };

            return QueryExecute.StoredProcedureScalar(_ConnectionString, SP_UPDATE, SP_Parameters);
        }

        public IEnumerable<Product> Select()
        {
            List<Product> list = new List<Product>();

            //Run Query
            DataSet dataSet = QueryExecute.StoredProcedureReader(_ConnectionString, VW_SELECT, CommandType.Text);

            foreach (DataRow row in dataSet.Tables[0].Rows) //single dataset
            {
                Product a = new Product(row);

                //add to list
                list.Add(a);
            }

            return list;
        }

        public Product Select(int key)
        {

            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ProductId", key)
                };

            //Run Query
            DataSet dataSet = QueryExecute.StoredProcedureReader(_ConnectionString, SP_SELECT, SP_Parameters);

            return new Product(dataSet.Tables[0].Rows[0]); //single dataset single row
        }

        public IEnumerable<Product> Find(string name)
        {
            List<Product> list = new List<Product>();

            SqlParameter[] SP_Parameters = {
                new SqlParameter("@name", name)
                };

            //Run Query
            DataSet dataSet = QueryExecute.StoredProcedureReader(_ConnectionString, SP_SEARCH, SP_Parameters);

            foreach (DataRow row in dataSet.Tables[0].Rows) //single dataset
            {
                Product entity = new Product(row);

                //add to list
                list.Add(entity);
            }

            return list;
        }
    }
}
