using ApiTest.Common;
using ApiTest.Datalayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ApiTest.Service
{
    public class GateListService:BaseService<GateListService>
    {
        public List<GateViewModel> GetGateList()
        {
            ConnectionFactory sqlConnection = new ConnectionFactory();
            var record = new List<GateViewModel>();
            using (SqlConnection connection = sqlConnection.GetConnection())
            {
                record = GateListDatalayer.GetInstance().GetGateList(connection);
                return record;
            }
        }
    }
}
