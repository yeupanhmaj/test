using ApiTest.Common;
using ApiTest.Datalayer;
using ApiTest.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Service
{
    public class UserService: BaseService<UserService>
    {
        public UserModel GetUser(string id)
        {
            ConnectionFactory sqlConnection = new ConnectionFactory();
            UserModel record = new UserModel();
            using (SqlConnection connection = sqlConnection.GetConnection())
            {
                record = UserDatalayer.GetInstance().GetUser(connection, id);
                return record;
            }
        }
    }
}
