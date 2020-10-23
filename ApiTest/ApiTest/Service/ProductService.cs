using ApiTest.Common;
using ApiTest.Datalayer;
using ApiTest.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Service
{
    public class ProductService:BaseService<ProductService>
    {
        public List<ProductModel> GetListProduct(bool isShowMobile)
        {
            ConnectionFactory sqlConnection = new ConnectionFactory();
            var record = new List<ProductModel>();
            using (SqlConnection connection = sqlConnection.GetConnection())
            {
                record = ProductDatalayer.GetInstance().GetListProduct(connection, isShowMobile);
                return record;
            }
        }
    }
}
