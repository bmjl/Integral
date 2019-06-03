using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral_DAL
{

    class SqlClent
    {
        //连接数据库
        SqlConnection con = SqlHelper.GetConnection();

        public DataTable Select(string sql)
        {
            //查询
            DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.Text, sql);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }
        public int InsertOrUpdateOrDelete(string sql)
        {
            //修改
            int i = SqlHelper.ExecuteNonQuery(con, CommandType.Text, sql, null);
            return i;
        }

    }
}
