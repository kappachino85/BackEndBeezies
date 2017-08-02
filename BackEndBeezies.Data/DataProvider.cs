using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEndBeezies.Data.Interfaces;
using BackEndBeezies.Data.Providers;

namespace BackEndBeezies.Data
{
    public sealed class DataProvider
    {
        private DataProvider() { }

        public static IDao Instance
        {
            get
            {
                return SqlDao.Instance;
            }
        }

        public static void ExecuteCmd(object getConnection, string v, Func<SqlParameterCollection, object> inputParamMapper)
        {
            throw new NotImplementedException();
        }

        public static void ExecuteCmd(object getConnection, string v, Func<SqlParameterCollection, object> inputParamMapper, Func<IDataReader, short, object> map)
        {
            throw new NotImplementedException();
        }

        public static void ExecuteCmd(object getConnection, string v, object p, Func<IDataReader, short, object> map)
        {
            throw new NotImplementedException();
        }
    }
}
