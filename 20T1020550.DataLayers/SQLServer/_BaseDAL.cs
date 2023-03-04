using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20T1020550.DataLayers.SQLServer
{
    /// <summary>
    /// Lớp cơ sở cho các lớp xử lý dữ liệu liên quan đến SQL sever
    /// </summary>
    public abstract class _BaseDAL
    { 
        /// <summary>
        /// Chuỗi tham số kết nối CSDL
        /// </summary>
        protected string _connectionString; // Access Modifier
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="connecttionString"></param>
        public _BaseDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}
