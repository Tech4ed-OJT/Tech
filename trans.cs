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
    public partial class trans : Form
    {
        public trans()
        {
            InitializeComponent();
        }

        private void trans_Load(object sender, EventArgs e)
        {
            cbTransType.Items.AddRange(new string[] { "PC ACCESS", "PRINTING","SCANNING" });
            cbPaperType.Items.AddRange(new string[] { "LONG", "SHORT", "A4", "LEGAL" });
            cbPurpose.Items.AddRange(new string[] { "Research", "Use of MS Word", "Use of MS PowerPoint", "Use of MS Excel","Seminar and Training" });
        }

      

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=netcafedatabase;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            if (cbTransType.SelectedIndex == 0)
            {
                MySqlCommand cmd = new MySqlCommand("Insert into transactiontable(TransactionType, Type) values ('" + cbTransType.Text + "','" + cbPurpose.Text + "') ",conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Transaction added Successfuly");
                conn.Close();
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand("Insert into transactiontable(TransactionType, Type) values ('" + cbTransType.Text + "','" + cbPaperType.Text + "') ",conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Transaction added Successfuly");
                conn.Close();
            }


        }

        private void cbTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTransType.SelectedIndex == 0)
            {
                lblPapertype.Visible = false;
                cbPaperType.Visible = false;
                lblPurpose.Visible = true;
                cbPurpose.Visible = true;
            }
            else
            {
                lblPurpose.Visible = false;
                cbPurpose.Visible = false;
                lblPapertype.Visible = true;
                cbPaperType.Visible = true;

            }
        }
    }
}
