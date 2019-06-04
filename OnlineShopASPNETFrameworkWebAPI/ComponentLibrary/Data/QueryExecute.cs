using System;
using System.Data;
using System.Data.SqlClient;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Data
{
    public class QueryExecute
    {
        /// <summary>
        /// Executes sql server stored procedure within a sql transaction using execute scalar, returns the first column of the first row in the result set or returns primary key
        /// </summary>
        /// <param name="spName">name of the store procedure</param>
        /// <param name="transaction">sql transaction object with connection string in it</param>
        /// <param name="parameters">all parameters that the store procedure accepts</param>
        /// <returns>responds with inserted primary key or any type of interger value</returns>
        internal static int StoredProcedureScalar(string spName, SqlTransaction transaction, params SqlParameter[] parameters)
        {
            int returnValue = -1;
            SqlConnection con = transaction.Connection;
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = transaction;
            cmd.Parameters.AddRange(parameters);

            try
            {
                returnValue = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException sx)
            {
                throw sx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnValue;
        }

        /// <summary>
        /// Executes sql server stored procedure using execute scalar, returns the first column of the first row in the result set or returns primary key
        /// </summary>
        /// <param name="connectionString">flat string type connection string for SP</param>
        /// <param name="spName">name of the store procedure</param>
        /// <param name="parameters">all parameters that the store procedure accepts</param>
        /// <returns>responds with inserted primary key or returns the first column of the first row in the result set.</returns>
        internal static int StoredProcedureScalar(string connectionString, string spName, params SqlParameter[] parameters)
        {
            int returnValue = -1;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters);
            con.Open();

            using (con)
            {
                try
                {
                    returnValue = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return returnValue;
        }

        /// <summary>
        /// Executes a parameter-less stored procedure using execute scalar, returns the first column of the first row in the result set or returns primary key
        /// </summary>
        /// <param name="connectionString">flat string type connection string for SP</param>
        /// <param name="spName">name of the store procedure</param>
        /// <returns>responds with inserted primary key or returns the first column of the first row in the result set.</returns>
        internal static int StoredProcedureScalar(string connectionString, string spName)
        {
            int returnValue = -1;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            using (con)
            {
                try
                {
                    returnValue = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (SqlException sx)
                {
                    throw sx;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Executes a query or paremeter-less stored procedure with the Connection using a SqlDataAdapter, returns a DataSet type object
        /// </summary>
        /// <param name="connectionString">flat string type connection string for SP</param>
        /// <param name="command">flat query or name of the store procedure</param>
        /// <param name="commandType">mention command type is query or SP</param>
        /// <returns>provide with DataSet object populated with complete entity</returns>
        internal static DataSet StoredProcedureReader(string connectionString, string command, CommandType commandType)
        {
            DataSet dataSet = new DataSet();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = commandType;
            con.Open();

            using (con)
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dataSet);
            }

            return dataSet;
        }

        /// <summary>
        /// Executes only a stored procedure with the Connection using a SqlDataAdapter, returns a DataSet type object
        /// </summary>
        /// <param name="connectionString">flat string type connection string for SP</param>
        /// <param name="spName">name of the store procedure</param>
        /// <param name="parameters">all parameters that the store procedure accepts</param>
        /// <returns>Provides with DataSet object populated with complete entity</returns>
        internal static DataSet StoredProcedureReader(string connectionString, string spName, params SqlParameter[] parameters)
        {
            DataSet dataSet = new DataSet();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters);
            con.Open();

            using (con)
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dataSet);
            }

            return dataSet;
        }
    }
}
