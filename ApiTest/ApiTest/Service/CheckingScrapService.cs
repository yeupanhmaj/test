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
    public class CheckingScrapService:BaseService<CheckingScrapService>
    {
        public List<CheckingScrapViewModel> GetCheckingScrap(string RFID, bool isDone)
        {
            ConnectionFactory sqlConnection = new ConnectionFactory();
            var record = new List<CheckingScrapViewModel>();
            using (SqlConnection connection = sqlConnection.GetConnection())
            {
                record = CheckingScrapDatalayer.GetInstance().GetCheckingScrap(connection,RFID,isDone);
                return record;
            }
        }
        public int InsertCheckingScrap(CheckingScrapViewModel _user)
        {
            ConnectionFactory sqlConnection = new ConnectionFactory();
            CheckingScrapViewModel record = new CheckingScrapViewModel();
            using (SqlConnection connection = sqlConnection.GetConnection())
            {
               return CheckingScrapDatalayer.GetInstance().InsertCheckingScrap(connection, _user);
            }
        }
        public int UpdateCheckingScrap(CheckingScrapViewModel _user)
        {
            ConnectionFactory sqlConnection = new ConnectionFactory();
            CheckingScrapViewModel record = new CheckingScrapViewModel();
            using (SqlConnection connection = sqlConnection.GetConnection())
            {
                return CheckingScrapDatalayer.GetInstance().UpdateCheckingScrap(connection, _user);
            }
        }
    }
}
