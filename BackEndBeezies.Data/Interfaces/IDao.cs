using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndBeezies.Data.Interfaces
{
    public interface IDao
    {
      void ExecuteCmd(
        Func<SqlConnection> dataSouce,
        string storedProc,
        Action<SqlParameterCollection> inputParamMapper,
        Action<IDataReader, short> map,

        Action<SqlParameterCollection> returnParameters = null,
        Action<SqlCommand> cmdModifier = null);


        int ExecuteNonQuery(Func<System.Data.SqlClient.SqlConnection> dataSouce, string storedProc,
            Action<System.Data.SqlClient.SqlParameterCollection> inputParamMapper,
            Action<System.Data.SqlClient.SqlParameterCollection> returnParameters = null);
    }
}
