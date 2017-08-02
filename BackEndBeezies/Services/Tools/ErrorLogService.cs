using BackEndBeezies.Models.Requests.Tools;
using BackEndBeezies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackEndBeezies.Services.Tools
{
    public class ErrorLogService : IErrorLogService
    {
        IBaseService _baseService;

        public ErrorLogService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public int Insert(ErrorLogAddRequest model)
        {
            try
            {
                int id = 0;
                _baseService.DataProvider.ExecuteNonQuery(_baseService.GetConnection, "dbo.ErrorLog_Insert", inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@ErrorFunction", model.ErrorFunction);
                    paramCollection.AddWithValue("@ErrorMessage", model.ErrorMessage);
                    paramCollection.AddWithValue("@ErrorStackTrace", model.ErrorStackTrace);
                    paramCollection.AddWithValue("@CreatedBy", model.CreatedBy);


                    SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    p.Direction = ParameterDirection.Output;

                    paramCollection.Add(p);

                }, returnParameters: delegate (SqlParameterCollection param)
                {
                    int.TryParse(param["@Id"].Value.ToString(), out id);
                });
                return id;
            }
            catch
            {
                throw;
            }
        }
    }
}