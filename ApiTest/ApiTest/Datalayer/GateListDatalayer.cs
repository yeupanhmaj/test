using ApiTest.DataLayers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ApiTest.Datalayer
{
    public class GateListDatalayer:BaseLayerData<GateListDatalayer>
    {
        public List<GateViewModel> GetGateList(SqlConnection connection)
        {
            var result = new List<GateViewModel>();           
            using (var command = new SqlCommand("exec Ins_GateModel_GetGateList", connection))
            {                         
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var info = new GateViewModel();
                        info.GateId = GetDbReaderValue<string>(reader["GateCode"]);
                        info.GateName = GetDbReaderValue<string>(reader["GateName"]);
                        result.Add(info);
                    }
                }
                return result;
            }
        }
    }
}
