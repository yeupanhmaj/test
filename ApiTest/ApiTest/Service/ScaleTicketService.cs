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
    public class ScaleTicketService:BaseService<ScaleTicketService>
    {
        public List<ScaleTicketViewModel> GetScaleTicket(Guid? ScaleTicketId)
        {
            ConnectionFactory sqlConnection = new ConnectionFactory();
            var record = new List<ScaleTicketViewModel>();
            using (SqlConnection connection = sqlConnection.GetConnection())
            {
                record = ScaleTicketDatalayer.GetInstance().GetScaleTicket(connection,ScaleTicketId);
                return record;
            }
        }
    }
}
