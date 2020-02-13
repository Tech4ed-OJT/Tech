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
    public partial class Registration : Form
    {
        public Registration()
        {
            
            InitializeComponent();

        }
        const int SC_CLOSE = 0xF060;
        const int MF_GRAYED = 0x1;
        const int MF_DISABLED = 0x00000002;

        [DllImport("user32")]
        private static extern IntPtr GetSystemMenu(IntPtr HWNDValue, bool Revert);
        [DllImport("user32")]
        private static extern int EnableMenuItem(IntPtr tMenu, int targetItem, int targetStatus);



        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=netcafedatabase;";

            if (txtLastName.Text == "" || txtFirstName.Text == "" || txtProvince.Text == "" || txtCity.Text == "" || txtEmail.Text == "" || MaskedBirth.Text == "" || txtbarangay.Text == "" || cbGender.Text == "" || MaskedCelNo.Text == "" || CbCusType.Text == "")
            {
                MessageBox.Show("All Fields must be filled");
            }

            else
            {

                string query = "INSERT INTO customertable(LastName, FirstName, Gender, Birthdate,Province,City,Barangay,EMail,CelNO,CustomerType) VALUES ('" + txtLastName.Text + "', '" + txtFirstName.Text + "', '" + cbGender.Text + "','" + MaskedBirth.Text + "','" + txtProvince.Text + "','" + txtCity.Text + "','" + txtbarangay.Text + "','" + txtEmail.Text + "','" + MaskedCelNo.Text + "','" + CbCusType.Text + "')";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.ExecuteNonQuery();

                if (CbCusType.SelectedIndex == 1)
                {
                    if (TxtBox7.Text == "" || TxtBox8.Text == "" || TxtBox9.Text == "")
                    {
                        MessageBox.Show("All Fields must be filled");
                    }
                    else
                    {
                        string query1 = "INSERT INTO tblteacher (SchoolName,SchoolAddress,Department) VALUES ('" + TxtBox7.Text + "','" + TxtBox9.Text + "','" + TxtBox8.Text + "')";
                        MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection);
                        commandDatabase1.ExecuteNonQuery();
                        databaseConnection.Close();
                        MessageBox.Show("User succesfully registered");
                    }
                }

                else if (CbCusType.SelectedIndex == 2)
                {
                    if (TxtBox7.Text == "" || TxtBox8.Text == "" || TxtBox9.Text == "")
                    {
                        MessageBox.Show("All Fields must be filled");
                    }
                    else
                    {
                        string query2 = "INSERT INTO tblstudent (SchoolName,SchoolAddress,EducationalLevel) VALUES ('" + TxtBox7.Text + "','" + TxtBox9.Text + "','" + TxtBox8.Text + "')";
                        MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection);
                        commandDatabase2.ExecuteNonQuery();
                        databaseConnection.Close();
                        MessageBox.Show("User succesfully registered");
                    }
                }
                else if (CbCusType.SelectedIndex == 3)
                {
                    if (TxtBox7.Text == "" || TxtBox9.Text == "")
                    {
                        MessageBox.Show("All Fields must be filled");
                    }
                    else
                    {
                        string query3 = "INSERT INTO disabilitytable (DisabilityType,Reason) VALUES ('" + TxtBox7.Text + "','" + TxtBox9.Text + "')";
                        MySqlCommand commandDatabase3 = new MySqlCommand(query3, databaseConnection);
                        commandDatabase3.ExecuteNonQuery();
                        databaseConnection.Close();
                        MessageBox.Show("User succesfully registered");
                    }
                }
                else if (CbCusType.SelectedIndex == 7)
                {
                    if (TxtBox7.Text == "" || TxtBox8.Text == "" || TxtBox9.Text == "")
                    {
                        MessageBox.Show("All Fields must be filled");
                    }
                    else
                    {
                        string query4 = "INSERT INTO entreptable (BusiName,BusinessType,BusiOwnership) VALUES ('" + TxtBox7.Text + "','" + TxtBox9.Text + "','" + TxtBox8.Text + "')";
                        MySqlCommand commandDatabase4 = new MySqlCommand(query4, databaseConnection);
                        commandDatabase4.ExecuteNonQuery();
                        databaseConnection.Close();
                        MessageBox.Show("User succesfully registered");
                    }
                }

        

                MySqlCommand cmd = new MySqlCommand("select CustomerID from customertable where LastName = '" + txtLastName.Text + "' and FirstName = '" + txtFirstName.Text + "' ", databaseConnection);
                MySqlDataReader read = cmd.ExecuteReader();
                read.Read();
                string ActId = read.GetString("CustomerID");
                label11.Text = ActId;
                read.Close();
                AccountCreat Create = new AccountCreat(label11.Text);
                this.Hide();
                Create.ShowDialog();
                databaseConnection.Close();
               
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtLastName.Clear();
            txtFirstName.Clear();
            txtProvince.Clear();
            txtCity.Clear();
            txtEmail.Clear();
            MaskedBirth.Clear();
            TxtBox7.Clear();
            TxtBox8.Clear();
            TxtBox9.Clear();
            txtbarangay.Clear();
            cbGender.ResetText();
            MaskedCelNo.Clear();
            CbCusType.ResetText();
        }

        private void CbCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbCusType.SelectedIndex == 1)
            {
                lblbusi.Visible = false;
                lblbusiAdd.Visible = false;
                lblreason.Visible = false;
                lblBusiType.Visible = false;
                lblDisType.Visible = false;
                lblYearLevel.Visible = false;
                lblschoolAddress.Visible = true;
                lblDepartment.Visible = true;
                lblSchoolName.Visible = true;
                TxtBox7.Visible = true;
                TxtBox8.Visible = true;
                TxtBox9.Visible = true;
            }
            else if (CbCusType.SelectedIndex == 2)
            {
                lblbusi.Visible = false;
                lblbusiAdd.Visible = false;
                lblreason.Visible = false;
                lblBusiType.Visible = false;
                lblDisType.Visible = false;
                lblDepartment.Visible = false;
                lblschoolAddress.Visible = true;
                lblYearLevel.Visible = true;
                lblSchoolName.Visible = true;
                TxtBox7.Visible = true;
                TxtBox8.Visible = true;
                TxtBox9.Visible = true;
            }

            else if (CbCusType.SelectedIndex == 3)
            {
                lblDepartment.Visible = false;
                lblschoolAddress.Visible = false;
                lblYearLevel.Visible = false;
                lblSchoolName.Visible = false;
                TxtBox8.Visible = false;
                TxtBox9.Visible = false;
                lblBusiType.Visible = false;
                lblreason.Visible = false;
                TxtBox8.Visible = false;
                lblbusi.Visible = false;
                lblbusiAdd.Visible = false;
                lblDisType.Visible = true;
                lblreason.Visible = true;
                TxtBox7.Visible = true;
                TxtBox9.Visible = true;
                

            }
            else if(CbCusType.SelectedIndex == 7)
            {
                lblDisType.Visible = false;
                lblDepartment.Visible = false;
                lblschoolAddress.Visible = false;
                lblYearLevel.Visible = false;
                lblSchoolName.Visible = false;
                TxtBox9.Visible = false;
                lblreason.Visible = false;
                TxtBox8.Visible = true;
                lblBusiType.Visible = true;
                lblbusi.Visible = true;
                lblbusiAdd.Visible = true;
                TxtBox7.Visible = true;
                TxtBox9.Visible = true;
            }
            else
            {
                lblDisType.Visible = false;
                lblDepartment.Visible = false;
                lblschoolAddress.Visible = false;
                lblYearLevel.Visible = false;
                lblSchoolName.Visible = false;
                TxtBox8.Visible = false;
                TxtBox9.Visible = false;
                lblBusiType.Visible = false;
                TxtBox7.Visible = false;
                lblbusi.Visible = false;
                lblbusiAdd.Visible = false;
                lblreason.Visible = false;
            }
        }

        private void TxtBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtFirstName.Focus();
            }
        }

        private void TxtBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                cbGender.Focus();
            }
        }
        private void cbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MaskedBirth.Focus();
            }
        }
        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProvince.Focus();
            }
        }

        private void TxtBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCity.Focus();
            }
        }

        private void TxtBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtbarangay.Focus();
            }
        }

        private void txtbarangay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void TxtBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MaskedCelNo.Focus();
            }
        }

        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CbCusType.Focus();
            }
        }

        private void CbCusType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtBox7.Focus();
            }
        }

        private void TxtBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtBox9.Focus();
            }
        }

          private void Registration_Load(object sender, EventArgs e)
        {
            CbCusType.Items.AddRange(new string[] { "OSYA", "Teacher","Student","PWD","OFW", "Employee", "Senior Citizen", "Entrepreneurs", "Indigenous People" });
            cbGender.Items.AddRange(new string[] { "Male", "Female"});
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
        }
    }
}


