using ApiTest.DataLayers;
using ApiTest.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Datalayer
{
    public class ProductDatalayer:BaseLayerData<ProductDatalayer>
    {
        public List<ProductModel> GetListProduct(SqlConnection connection, bool isShowMobile)
        {
            var result = new List<ProductModel>();
            using (var command = new SqlCommand("exec Ins_ProductModel_GetProductShowMobile @isShowMobile", connection))
            {
                AddSqlParameter(command, "@isShowMobile", isShowMobile, System.Data.SqlDbType.Bit);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var info = new ProductModel();
                        info.ProductId = GetDbReaderValue<Guid>(reader["ProductId"]);
                        info.ProductCode = GetDbReaderValue<string>(reader["ProductCode"]);
                        info.ProductName = GetDbReaderValue<string>(reader["ProductName"]);
                        result.Add(info);
                    }
                }
                return result;
            }
            
        }
    }
}
