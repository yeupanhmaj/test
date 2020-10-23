using ApiTest.Common;
using ApiTest.Datalayer;
using ApiTest.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ApiTest.Service
{
    public class ScaleTicketPODetailMobileModelService:BaseService<ScaleTicketPODetailMobileModelService>
    {
        public List<ScaleTicketPODetailViewModel> pGetListScaleTicketPOMobileDetail(Guid? ScaleTicketId)
        {
            ConnectionFactory sqlConnection = new ConnectionFactory();
            var record = new List<ScaleTicketPODetailViewModel>();
            using (SqlConnection connection = sqlConnection.GetConnection())
            {
                record = ScaleTicketPODetailMobileModelDatalayer.GetInstance().pGetListScaleTicketPOMobileDetail(connection, ScaleTicketId);
                return record;
            }
        }
    }
}
