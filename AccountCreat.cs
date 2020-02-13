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
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace netnetcafe
{
    public partial class AccountCreat : Form
    {
        public AccountCreat(string str_value)
        {
            InitializeComponent();
            lblCusId.Text = str_value;

        }
        const int SC_CLOSE = 0xF060;
        const int MF_GRAYED = 0x1;
        const int MF_DISABLED = 0x00000002;

        [DllImport("user32")]
        private static extern IntPtr GetSystemMenu(IntPtr HWNDValue, bool Revert);
        [DllImport("user32")]
        private static extern int EnableMenuItem(IntPtr tMenu, int targetItem, int targetStatus);
        private void btnDone_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=netcafedatabase;";
            if (txtUsername.Text == "" || txtPass.Text == "" || txtConfirmpass.Text == "")
            {
                MessageBox.Show("All Fields must be filled");
            }
            else
            {
                if (txtPass.Text == txtConfirmpass.Text)
                {
                    string query = "INSERT INTO accounttable(AcountID,UserName1,Password1,UserType) VALUES ('"+lblCusId.Text+"','" + txtUsername.Text + "', '" + txtPass.Text + "','" + lblhidden.Text + "')";
                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    databaseConnection.Open();
                    commandDatabase.ExecuteNonQuery();
                    MessageBox.Show("Account Successfully Created!");
                    new Login().Show();
                }
                else
                {
                    MessageBox.Show("Password does not Match");
                    txtPass.Clear();
                    txtConfirmpass.Clear();
                }
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            new Registration().Show();
        }
        private void AccountCreat_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);          
        }

    }
}
