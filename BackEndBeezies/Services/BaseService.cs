using BackEndBeezies.Data.Extensions;
using BackEndBeezies.Data.Interfaces;
using BackEndBeezies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackEndBeezies.Services
{
    public class BaseService : IBaseService
    {
        public IDao DataProvider
        {
            get { return BackEndBeezies.Data.DataProvider.Instance; }
        }

        public IErrorLogService ErrorLog { get; set; }

        public SqlConnection GetConnection()
        {
            return new System.Data.SqlClient.SqlConnection(
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public void LogError(string methodName, Exception ex, string createdBy)
        {
            ErrorLog.Insert(new Models.Requests.Tools.ErrorLogAddRequest
            {
                ErrorFunction = methodName,
                ErrorMessage = ex.Message,
                ErrorStackTrace = ex.ToString(),
                CreatedBy = createdBy
            });
        }

        public T MapToObject<T>(IDataReader reader)
        {
            var colname = reader.GetSchemaTable().Rows.Cast<DataRow>().Select(c => c["ColumnName"].ToString().ToLower()).ToList();

            var properties = typeof(T).GetProperties();

            var obj = Activator.CreateInstance<T>();
            foreach (var prop in properties)
            {
                if (colname.Contains(prop.Name.ToLower()))
                {
                    Type typ = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    if (reader[prop.Name] != DBNull.Value)
                    {
                        if (reader[prop.Name].GetType() == typeof(decimal)) { prop.SetValue(obj, (reader.GetDouble(prop.Name)), null); }
                        else { prop.SetValue(obj, (reader.GetValue(reader.GetOrdinal(prop.Name)) ?? null), null); }
                    }
                }
            }

            return obj;
        }
    }
}