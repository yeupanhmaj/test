using ApiTest.DataLayers;
using Microsoft.AspNetCore.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ApiTest.Datalayer
{
    public class ScaleTicketPODetailDatalayer:BaseLayerData<ScaleTicketPODetailDatalayer>
    {
        public List<ScaleTicketPODetailViewModel> GetListScaleTicketPODetail(SqlConnection connection, Guid ScaleTicketId)
        {
            var result = new List<ScaleTicketPODetailViewModel>();
            using (var command = new SqlCommand("exec Ins_ScaleTicketPODetailModel_GetByScaleTicketID @ScaleTicketId", connection))
            {
                AddSqlParameter(command, "@ScaleTicketId", ScaleTicketId, System.Data.SqlDbType.UniqueIdentifier);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var info = new ScaleTicketPODetailViewModel();
                        info.ScaleTicketPODetailId = GetDbReaderValue<Guid>(reader["ScaleTicketPODetailId"]);
                        info.ScaleTicketId = GetDbReaderValue<Guid>(reader["ScaleTicketId"]);
                        info.PONumber = GetDbReaderValue<string>(reader["PONumber"]);
                        info.POLine = GetDbReaderValue<string>(reader["POLine"]);
                        info.ProductCode = GetDbReaderValue<string>(reader["ProductCode"]);
                        info.ProductName = GetDbReaderValue<string>(reader["ProductName"]);
                        info.POQty = GetDbReaderValue<decimal>(reader["POQty"]);
                        info.UNIT = GetDbReaderValue<string>(reader["UNIT"]);
                        info.SoLuongDaNhap = GetDbReaderValue<decimal>(reader["SoLuongDaNhap"]);
                        info.TyLeTrongLuong = GetDbReaderValue<decimal>(reader["TyLeTrongLuong"]);
                        info.Qty1 = GetDbReaderValue<decimal>(reader["Qty1"]);
                        info.TapChat = GetDbReaderValue<decimal>(reader["TapChat"]);
                        info.Unit1 = GetDbReaderValue<string>(reader["Unit1"]);
                        info.Qty2 = GetDbReaderValue<decimal>(reader["Qty2"]);
                        info.Unit2 = GetDbReaderValue<string>(reader["Unit2"]);
                        info.isNoPO = GetDbReaderValue<bool>(reader["isNoPO"]);
                        info.isSendToSAPCompleted = GetDbReaderValue<bool>(reader["isSendToSAPCompleted"]);                       
                        result.Add(info);
                    }
                }
                return result;
            }
        }
    }
}
