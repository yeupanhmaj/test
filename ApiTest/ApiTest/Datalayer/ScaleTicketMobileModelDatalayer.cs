using ApiTest.DataLayers;
using ApiTest.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ApiTest.Datalayer
{
    public class ScaleTicketMobileModelDatalayer:BaseLayerData<ScaleTicketMobileModelDatalayer>
    {
        public List<ScaleTicketViewModel> GetScaleTicketMobile(SqlConnection connection, Guid? ScaleTicketId)
        {
            var result = new List<ScaleTicketViewModel>();
            using (var command = new SqlCommand("exec Ins_ScaleTicketMobileModel_GetByScaleTicketMobileId @ScaleTicketId", connection))
            {
                AddSqlParameter(command, "@ScaleTicketId", ScaleTicketId, System.Data.SqlDbType.UniqueIdentifier);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var info = new ScaleTicketViewModel();
                        //info.ScaleTicketId = GetDbReaderValue<Guid>(reader["ScaleTicketMobileId"]);
                        info.ScaleTicketId = GetDbReaderValue<Guid>(reader["ScaleTicketId"]);
                        info.ScaleTicketCode = GetDbReaderValue<string>(reader["ScaleTicketCode"]);
                        info.VehicleTypeCode = GetDbReaderValue<string>(reader["VehicleTypeCode"]);
                        info.VehicleNumber = GetDbReaderValue<string>(reader["VehicleNumber"]);
                        info.ContainerCount = GetDbReaderValue<string>(reader["ContainerCount"]);
                        info.TrailersNumber = GetDbReaderValue<string>(reader["TrailersNumber"]);                      
                        info.PercentReduced = GetDbReaderValue<decimal>(reader["PercentReduced"]);
                        info.KgReduced = GetDbReaderValue<decimal>(reader["KgReduced"]);                       
                        info.Description = GetDbReaderValue<string>(reader["Description"]);                    
                        info.isXeNoiBo = GetDbReaderValue<bool>(reader["isXeNoiBo"]);                       
                        info.is20Feet = GetDbReaderValue<bool>(reader["is20Feet"]);
                        info.is40Feet = GetDbReaderValue<bool>(reader["is40Feet"]);
                        info.SoHieuCont1 = GetDbReaderValue<string>(reader["SoHieuCont1"]);
                        info.SoHieuCont2 = GetDbReaderValue<string>(reader["SoHieuCont2"]);
                        result.Add(info);
                    }
                }
                return result;
            }
        }
    }
}
