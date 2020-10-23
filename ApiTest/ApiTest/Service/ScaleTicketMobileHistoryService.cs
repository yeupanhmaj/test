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
    public class ScaleTicketMobileHistoryService:BaseService<ScaleTicketMobileHistoryService>
    {
        public List<ScaleTicketMobileHistoryViewModel> GetScaleTicketMobileHistory(Guid? ScaleTicketId)
        {
            ConnectionFactory sqlConnection = new ConnectionFactory();
            var record = new List<ScaleTicketMobileHistoryViewModel>();
            using (SqlConnection connection = sqlConnection.GetConnection())
            {
                record = ScaleTicketMobileHistoryDatalayer.GetInstance().GetListScaleTicketMobileHistory(connection, ScaleTicketId);
                return record;
            }
        }
    }
}
