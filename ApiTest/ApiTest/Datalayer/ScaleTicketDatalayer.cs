using ApiTest.DataLayers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ApiTest.Datalayer
{
    public class ScaleTicketDatalayer:BaseLayerData<ScaleTicketDatalayer>
    {
        public List<ScaleTicketViewModel> GetScaleTicket(SqlConnection connection,Guid? ScaleTicketId)
        {
            var result = new List<ScaleTicketViewModel>();
            using (var command = new SqlCommand("exec Ins_ScaleTicketModel_GetByID @ScaleTicketId", connection))
            {
                AddSqlParameter(command, "@ScaleTicketId", ScaleTicketId, System.Data.SqlDbType.UniqueIdentifier);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var info = new ScaleTicketViewModel();
                        info.ScaleTicketId = GetDbReaderValue<Guid>(reader["ScaleTicketId"]);
                        info.ScaleTicketCode = GetDbReaderValue<string>(reader["ScaleTicketCode"]);
                        info.ScaleTicketTypeCode = GetDbReaderValue<string>(reader["ScaleTicketTypeCode"]);
                        info.VehicleTypeCode = GetDbReaderValue<string>(reader["VehicleTypeCode"]);
                        info.VehicleNumber = GetDbReaderValue<string>(reader["VehicleNumber"]);
                        info.BargeNumber = GetDbReaderValue<string>(reader["BargeNumber"]);
                        info.ContainerCount = GetDbReaderValue<string>(reader["ContainerCount"]);
                        info.TrailersNumber = GetDbReaderValue<string>(reader["TrailersNumber"]);
                        info.InHour = GetDbReaderValue<DateTime>(reader["InHour"]);
                        info.OutHour = GetDbReaderValue<DateTime>(reader["OutHour"]);
                        info.FirstWeight = GetDbReaderValue<decimal>(reader["FirstWeight"]);
                        info.SecondWeight = GetDbReaderValue<decimal>(reader["SecondWeight"]);
                        info.ActualWeight = GetDbReaderValue<decimal>(reader["ActualWeight"]);
                        info.PercentReduced = GetDbReaderValue<decimal>(reader["PercentReduced"]);
                        info.KgReduced = GetDbReaderValue<decimal>(reader["KgReduced"]);
                        info.ActualWeightAfterReduction = GetDbReaderValue<decimal>(reader["ActualWeightAfterReduction"]);
                        info.TotalReduced = GetDbReaderValue<decimal>(reader["TotalReduced"]);
                        info.Description = GetDbReaderValue<string>(reader["Description"]);
                        info.isTest = GetDbReaderValue<bool>(reader["isTest"]);
                        info.SoftCode = GetDbReaderValue<string>(reader["SoftCode"]);
                        info.FirstUserId = GetDbReaderValue<Guid>(reader["FirstUserId"]);
                        info.SecondUserId = GetDbReaderValue<Guid>(reader["SecondUserId"]);
                        info.isSendToSAPCompleted = GetDbReaderValue<bool>(reader["isSendToSAPCompleted"]);
                        info.isInvalidSAP = GetDbReaderValue<bool>(reader["isInvalidSAP"]);
                        info.InvalidSAPMessage = GetDbReaderValue<string>(reader["InvalidSAPMessage"]);
                        info.isXeNoiBo = GetDbReaderValue<bool>(reader["isXeNoiBo"]);
                        info.isDeleted = GetDbReaderValue<bool>(reader["isDeleted"]);
                        info.isQuaTai = GetDbReaderValue<bool>(reader["isQuaTai"]);
                        info.StatusIP = GetDbReaderValue<bool>(reader["StatusIP"]);
                        info.isDonTrongMin = GetDbReaderValue<bool>(reader["isDonTrongMin"]);
                        info.isDonTrongMax = GetDbReaderValue<bool>(reader["isDonTrongMax"]);
                        info.isVuotTyLeOD = GetDbReaderValue<bool>(reader["isVuotTyLeOD"]);
                        info.CungDuongCode = GetDbReaderValue<int>(reader["CungDuongCode"]);
                        info.CungDuongName = GetDbReaderValue<string>(reader["CungDuongName"]);
                        info.VehicleOwner = GetDbReaderValue<string>(reader["VehicleOwner"]);
                        info.VehicleOwnerName = GetDbReaderValue<string>(reader["VehicleOwnerName"]);
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
