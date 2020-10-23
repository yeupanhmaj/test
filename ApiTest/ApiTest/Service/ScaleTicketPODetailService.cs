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
    public class ScaleTicketPODetailService:BaseService<ScaleTicketPODetailService>
    {
        public List<ScaleTicketPODetailViewModel> GetListScaleTicketPODetail(Guid ScaleTicketId)
        {
            ConnectionFactory sqlConnection = new ConnectionFactory();
            var record = new List<ScaleTicketPODetailViewModel>();
            using (SqlConnection connection = sqlConnection.GetConnection())
            {
                record = ScaleTicketPODetailDatalayer.GetInstance().GetListScaleTicketPODetail(connection, ScaleTicketId);
                return record;
            }
        }
    }
}
