using log4net.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Common
{
    public class ConnectionFactory
    {
        private static SqlConnection cnn;
        //string conn = "data source=192.168.100.66;initial catalog=VAS_4000;user id=sa;password=123456a@;MultipleActiveResultSets=True;";
        /// <summary>
        /// Hàm tạo chuổi kết nối cơ sở dữ liệu SQL Server
        /// </summary>
        /// <returns>OdbcConnection trả về</returns>
        public SqlConnection GetConnection()
        {
            string _serverName = "192.168.100.66";
            string _dbName = "VAS_4000";
            string _userName = "sa";
            string _passWord = "123456a@";
            string conn = String.Format("data source={0};" +
                "initial catalog={1};" +
                "user id={2};" +
                "password={3};" +
                "MultipleActiveResultSets=True;", _serverName, _dbName, _userName, _passWord);
            cnn = new SqlConnection(conn);
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
            cnn.Open();
            return cnn;
        }
    }
}
