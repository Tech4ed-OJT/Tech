using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace netnetcafe
{
    public partial class Form7 : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=netcafedatabase;";

        public Form7(string str_value)
        {
            InitializeComponent();
            lblhid.Text = str_value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connect = new MySqlConnection(connectionString);
                connect.Open();

               
                MySqlCommand cmd = new MySqlCommand("select AcountID from accounttable where UserName1 = '" + txtUsername.Text + "' ", connect);
                MySqlDataReader read = cmd.ExecuteReader();
                read.Read();
                string ActId = read.GetString("AcountID");


                read.Close();
                MySqlCommand cmd2 = new MySqlCommand("select * from timetable where AccountID = '" + ActId + "' ", connect);
                MySqlDataReader read2 = cmd2.ExecuteReader();
                read2.Read();

                int x = read2.GetInt16(0);
                string y = read2.GetString(1);
                int h = read2.GetInt16(2);
                int m = read2.GetInt16(3);
                int s = read2.GetInt16(4);




                read2.Close();
                h = h + int.Parse(txtHour.Text);
             
                //int h = 2;
                //int m = 2;
                //int s = 2;



                MySqlCommand cmd1 = new MySqlCommand("UPDATE timetable set H ='"+h+"', M ='"+m+"', S='"+s+"' where AccountID='"+ActId+"' ", connect);
                cmd1.ExecuteNonQuery();
                connect.Close();


               
            }
            catch(Exception exq)
            {
                MessageBox.Show(exq.Message);
            }
            
        }

        private void btnIdSearch_Click(object sender, EventArgs e)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            string query = "select * from accounttable where AcountID = '" + txtSearch.Text + "' ";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader = commandDatabase.ExecuteReader();
            if (reader.Read())
            {
                txtUsername.Text = reader.GetString("Username1");

            }
            else
            {
                MessageBox.Show("Account doesn't Exist");

            }
            reader.Close();
            databaseConnection.Close();

        }

        private void btnNameSearch_Click(object sender, EventArgs e)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            string query = "select * from accounttable where UserName1 = '" + txtSearch.Text + "' ";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader = commandDatabase.ExecuteReader();
            if (reader.Read())
            {
                txtUsername.Text = reader.GetString("Username1");

            }
            else
            {
                MessageBox.Show("Account doesn't Exist");

            }
            reader.Close();
            databaseConnection.Close();

        }
    }
}
