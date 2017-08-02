using BackEndBeezies.Models.Requests.Member;
using BackEndBeezies.Services.Interfaces;
using BackEndBeezies.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BackEndBeezies.Services.Member
{
    public class MemberProfileService: IMemberProfileService
    {
        IUserService _userService;
        IBaseService _baseService;

        public MemberProfileService(IUserService userService, IBaseService baseService, IErrorLogService errorLogService)
        {
            _userService = userService;
            _baseService = baseService;
            _baseService.ErrorLog = errorLogService;
        }

        public int Insert(MemberProfileAddRequest model)
        {
            try
            {
                int id = 0;
                _baseService.DataProvider.ExecuteNonQuery(_baseService.GetConnection, "dbo.MemberProfile_Insert", inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@AspNetUserId", model.AspNetUserId);
                    paramCollection.AddWithValue("@FirstName", model.FirstName);
                    paramCollection.AddWithValue("@Email", model.Email);
                    paramCollection.AddWithValue("@LastName", model.LastName);
                    paramCollection.AddWithValue("@Gender", model.Gender);

                    SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    p.Direction = System.Data.ParameterDirection.Output;

                    paramCollection.Add(p);

                }, returnParameters: delegate (SqlParameterCollection param)
                {
                    int.TryParse(param["@id"].Value.ToString(), out id);
                });
                return id;
            }
            catch (Exception ex)
            {
                _baseService.LogError(System.Reflection.MethodBase.GetCurrentMethod().Name, ex, "MemberProfileService");
                throw;
            }
        }
    }
}