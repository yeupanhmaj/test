using ApiTest.DataLayers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ApiTest.Datalayer
{
    public class ScaleTicketMobileHistoryDatalayer:BaseLayerData<ScaleTicketMobileHistoryDatalayer>
    {
        public List<ScaleTicketMobileHistoryViewModel> GetListScaleTicketMobileHistory(SqlConnection connection,Guid? ScaleTicketId)
        {
            var result = new List<ScaleTicketMobileHistoryViewModel>();
            using (var command = new SqlCommand("exec Ins_ScaleTicketMobileHistoryModel @ScaleTicketId", connection))
            {
                AddSqlParameter(command, "@ScaleTicketId", ScaleTicketId, System.Data.SqlDbType.UniqueIdentifier);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var info = new ScaleTicketMobileHistoryViewModel();
                        info.HistoryType = GetDbReaderValue<string>(reader["HistoryType"]);
                        info.CreateDate = GetDbReaderValue<DateTime>(reader["CreateDate"]);
                        info.FullName = GetDbReaderValue<string>(reader["FullName"]);
                        result.Add(info);
                    }
                }
                return result;
            }
        }
    }
}
