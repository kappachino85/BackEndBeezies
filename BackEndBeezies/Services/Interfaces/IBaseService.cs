using BackEndBeezies.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBeezies.Services.Interfaces
{
    public interface IBaseService
    {
        IDao DataProvider { get; }
        IErrorLogService ErrorLog { get; set; }
        SqlConnection GetConnection();
        void LogError(string methodName, Exception ex, string createdBy);
        T MapToObject<T>(IDataReader reader);
    }
}
