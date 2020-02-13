using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace netnetcafe
{
    class ViewMe
    {

        public double total(double t)
        {
            MySqlConnection connect = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=netcafedatabase;");
            connect.Open();


            MySqlDataAdapter sda0 = new MySqlDataAdapter("select count(*) from transactiontable", connect);
            DataTable dt0 = new DataTable();
            sda0.Fill(dt0);
            t = Convert.ToInt32(dt0.Rows[0][0]);


            return t;
        }
    }

}
