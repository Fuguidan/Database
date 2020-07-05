using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace HRMS
{
    class Dao
    {
        public MySqlConnection connection()
        {
            string str = "data source = localhost; database = hrms; user=root; password=123";
            MySqlConnection sc = new MySqlConnection(str);
            sc.Open();
            return sc;
        }

        public MySqlCommand command(string sql)
        {
            MySqlCommand sc = new MySqlCommand(sql, connection());
            return sc;
        }

        //用于delete、 updata、 insert 返回受影响的行数
        public int Excute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }

        //用于select  返回包含数据的对象
        public MySqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }
    }
}
