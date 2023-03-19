using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;


namespace ComputerGraphics.HelperScripts
{
    public static class ConnectDatabase
    {
        public static SqlConnection ConnectSQL()
        {
            string conn_string = Properties.Settings.Default.connection_settings;
            SqlConnection conn = new(conn_string);

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
                Debug.WriteLine("Server opened!");
            }

            return conn;
        }
    }
}
