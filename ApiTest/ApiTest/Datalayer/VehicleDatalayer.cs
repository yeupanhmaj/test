using ApiTest.DataLayers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ApiTest.Datalayer
{
    public class VehicleDatalayer : BaseLayerData<VehicleDatalayer>
    {
        public VehicleViewModel GetVehicleInfo(SqlConnection connection, string VehicleNumber)
        {

            var info = new VehicleViewModel();
            using (var command = new SqlCommand("exec Ins_VehicleModel_GetVehicleInfo @VehicleNumber", connection))
            {
                AddSqlParameter(command, "@VehicleNumber", VehicleNumber, System.Data.SqlDbType.VarChar);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    info.VehicleId = GetDbReaderValue<Guid>(reader["VehicleId"]);
                    info.Type = GetDbReaderValue<int>(reader["Type"]);
                    info.VehicleNumber = GetDbReaderValue<string>(reader["VehicleNumber"]);
                    info.VehicleOwner = GetDbReaderValue<string>(reader["VehicleOwner"]);                   
                }
                return info;
            }
        }
    }
}
