using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public class DB
    {
        public static MySqlCommand GetCommand (string sql)
        {
            var con = new MySqlConnection("Server=localhost;Database=blagajna;UID=travel;PWD=travel");
            var cmd = new MySqlCommand(sql);
            con.Open();
            cmd.Connection = con;
            return cmd;
        }
    }
}
