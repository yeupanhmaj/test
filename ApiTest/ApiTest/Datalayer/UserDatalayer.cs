using ApiTest.DataLayers;
using ApiTest.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Datalayer
{
    public class UserDatalayer:BaseLayerData<UserDatalayer>
    {
        public UserModel GetUser(SqlConnection connection, string UserName)
        {

            var info = new UserModel();
            using (var command = new SqlCommand("Select [UserId]       " +
                ",[FullName]" +
                ",[UserName]" +
                ",[PasswordEnscrypt]" +
                ",[RoldCode]" +
                ",[CreatedTime]" +
                ",[LastEditedTime]" +
                ",[Actived]" +
                " from [VAS_4000].[dbo].[UserModel] where UserName=@UserName", connection))
            {
                AddSqlParameter(command, "@UserName", UserName, System.Data.SqlDbType.VarChar);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    info.UserId = GetDbReaderValue<Guid>(reader["UserId"]);
                    info.FullName = GetDbReaderValue<string>(reader["FullName"]);
                    info.UserName = GetDbReaderValue<string>(reader["UserName"]);
                    info.PasswordEnscrypt = GetDbReaderValue<string>(reader["PasswordEnscrypt"]);
                    info.RoldCode = GetDbReaderValue<string>(reader["RoldCode"]);
                    info.CreatedTime = GetDbReaderValue<DateTime>(reader["CreatedTime"]);
                    info.LastEditedTime = GetDbReaderValue<DateTime>(reader["LastEditedTime"]);
                    info.Actived = GetDbReaderValue<Boolean>(reader["Actived"]);
                }
                return info;
            }
        }
    }
}
