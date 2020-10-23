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
    public class VehicleService:BaseService<VehicleService>
    {
        public VehicleViewModel GetVehicleInfo(string vehicleNumber)
        {
            ConnectionFactory sqlConnection = new ConnectionFactory();
            VehicleViewModel record = new VehicleViewModel();
            using (SqlConnection connection = sqlConnection.GetConnection())
            {
                record = VehicleDatalayer.GetInstance().GetVehicleInfo(connection, vehicleNumber);
                return record;
            }
        }
    }
}
