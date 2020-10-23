
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ApiTest.DataLayers
{
    public abstract class BaseLayerData<T> where T : new()
    {
        /// <summary>
        /// 	Logger
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static T _instance = default(T);

        public static T GetInstance()
        {
            if (_instance == null)
            {
                _instance = new T();
            }

            return _instance;
        }

        protected void WriteLogExecutingCommand(OdbcCommand command)
        {
            StringBuilder builder = new StringBuilder("");
            builder.AppendLine("Preparing SQL command with parameters: ");
            foreach (OdbcParameter param in command.Parameters)
            {
                builder.AppendLine(string.Format("Name: {0} - Value: {1}",
                    param.ParameterName,
                    param.Value == DBNull.Value ? "null" : param.Value.ToString()));
            }
            builder.AppendLine(string.Format("SQL executing: {0}", command.CommandText));

            _logger.Debug(builder.ToString());
        }

        protected void WriteLogExecutingCommand(SqlCommand command)
        {
            StringBuilder builder = new StringBuilder("");
            builder.AppendLine("Preparing SQL command with parameters: ");
            foreach (SqlParameter param in command.Parameters)
            {
                builder.AppendLine(string.Format("declare {0} {1}; set {0}={2};",
                    param.ParameterName,
                    param.DbType.ToString(),
                    param.Value == DBNull.Value ? "null" : param.Value.ToString()));
            }
            builder.AppendLine(string.Format("SQL executing: {0} on host {1} and db {2}", command.CommandText,
                command.Connection != null ? command.Connection.DataSource : string.Empty,
                command.Connection != null ? command.Connection.Database : string.Empty));

            _logger.Debug(builder.ToString());
        }

        protected object GetObjectValue(SqlDataReader reader, string keyProperty)
        {
            if (!System.DBNull.Value.Equals(reader[keyProperty]) && reader[keyProperty] != null)
            {
                return (object)reader[keyProperty];
            }

            return null;
        }

        protected object GetDatabaseValue(object value)
        {
            if (value is string)
            {
                return string.IsNullOrEmpty((string)value) ? System.DBNull.Value : value;
            }

            return value == null ? System.DBNull.Value : value;
        }

        protected K GetDbReaderValue<K>(object value)
        {
            if (System.DBNull.Value.Equals(value) == false && value != null)
            {
                return (K)value;
            }

            return default(K);
        }

        protected void ApplyValue(object dataObject, object value, string valueProperty)
        {
            if (System.DBNull.Value.Equals(value) == false)
            {
                PropertyInfo propertyInfo = dataObject.GetType().GetProperty(valueProperty);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(dataObject, value, null);
                }
            }
        }

        protected string FormatListData(List<int> listValues)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var value in listValues)
            {
                stringBuilder.AppendFormat(", {0}", value);
            }

            if (stringBuilder.Length > 0)
            {
                stringBuilder.Remove(0, 2);
            }

            return stringBuilder.ToString();
        }

        protected string FormatListData(List<string> listValues)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var value in listValues)
            {
                stringBuilder.AppendFormat(", '{0}'", value);
            }

            if (stringBuilder.Length > 0)
            {
                stringBuilder.Remove(0, 2);
            }

            return stringBuilder.ToString();
        }



        protected void AddSqlParameter(SqlCommand command, string parameterName, object value, System.Data.SqlDbType type)
        {
            SqlParameter parameter = new SqlParameter(parameterName, type);
            parameter.Value = GetDatabaseValue(value);
            command.Parameters.Add(parameter);
        }

        protected DataSet ToDataSet<K>(IList<K> list)
        {
            Type elementType = typeof(K);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            foreach (K item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }
    }
}
