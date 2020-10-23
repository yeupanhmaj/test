using ApiTest.Common;
using ApiTest.Datalayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ViewModels;

namespace ApiTest.Service
{
    public class ScaleTicketMobileModelService:BaseService<ScaleTicketMobileModelService>
    {
        public List<ScaleTicketViewModel> pGetScaleTicketMobile(Guid? ScaleTicketId)
        {
            ConnectionFactory sqlConnection = new ConnectionFactory();
            var record = new List<ScaleTicketViewModel>();
            using (SqlConnection connection = sqlConnection.GetConnection())
            {
                record = ScaleTicketMobileModelDatalayer.GetInstance().GetScaleTicketMobile(connection, ScaleTicketId);
                return record;
            }
        }
    }
}
