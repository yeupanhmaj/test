using ApiTest.DataLayers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ApiTest.Datalayer
{
    public class CheckingScrapDatalayer:BaseLayerData<CheckingScrapDatalayer>
    {
        public List<CheckingScrapViewModel> GetCheckingScrap(SqlConnection connection,string RFID,bool isDone)
        {
            var result = new List<CheckingScrapViewModel>();
            using (var command = new SqlCommand("exec Ins_CheckingScrapModel_GetByRFID @RFID, @isDone", connection))
            {
                AddSqlParameter(command, "@RFID", RFID, System.Data.SqlDbType.VarChar);
                AddSqlParameter(command, "@isDone", isDone, System.Data.SqlDbType.Bit);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var info = new CheckingScrapViewModel();
                        info.CheckingScrapId = GetDbReaderValue<Guid>(reader["CheckingScrapId"]);
                        info.ChekingScrapIdInt = GetDbReaderValue<int>(reader["ChekingScrapIdInt"]);
                        info.ScaleTicketId = GetDbReaderValue<Guid>(reader["ScaleTicketId"]);
                        info.ScaleTicketMobileId = GetDbReaderValue<Guid>(reader["ScaleTicketMobileId"]);
                        info.RFID = GetDbReaderValue<string>(reader["RFID"]);
                        info.InHourGuard = GetDbReaderValue<DateTime>(reader["InHourGuard"]);
                        info.OutHourGuard = GetDbReaderValue<DateTime>(reader["OutHourGuard"]);
                        info.GiaoNhan = GetDbReaderValue<string>(reader["GiaoNhan"]);
                        info.VehicleNumber = GetDbReaderValue<string>(reader["VehicleNumber"]);
                        info.DriverName = GetDbReaderValue<string>(reader["DriverName"]);
                        info.DriverIdCard = GetDbReaderValue<string>(reader["DriverIdCard"]);
                        info.IsVehicleNew = GetDbReaderValue<bool>(reader["IsVehicleNew"]);
                        info.InGateId = GetDbReaderValue<string>(reader["InGateId"]);
                        info.OutGateId = GetDbReaderValue<string>(reader["OutGateId"]);
                        info.ReceiveType = GetDbReaderValue<string>(reader["ReceiveType"]);
                        info.User1Id = GetDbReaderValue<Guid>(reader["User1Id"]);
                        info.Note1 = GetDbReaderValue<string>(reader["Note1"]);
                        info.User2Id = GetDbReaderValue<Guid>(reader["User2Id"]);
                        info.User3Id = GetDbReaderValue<Guid>(reader["User3Id"]);
                        info.Note3 = GetDbReaderValue<string>(reader["Note3"]);
                        info.CheckingTime = GetDbReaderValue<DateTime>(reader["CheckingTime"]);
                        info.User4Id = GetDbReaderValue<Guid>(reader["User4Id"]);
                        info.VerifyTime = GetDbReaderValue<DateTime>(reader["VerifyTime"]);
                        info.User5Id = GetDbReaderValue<Guid>(reader["User5Id"]);
                        info.Status = GetDbReaderValue<int>(reader["Status"]);
                        info.Actived = GetDbReaderValue<bool>(reader["Actived"]);
                        info.IsDone = GetDbReaderValue<bool>(reader["IsDone"]);
                        info.Step = GetDbReaderValue<int>(reader["Step"]);
                        result.Add(info);
                    }
                }
                return result;
            }
        }
        public int InsertCheckingScrap(SqlConnection connection, CheckingScrapViewModel user)
        {
            int result = 0;
            using (var command = new SqlCommand("EXEC Ins_CheckingScrap_Insert " +
                "@CheckingScrapId," +
                "@ScaleTicketId," +
                "@ScaleTicketMobileId," +
                "@RFID," +
                "@InHourGuard," +
                "@OutHourGuard," +
                "@GiaoNhan," +
                "@VehicleNumber," +
                "@DriverName," +
                "@DriverIdCard," +
                "@IsVehicleNew," +
                "@InGateId," +
                "@OutGateId," +
                "@ReceiveType," +
                "@User1Id," +
                "@Note1," +
                "@User2Id," +
                "@User3Id," +
                "@Note3," +
                "@CheckingTime," +
                "@User4Id," +
                "@VerifyTime," +
                "@User5Id," +
                "@Status," +
                "@Actived," +
                "@IsDone," +
                "@Step"
                 , connection))
            {
                AddSqlParameter(command, "@CheckingScrapId", user.CheckingScrapId, System.Data.SqlDbType.UniqueIdentifier);
                AddSqlParameter(command, "@ScaleTicketId", user.ScaleTicketId, System.Data.SqlDbType.UniqueIdentifier);
                AddSqlParameter(command, "@ScaleTicketMobileId", user.ScaleTicketMobileId, System.Data.SqlDbType.UniqueIdentifier);
                AddSqlParameter(command, "@RFID", user.RFID, System.Data.SqlDbType.NVarChar);
                AddSqlParameter(command, "@InHourGuard", user.InHourGuard, System.Data.SqlDbType.DateTime);
                AddSqlParameter(command, "@OutHourGuard", user.OutHourGuard, System.Data.SqlDbType.DateTime);
                AddSqlParameter(command, "@GiaoNhan", user.GiaoNhan, System.Data.SqlDbType.NVarChar);
                AddSqlParameter(command, "@VehicleNumber", user.VehicleNumber, System.Data.SqlDbType.NVarChar);
                AddSqlParameter(command, "@DriverName", user.DriverName, System.Data.SqlDbType.NVarChar);
                AddSqlParameter(command, "@DriverIdCard", user.DriverIdCard, System.Data.SqlDbType.NVarChar);
                AddSqlParameter(command, "@IsVehicleNew", user.IsVehicleNew, System.Data.SqlDbType.Bit);
                AddSqlParameter(command, "@InGateId", user.InGateId, System.Data.SqlDbType.NVarChar);
                AddSqlParameter(command, "@OutGateId", user.OutGateId, System.Data.SqlDbType.NVarChar);
                AddSqlParameter(command, "@ReceiveType", user.ReceiveType, System.Data.SqlDbType.NVarChar);
                AddSqlParameter(command, "@User1Id", user.User1Id, System.Data.SqlDbType.UniqueIdentifier);
                AddSqlParameter(command, "@Note1", user.Note1, System.Data.SqlDbType.NVarChar);
                AddSqlParameter(command, "@User2Id", user.User2Id, System.Data.SqlDbType.UniqueIdentifier);
                AddSqlParameter(command, "@User3Id", user.User3Id, System.Data.SqlDbType.UniqueIdentifier);
                AddSqlParameter(command, "@Note3", user.Note3, System.Data.SqlDbType.NVarChar);
                AddSqlParameter(command, "@CheckingTime", user.CheckingTime, System.Data.SqlDbType.DateTime);
                AddSqlParameter(command, "@User4Id", user.User4Id, System.Data.SqlDbType.UniqueIdentifier);
                AddSqlParameter(command, "@VerifyTime", user.VerifyTime, System.Data.SqlDbType.DateTime);
                AddSqlParameter(command, "@User5Id", user.User5Id, System.Data.SqlDbType.UniqueIdentifier);
                AddSqlParameter(command, "@Status", user.Status, System.Data.SqlDbType.Int);
                AddSqlParameter(command, "@Actived", user.Actived, System.Data.SqlDbType.Bit);
                AddSqlParameter(command, "@IsDone", user.IsDone, System.Data.SqlDbType.Bit);
                AddSqlParameter(command, "@Step", user.Step, System.Data.SqlDbType.Int);
                WriteLogExecutingCommand(command);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var info = new GateViewModel();                       
                        result = GetDbReaderValue<int> (reader["result"]);
                    }
                }
            }
            return result;
        }
        public int UpdateCheckingScrap(SqlConnection connection, CheckingScrapViewModel user)
        {
            int result = 0;
            using (var command = new SqlCommand("ins_CheckingScrap_Update " +
                "@CheckingScrapId," +
                "@OutHourGuard," +
                "@OutGateId," +
                "@User5Id," +
                "@IsDone," +
                "@Step"
                 , connection))
            {
                AddSqlParameter(command, "@CheckingScrapId", user.CheckingScrapId, System.Data.SqlDbType.UniqueIdentifier);
                AddSqlParameter(command, "@OutHourGuard", user.OutHourGuard, System.Data.SqlDbType.DateTime);
                AddSqlParameter(command, "@OutGateId", user.OutGateId, System.Data.SqlDbType.NVarChar);
                AddSqlParameter(command, "@User5Id", user.User5Id, System.Data.SqlDbType.UniqueIdentifier);
                AddSqlParameter(command, "@IsDone", user.IsDone, System.Data.SqlDbType.Bit);
                AddSqlParameter(command, "@Step", user.Step, System.Data.SqlDbType.Int);
                WriteLogExecutingCommand(command);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var info = new GateViewModel();
                        result = GetDbReaderValue<int>(reader["result"]);
                    }
                }
            }
            return result;
        }
    }
   
}
