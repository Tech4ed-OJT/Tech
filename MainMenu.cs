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
    public partial class Menu : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=netcafedatabase;";
        
        public Menu()
        {
            InitializeComponent();
        }


        private void aDDTIMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gbAccMain.Hide();
            gbAddTime.Show();
            dataGridView1.Hide();
            dataGridView2.Hide();
            gbCharts.Hide();

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
                txtUsername.Enabled = false;

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
                txtUsername.Enabled = false;


            }
            else
            {
                MessageBox.Show("Account doesn't Exist");

            }
            reader.Close();
            databaseConnection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("No Account Selected!");
            }
            else
            {
                if (int.Parse(NumHour.Text) == 0 && int.Parse(numMinutes.Text) == 0)
                {
                    MessageBox.Show("Hours or Minutes must have values!");
                }
                else
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

                        int h = read2.GetInt16(1);
                        int m = read2.GetInt16(2);
                        int s = read2.GetInt16(3);




                        read2.Close();


                        //int h = 2;
                        //int m = 2;
                        //int s = 2;
                        if (h < 0)
                        {
                            h = 0 + int.Parse(NumHour.Text);
                            m = 0 + int.Parse(numMinutes.Text);


                            MySqlCommand cmd5 = new MySqlCommand("UPDATE timetable set H ='" + h + "', M ='" + m + "', S=" + 0 + " where AccountID='" + ActId + "' ", connect);
                            cmd5.ExecuteNonQuery();
                            connect.Close();
                            MessageBox.Show("Time Added Successfully!");
                        }
                        else
                        {
                            h = h + int.Parse(NumHour.Text);
                            m = m + int.Parse(numMinutes.Text);

                            MySqlCommand cmd1 = new MySqlCommand("UPDATE timetable set H ='" + h + "', M ='" + m + "', S='" + s + "' where AccountID='" + ActId + "' ", connect);
                            cmd1.ExecuteNonQuery();
                            connect.Close();
                            MessageBox.Show("Time Added Successfully!");
                        }


                    }
                    catch (Exception exq)
                    {
                        MessageBox.Show(exq.Message);
                    }
                }
            }
        }

        private void aCCOUNTMAINTENANCEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gbAccMain.Show();
            gbAddTime.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();
            gbCharts.Hide();


        }

     
        private void btnIdSearch_Click_1(object sender, EventArgs e)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            string query = "select * from accounttable where AcountID = '" + txtSearch1.Text + "' ";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader = commandDatabase.ExecuteReader();
            if (reader.Read())
            {
                TxtUserName1.Text = reader.GetString("Username1");
                TxtUserName1.Enabled = false;

            }
            else
            {
                MessageBox.Show("Account doesn't Exist");

            }
            reader.Close();
            databaseConnection.Close();
        }

        private void btnNameSearch_Click_1(object sender, EventArgs e)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            string query = "select * from accounttable where UserName1 = '" + txtSearch1.Text + "' ";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader = commandDatabase.ExecuteReader();
            if (reader.Read())
            {
                TxtUserName1.Text = reader.GetString("Username1");
                TxtUserName1.Enabled = false;

            }
            else
            {
                MessageBox.Show("Account doesn't Exist");

            }
            reader.Close();
            databaseConnection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(TxtUserName1.Text == "")
            {
                MessageBox.Show("No Account to Update!");
            }
            else{ 
            if (txtPass.Text == txtConfirmpass.Text &&txtPass.Text != "" && txtConfirmpass.Text!= "" )
            {
                string query = "Update accounttable set UserName1 = '" + TxtUserName1.Text + "', Password1 = '" + txtPass.Text + "' where UserName1 ='" + TxtUserName1.Text + "'";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                try
                {
                    databaseConnection.Open();
                    commandDatabase.ExecuteNonQuery();

                    MessageBox.Show("Updated!");

                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }
                TxtUserName1.Clear();
                txtPass.Clear();
                txtConfirmpass.Clear();
                //txtSearch1.Clear();
            }
            else
            {
                MessageBox.Show("Password must Match and cannot be Null!");
                TxtUserName1.Clear();
                txtPass.Clear();
                txtConfirmpass.Clear();
                txtSearch1.Clear();

            }
        }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

            txtSearch1.Clear();
            TxtUserName1.Clear();
            txtPass.Clear();
            txtConfirmpass.Clear();
        }

        private void clientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Show();
            gbAccMain.Hide();
            gbAddTime.Hide();
            dataGridView1.Hide();
            gbCharts.Hide();
            try
            {
                MySqlConnection connect = new MySqlConnection(connectionString);
                connect.Open();
                string selectsql = "select CustomerID as 'Customer ID' , LastName as 'Last Name', FirstName as 'First Name',Gender,Birthdate,Province,City,Barangay,EMail as 'E-mail',CelNO as 'Cellphone Number',CustomerType as 'Customer Type' from customertable";
                //string selectsql = "select * from customertable";
                MySqlDataAdapter adapt = new MySqlDataAdapter(selectsql, connect);
                DataTable atable = new DataTable();
                adapt.Fill(atable);
                dataGridView2.DataSource = atable;
                connect.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        private void customerLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            gbAccMain.Hide();
            gbAddTime.Hide();
            dataGridView2.Hide();
            gbCharts.Hide();

            try
            {
                MySqlConnection connect = new MySqlConnection(connectionString);
                connect.Open();
                string selectsql = "select TransactNo as 'Transaction Number' , AccountID as 'Account ID' , CurrentTime1 as 'Date/Time', Status as 'Status' from customerlogtable";
                //string selectsql =  "select * from customerlogtable";
                MySqlDataAdapter adapt = new MySqlDataAdapter(selectsql, connect);
                DataTable atable = new DataTable();
                adapt.Fill(atable);
                dataGridView1.DataSource = atable;
                connect.Close();
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //cbService.Items.AddRange(new string[] { "ADD TIME(PC)", "PRINTING","SCANNING","INTERNET ACCESS(OWN GADGET)" });
            //cbPaperType.Items.AddRange(new string[] { "LONG", "SHORT", "A4", "LEGAL" });
            gbAccMain.Hide();
            gbAddTime.Show();
            dataGridView1.Hide();
            dataGridView2.Hide();
            gbCharts.Hide();
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void transactionLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            gbAccMain.Hide();
            gbAddTime.Hide();
            dataGridView2.Hide();
            gbCharts.Hide();

            try
            {
                MySqlConnection connect = new MySqlConnection(connectionString);
                connect.Open();
                string selectsql = "select TransactNo as 'Transaction Number' , TransactionType as 'Transaction Type' , Type as 'Type',CurrentTime1 as 'Date/Time' from transactiontable";
                //string selectsql =  "select * from customerlogtable";
                MySqlDataAdapter adapt = new MySqlDataAdapter(selectsql, connect);
                DataTable atable = new DataTable();
                adapt.Fill(atable);
                dataGridView1.DataSource = atable;
                connect.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        private void timeMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            gbAccMain.Hide();
            gbAddTime.Hide();
            dataGridView2.Hide();
            gbCharts.Show();


            cbMonth.Items.AddRange(new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            cbYear.Items.AddRange(new string[] { "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031" });
            cbYearly.Items.AddRange(new string[] { "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031" });
            CbQyear.Items.AddRange(new string[] { "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031" });
            cbQuarts.Items.AddRange(new string[] { "1st Quarter", "2nd Quarter", "3rd Quarter", "4th Quarter" });
            foreach (var series in TransactionChart.Series)
            {
                series.Points.Clear();
            }
            PrintChart.Titles.Clear();

            foreach (var series in PrintChart.Series)
            {
                series.Points.Clear();
            }
            ScanChart.Titles.Clear();
            foreach (var series in ScanChart.Series)
            {
                series.Points.Clear();
            }
            PCAccessChart.Titles.Clear();
            foreach (var series in PCAccessChart.Series)
            {
                series.Points.Clear();
            }

            MySqlConnection connect = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=netcafedatabase;");
            connect.Open();
            MySqlDataAdapter sda0 = new MySqlDataAdapter("select count(*) from transactiontable", connect);
            DataTable dt0 = new DataTable();
            sda0.Fill(dt0);
            double total = Convert.ToInt32(dt0.Rows[0][0]);


            MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING'", connect);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            double Print = Convert.ToInt32(dt1.Rows[0][0]);

            MySqlDataAdapter sda2 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS'", connect);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            double PC = Convert.ToInt32(dt2.Rows[0][0]);

            MySqlDataAdapter sda3 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING'", connect);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            double Scan = Convert.ToInt32(dt3.Rows[0][0]);


            TransactionChart.Titles.Add("Transaction");
            TransactionChart.Series["s1"].Points.AddXY("Printing", Print);
            TransactionChart.Series["s1"].Points.AddXY("PC Access", PC);
            TransactionChart.Series["s1"].Points.AddXY("Scanning", Scan);

            lblPrint.Text = String.Format("{0:0.00}%", (Print / total) * 100);
            lblPCAccess.Text = String.Format("{0:0.00}%", (PC / total) * 100);
            lblScan.Text = String.Format("{0:0.00}%", (Scan / total) * 100);


            MySqlDataAdapter sda4 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LONG'", connect);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            int Long = Convert.ToInt32(dt4.Rows[0][0]);

            MySqlDataAdapter sda5 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'SHORT'", connect);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            int Short = Convert.ToInt32(dt5.Rows[0][0]);

            MySqlDataAdapter sda6 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'A4'", connect);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            int A4 = Convert.ToInt32(dt6.Rows[0][0]);

            MySqlDataAdapter sda7 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LEGAL'", connect);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            int Legal = Convert.ToInt32(dt7.Rows[0][0]);


            PrintChart.Titles.Add("Printing");
            PrintChart.Series["s2"].Points.AddXY("Long", Long);
            PrintChart.Series["s2"].Points.AddXY("Short", Short);
            PrintChart.Series["s2"].Points.AddXY("A4", A4);
            PrintChart.Series["s2"].Points.AddXY("Legal", Legal);

            lblLong.Text = String.Format("{0:0.00}%", (Long / Print) * 100);
            lblShort.Text = String.Format("{0:0.00}%", (Short / Print) * 100);
            lblA4.Text = String.Format("{0:0.00}%", (A4 / Print) * 100);
            lblLegal.Text = String.Format("{0:0.00}%", (Legal / Print) * 100);
            //asdasdsdasdasdasd

            MySqlDataAdapter sda8 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LONG'", connect);
            DataTable dt8 = new DataTable();
            sda8.Fill(dt8);
            int Long1 = Convert.ToInt32(dt8.Rows[0][0]);

            MySqlDataAdapter sda9 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'SHORT'", connect);
            DataTable dt9 = new DataTable();
            sda9.Fill(dt9);
            int Short1 = Convert.ToInt32(dt9.Rows[0][0]);

            MySqlDataAdapter sda10 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'A4'", connect);
            DataTable dt10 = new DataTable();
            sda10.Fill(dt10);
            int A41 = Convert.ToInt32(dt10.Rows[0][0]);

            MySqlDataAdapter sda11 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LEGAL'", connect);
            DataTable dt11 = new DataTable();
            sda11.Fill(dt11);
            int Legal1 = Convert.ToInt32(dt11.Rows[0][0]);


            ScanChart.Titles.Add("Scanning");
            ScanChart.Series["s3"].Points.AddXY("Long", Long1);
            ScanChart.Series["s3"].Points.AddXY("Short", Short1);
            ScanChart.Series["s3"].Points.AddXY("A4", A41);
            ScanChart.Series["s3"].Points.AddXY("Legal", Legal1);

            lblLong1.Text = String.Format("{0:0.00}%", (Long1 / Scan) * 100);
            lblShort1.Text = String.Format("{0:0.00}%", (Short1 / Scan) * 100);
            lblA41.Text = String.Format("{0:0.00}%", (A41 / Scan) * 100);
            lblLegal1.Text = String.Format("{0:0.00}%", (Legal1 / Scan) * 100);

            MySqlDataAdapter sda12 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Research'", connect);
            DataTable dt12 = new DataTable();
            sda12.Fill(dt12);
            int Research = Convert.ToInt32(dt12.Rows[0][0]);

            MySqlDataAdapter sda13 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Word'", connect);
            DataTable dt13 = new DataTable();
            sda13.Fill(dt13);
            int MSWord = Convert.ToInt32(dt13.Rows[0][0]);

            MySqlDataAdapter sda14 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS PowerPoint'", connect);
            DataTable dt14 = new DataTable();
            sda14.Fill(dt14);
            int MSPowerpoint = Convert.ToInt32(dt14.Rows[0][0]);

            MySqlDataAdapter sda15 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Excel'", connect);
            DataTable dt15 = new DataTable();
            sda15.Fill(dt15);
            int MSExcel = Convert.ToInt32(dt15.Rows[0][0]);

            MySqlDataAdapter sda16 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Seminar and Training'", connect);
            DataTable dt16 = new DataTable();
            sda16.Fill(dt16);
            int SeminarTraining = Convert.ToInt32(dt16.Rows[0][0]);



            PCAccessChart.Titles.Add("PC Access");
            PCAccessChart.Series["s4"].Points.AddXY("Research", Research);
            PCAccessChart.Series["s4"].Points.AddXY("MS Word", MSWord);
            PCAccessChart.Series["s4"].Points.AddXY("MS Powerpoint", MSPowerpoint);
            PCAccessChart.Series["s4"].Points.AddXY("MS Excel", MSExcel);
            PCAccessChart.Series["s4"].Points.AddXY("Seminar and Training", SeminarTraining);


            lblResearch.Text = String.Format("{0:0.00}%", (Research / PC) * 100);
            lblMSWord.Text = String.Format("{0:0.00}%", (MSWord / PC) * 100);
            lblMSPowerpoint.Text = String.Format("{0:0.00}%", (MSPowerpoint / PC) * 100);
            lblMSExcel.Text = String.Format("{0:0.00}%", (MSExcel / PC) * 100);
            lblSeminarTraining.Text = String.Format("{0:0.00}%", (SeminarTraining / PC) * 100);



        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            int[] mons = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] year = { 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030, 2031, 2032 };
            MySqlConnection connect = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=netcafedatabase;");
            connect.Open();
            if (cbMonth.Text == "" || cbYear.Text == "")
            {
                MessageBox.Show("Must select Month and Year");
            }
            else
            {
                TransactionChart.Titles.Clear();
                foreach (var series in TransactionChart.Series)
                {
                    series.Points.Clear();
                }
                PrintChart.Titles.Clear();
                foreach (var series in PrintChart.Series)
                {
                    series.Points.Clear();
                }
                ScanChart.Titles.Clear();
                foreach (var series in ScanChart.Series)
                {
                    series.Points.Clear();
                }
                PCAccessChart.Titles.Clear();
                foreach (var series in PCAccessChart.Series)
                {
                    series.Points.Clear();
                }
                int i = cbMonth.SelectedIndex;
                int j = cbYear.SelectedIndex;
                MySqlDataAdapter sda0 = new MySqlDataAdapter("select count(*) from transactiontable where MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt0 = new DataTable();
                sda0.Fill(dt0);
                double total = Convert.ToInt32(dt0.Rows[0][0]);

                MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                double Print = Convert.ToInt32(dt1.Rows[0][0]);

                MySqlDataAdapter sda2 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                double PC = Convert.ToInt32(dt2.Rows[0][0]);

                MySqlDataAdapter sda3 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt3 = new DataTable();
                sda3.Fill(dt3);
                double Scan = Convert.ToInt32(dt3.Rows[0][0]);


                TransactionChart.Titles.Add("Transaction");
                TransactionChart.Series["s1"].Points.AddXY("Printing", Print);
                TransactionChart.Series["s1"].Points.AddXY("PC Access", PC);
                TransactionChart.Series["s1"].Points.AddXY("Scanning", Scan);

                lblPrint.Text = String.Format("{0:0.00}%", (Print / total) * 100);
                lblPCAccess.Text = String.Format("{0:0.00}%", (PC / total) * 100);
                lblScan.Text = String.Format("{0:0.00}%", (Scan / total) * 100);

                MySqlDataAdapter sda4 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LONG' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt4 = new DataTable();
                sda4.Fill(dt4);
                int Long = Convert.ToInt32(dt4.Rows[0][0]);

                MySqlDataAdapter sda5 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'SHORT' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt5 = new DataTable();
                sda5.Fill(dt5);
                int Short = Convert.ToInt32(dt5.Rows[0][0]);

                MySqlDataAdapter sda6 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'A4' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt6 = new DataTable();
                sda6.Fill(dt6);
                int A4 = Convert.ToInt32(dt6.Rows[0][0]);

                MySqlDataAdapter sda7 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LEGAL'  and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt7 = new DataTable();
                sda7.Fill(dt7);
                int Legal = Convert.ToInt32(dt7.Rows[0][0]);


                PrintChart.Titles.Add("Printing");
                PrintChart.Series["s2"].Points.AddXY("Long", Long);
                PrintChart.Series["s2"].Points.AddXY("Short", Short);
                PrintChart.Series["s2"].Points.AddXY("A4", A4);
                PrintChart.Series["s2"].Points.AddXY("Legal", Legal);

                lblLong.Text = String.Format("{0:0.00}%", (Long / Print) * 100);
                lblShort.Text = String.Format("{0:0.00}%", (Short / Print) * 100);
                lblA4.Text = String.Format("{0:0.00}%", (A4 / Print) * 100);
                lblLegal.Text = String.Format("{0:0.00}%", (Legal / Print) * 100);

                MySqlDataAdapter sda8 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LONG' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt8 = new DataTable();
                sda8.Fill(dt8);
                int Long1 = Convert.ToInt32(dt8.Rows[0][0]);

                MySqlDataAdapter sda9 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'SHORT' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt9 = new DataTable();
                sda9.Fill(dt9);
                int Short1 = Convert.ToInt32(dt9.Rows[0][0]);

                MySqlDataAdapter sda10 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'A4' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt10 = new DataTable();
                sda10.Fill(dt10);
                int A41 = Convert.ToInt32(dt10.Rows[0][0]);

                MySqlDataAdapter sda11 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LEGAL' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt11 = new DataTable();
                sda11.Fill(dt11);
                int Legal1 = Convert.ToInt32(dt11.Rows[0][0]);


                ScanChart.Titles.Add("Scanning");
                ScanChart.Series["s3"].Points.AddXY("Long", Long1);
                ScanChart.Series["s3"].Points.AddXY("Short", Short1);
                ScanChart.Series["s3"].Points.AddXY("A4", A41);
                ScanChart.Series["s3"].Points.AddXY("Legal", Legal1);

                lblLong1.Text = String.Format("{0:0.00}%", (Long1 / Scan) * 100);
                lblShort1.Text = String.Format("{0:0.00}%", (Short1 / Scan) * 100);
                lblA41.Text = String.Format("{0:0.00}%", (A41 / Scan) * 100);
                lblLegal1.Text = String.Format("{0:0.00}%", (Legal1 / Scan) * 100);

                MySqlDataAdapter sda12 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Research' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt12 = new DataTable();
                sda12.Fill(dt12);
                int Research = Convert.ToInt32(dt12.Rows[0][0]);

                MySqlDataAdapter sda13 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Word' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt13 = new DataTable();
                sda13.Fill(dt13);
                int MSWord = Convert.ToInt32(dt13.Rows[0][0]);

                MySqlDataAdapter sda14 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS PowerPoint' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt14 = new DataTable();
                sda14.Fill(dt14);
                int MSPowerpoint = Convert.ToInt32(dt14.Rows[0][0]);

                MySqlDataAdapter sda15 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Excel' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt15 = new DataTable();
                sda15.Fill(dt15);
                int MSExcel = Convert.ToInt32(dt15.Rows[0][0]);

                MySqlDataAdapter sda16 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Seminar and Training' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                DataTable dt16 = new DataTable();
                sda16.Fill(dt16);
                int SeminarTraining = Convert.ToInt32(dt16.Rows[0][0]);

                PCAccessChart.Titles.Add("PC Access");
                PCAccessChart.Series["s4"].Points.AddXY("Research", Research);
                PCAccessChart.Series["s4"].Points.AddXY("MS Word", MSWord);
                PCAccessChart.Series["s4"].Points.AddXY("MS Powerpoint", MSPowerpoint);
                PCAccessChart.Series["s4"].Points.AddXY("MS Excel", MSExcel);
                PCAccessChart.Series["s4"].Points.AddXY("Seminar and Training", SeminarTraining);


                lblResearch.Text = String.Format("{0:0.00}%", (Research / PC) * 100);
                lblMSWord.Text = String.Format("{0:0.00}%", (MSWord / PC) * 100);
                lblMSPowerpoint.Text = String.Format("{0:0.00}%", (MSPowerpoint / PC) * 100);
                lblMSExcel.Text = String.Format("{0:0.00}%", (MSExcel / PC) * 100);
                lblSeminarTraining.Text = String.Format("{0:0.00}%", (SeminarTraining / PC) * 100);


            }
        }

        private void btnAnnual_Click(object sender, EventArgs e)
        {
            int[] mons = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] year = { 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030, 2031, 2032 };
            MySqlConnection connect = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=netcafedatabase;");
            connect.Open();
            if (cbYearly.Text == "")
            {
                MessageBox.Show("Year must have Values");
            }
            else
            {
                TransactionChart.Titles.Clear();
                foreach (var series in TransactionChart.Series)
                {
                    series.Points.Clear();
                }
                PrintChart.Titles.Clear();

                foreach (var series in PrintChart.Series)
                {
                    series.Points.Clear();
                }
                ScanChart.Titles.Clear();
                foreach (var series in ScanChart.Series)
                {
                    series.Points.Clear();
                }
                PCAccessChart.Titles.Clear();
                foreach (var series in PCAccessChart.Series)
                {
                    series.Points.Clear();
                }


                double total = 0.0, Print = 0.0, PC = 0.0, Scan = 0.0, Long = 0.0, Short = 0.0, A4 = 0.0, Legal = 0.0, Long1 = 0.0, Short1 = 0.0, A41 = 0.0, Legal1 = 0.0, Research = 0.0, MSWord = 0.0, MSPowerpoint = 0.0, MSExcel = 0.0, SeminarTraining = 0.0;
                int j = cbYearly.SelectedIndex;
                for (int i = 0; i < 12; i++)
                {
                    MySqlDataAdapter sda0 = new MySqlDataAdapter("select count(*) from transactiontable where MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt0 = new DataTable();
                    sda0.Fill(dt0);
                    total = total + Convert.ToInt32(dt0.Rows[0][0]);

                    MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    Print = Print + Convert.ToInt32(dt1.Rows[0][0]);

                    MySqlDataAdapter sda2 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    PC = PC + Convert.ToInt32(dt2.Rows[0][0]);

                    MySqlDataAdapter sda3 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt3 = new DataTable();
                    sda3.Fill(dt3);
                    Scan = Scan + Convert.ToInt32(dt3.Rows[0][0]);

                    MySqlDataAdapter sda4 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LONG' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt4 = new DataTable();
                    sda4.Fill(dt4);
                    Long = Long + Convert.ToInt32(dt4.Rows[0][0]);

                    MySqlDataAdapter sda5 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'SHORT' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt5 = new DataTable();
                    sda5.Fill(dt5);
                    Short = Short + Convert.ToInt32(dt5.Rows[0][0]);

                    MySqlDataAdapter sda6 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'A4' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt6 = new DataTable();
                    sda6.Fill(dt6);
                    A4 = A4 + Convert.ToInt32(dt6.Rows[0][0]);

                    MySqlDataAdapter sda7 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LEGAL' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt7 = new DataTable();
                    sda7.Fill(dt7);
                    Legal = Legal + Convert.ToInt32(dt7.Rows[0][0]);

                    MySqlDataAdapter sda8 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LONG' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt8 = new DataTable();
                    sda8.Fill(dt8);
                    Long1 = Long1 + Convert.ToInt32(dt8.Rows[0][0]);

                    MySqlDataAdapter sda9 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'SHORT' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt9 = new DataTable();
                    sda9.Fill(dt9);
                    Short1 = Short1 + Convert.ToInt32(dt9.Rows[0][0]);

                    MySqlDataAdapter sda10 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'A4' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt10 = new DataTable();
                    sda10.Fill(dt10);
                    A41 = A41 + Convert.ToInt32(dt10.Rows[0][0]);

                    MySqlDataAdapter sda11 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LEGAL' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt11 = new DataTable();
                    sda11.Fill(dt11);
                    Legal1 = Legal1 + Convert.ToInt32(dt11.Rows[0][0]);

                    MySqlDataAdapter sda12 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Research' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt12 = new DataTable();
                    sda12.Fill(dt12);
                    Research = Research + Convert.ToInt32(dt12.Rows[0][0]);

                    MySqlDataAdapter sda13 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Word' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt13 = new DataTable();
                    sda13.Fill(dt13);
                    MSWord = MSWord + Convert.ToInt32(dt13.Rows[0][0]);

                    MySqlDataAdapter sda14 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS PowerPoint' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt14 = new DataTable();
                    sda14.Fill(dt14);
                    MSPowerpoint = MSPowerpoint + Convert.ToInt32(dt14.Rows[0][0]);

                    MySqlDataAdapter sda15 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Excel' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt15 = new DataTable();
                    sda15.Fill(dt15);
                    MSExcel = MSExcel + Convert.ToInt32(dt15.Rows[0][0]);

                    MySqlDataAdapter sda16 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Seminar and Training' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                    DataTable dt16 = new DataTable();
                    sda16.Fill(dt16);
                    SeminarTraining = SeminarTraining + Convert.ToInt32(dt16.Rows[0][0]);
                }


                TransactionChart.Titles.Add("Transaction");
                TransactionChart.Series["s1"].Points.AddXY("Printing", Print);
                TransactionChart.Series["s1"].Points.AddXY("PC Access", PC);
                TransactionChart.Series["s1"].Points.AddXY("Scanning", Scan);

                lblPrint.Text = String.Format("{0:0.00}%", (Print / total) * 100);
                lblPCAccess.Text = String.Format("{0:0.00}%", (PC / total) * 100);
                lblScan.Text = String.Format("{0:0.00}%", (Scan / total) * 100);


                PrintChart.Titles.Add("Printing");
                PrintChart.Series["s2"].Points.AddXY("Long", Long);
                PrintChart.Series["s2"].Points.AddXY("Short", Short);
                PrintChart.Series["s2"].Points.AddXY("A4", A4);
                PrintChart.Series["s2"].Points.AddXY("Legal", Legal);

                lblLong.Text = String.Format("{0:0.00}%", (Long / Print) * 100);
                lblShort.Text = String.Format("{0:0.00}%", (Short / Print) * 100);
                lblA4.Text = String.Format("{0:0.00}%", (A4 / Print) * 100);
                lblLegal.Text = String.Format("{0:0.00}%", (Legal / Print) * 100);

                ScanChart.Titles.Add("Scanning");
                ScanChart.Series["s3"].Points.AddXY("Long", Long1);
                ScanChart.Series["s3"].Points.AddXY("Short", Short1);
                ScanChart.Series["s3"].Points.AddXY("A4", A41);
                ScanChart.Series["s3"].Points.AddXY("Legal", Legal1);

                lblLong1.Text = String.Format("{0:0.00}%", (Long1 / Scan) * 100);
                lblShort1.Text = String.Format("{0:0.00}%", (Short1 / Scan) * 100);
                lblA41.Text = String.Format("{0:0.00}%", (A41 / Scan) * 100);
                lblLegal1.Text = String.Format("{0:0.00}%", (Legal1 / Scan) * 100);

                PCAccessChart.Titles.Add("PC Access");
                PCAccessChart.Series["s4"].Points.AddXY("Research", Research);
                PCAccessChart.Series["s4"].Points.AddXY("MS Word", MSWord);
                PCAccessChart.Series["s4"].Points.AddXY("MS Powerpoint", MSPowerpoint);
                PCAccessChart.Series["s4"].Points.AddXY("MS Excel", MSExcel);
                PCAccessChart.Series["s4"].Points.AddXY("Seminar and Training", SeminarTraining);


                lblResearch.Text = String.Format("{0:0.00}%", (Research / PC) * 100);
                lblMSWord.Text = String.Format("{0:0.00}%", (MSWord / PC) * 100);
                lblMSPowerpoint.Text = String.Format("{0:0.00}%", (MSPowerpoint / PC) * 100);
                lblMSExcel.Text = String.Format("{0:0.00}%", (MSExcel / PC) * 100);
                lblSeminarTraining.Text = String.Format("{0:0.00}%", (SeminarTraining / PC) * 100);

            }
        }

        private void btnQuarterly_Click(object sender, EventArgs e)
        {
            int[] mons = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] year = { 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030, 2031, 2032 };
            MySqlConnection connect = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=netcafedatabase;");
            connect.Open();
            if (cbQuarts.Text == "" || CbQyear.Text == "")
            {
                MessageBox.Show("Must select Month and Year");
            }
            else
            {
                TransactionChart.Titles.Clear();
                foreach (var series in TransactionChart.Series)
                {
                    series.Points.Clear();
                }
                PrintChart.Titles.Clear();

                foreach (var series in PrintChart.Series)
                {
                    series.Points.Clear();
                }
                ScanChart.Titles.Clear();
                foreach (var series in ScanChart.Series)
                {
                    series.Points.Clear();
                }
                PCAccessChart.Titles.Clear();
                foreach (var series in PCAccessChart.Series)
                {
                    series.Points.Clear();
                }
                double total = 0.0, Print = 0.0, PC = 0.0, Scan = 0.0, Long = 0.0, Short = 0.0, A4 = 0.0, Legal = 0.0, Long1 = 0.0, Short1 = 0.0, A41 = 0.0, Legal1 = 0.0, Research = 0.0, MSWord = 0.0, MSPowerpoint = 0.0, MSExcel = 0.0, SeminarTraining = 0.0;

                //int i = cbQuarts.SelectedIndex;
                int j = CbQyear.SelectedIndex;
                if (cbQuarts.SelectedIndex == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        MySqlDataAdapter sda0 = new MySqlDataAdapter("select count(*) from transactiontable where MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt0 = new DataTable();
                        sda0.Fill(dt0);
                        total = total + Convert.ToInt32(dt0.Rows[0][0]);

                        MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);
                        Print = Print + Convert.ToInt32(dt1.Rows[0][0]);

                        MySqlDataAdapter sda2 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);
                        PC = PC + Convert.ToInt32(dt2.Rows[0][0]);

                        MySqlDataAdapter sda3 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt3 = new DataTable();
                        sda3.Fill(dt3);
                        Scan = Scan + Convert.ToInt32(dt3.Rows[0][0]);

                        MySqlDataAdapter sda4 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LONG' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt4 = new DataTable();
                        sda4.Fill(dt4);
                        Long = Long + Convert.ToInt32(dt4.Rows[0][0]);

                        MySqlDataAdapter sda5 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'SHORT' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt5 = new DataTable();
                        sda5.Fill(dt5);
                        Short = Short + Convert.ToInt32(dt5.Rows[0][0]);

                        MySqlDataAdapter sda6 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'A4' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt6 = new DataTable();
                        sda6.Fill(dt6);
                        A4 = A4 + Convert.ToInt32(dt6.Rows[0][0]);

                        MySqlDataAdapter sda7 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LEGAL' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt7 = new DataTable();
                        sda7.Fill(dt7);
                        Legal = Legal + Convert.ToInt32(dt7.Rows[0][0]);

                        MySqlDataAdapter sda8 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LONG' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt8 = new DataTable();
                        sda8.Fill(dt8);
                        Long1 = Long1 + Convert.ToInt32(dt8.Rows[0][0]);

                        MySqlDataAdapter sda9 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'SHORT' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt9 = new DataTable();
                        sda9.Fill(dt9);
                        Short1 = Short1 + Convert.ToInt32(dt9.Rows[0][0]);

                        MySqlDataAdapter sda10 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'A4' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt10 = new DataTable();
                        sda10.Fill(dt10);
                        A41 = A41 + Convert.ToInt32(dt10.Rows[0][0]);

                        MySqlDataAdapter sda11 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LEGAL' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt11 = new DataTable();
                        sda11.Fill(dt11);
                        Legal1 = Legal1 + Convert.ToInt32(dt11.Rows[0][0]);

                        MySqlDataAdapter sda12 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Research' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt12 = new DataTable();
                        sda12.Fill(dt12);
                        Research = Research + Convert.ToInt32(dt12.Rows[0][0]);

                        MySqlDataAdapter sda13 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Word' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt13 = new DataTable();
                        sda13.Fill(dt13);
                        MSWord = MSWord + Convert.ToInt32(dt13.Rows[0][0]);

                        MySqlDataAdapter sda14 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS PowerPoint' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt14 = new DataTable();
                        sda14.Fill(dt14);
                        MSPowerpoint = MSPowerpoint + Convert.ToInt32(dt14.Rows[0][0]);

                        MySqlDataAdapter sda15 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Excel' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt15 = new DataTable();
                        sda15.Fill(dt15);
                        MSExcel = MSExcel + Convert.ToInt32(dt15.Rows[0][0]);

                        MySqlDataAdapter sda16 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Seminar and Training' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt16 = new DataTable();
                        sda16.Fill(dt16);
                        SeminarTraining = SeminarTraining + Convert.ToInt32(dt16.Rows[0][0]);
                    }
                }
                else if (cbQuarts.SelectedIndex == 1)
                {
                    for (int i = 3; i < 6; i++)
                    {
                        MySqlDataAdapter sda0 = new MySqlDataAdapter("select count(*) from transactiontable where MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt0 = new DataTable();
                        sda0.Fill(dt0);
                        total = total + Convert.ToInt32(dt0.Rows[0][0]);

                        MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);
                        Print = Print + Convert.ToInt32(dt1.Rows[0][0]);

                        MySqlDataAdapter sda2 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);
                        PC = PC + Convert.ToInt32(dt2.Rows[0][0]);

                        MySqlDataAdapter sda3 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt3 = new DataTable();
                        sda3.Fill(dt3);
                        Scan = Scan + Convert.ToInt32(dt3.Rows[0][0]);

                        MySqlDataAdapter sda4 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LONG' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt4 = new DataTable();
                        sda4.Fill(dt4);
                        Long = Long + Convert.ToInt32(dt4.Rows[0][0]);

                        MySqlDataAdapter sda5 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'SHORT' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt5 = new DataTable();
                        sda5.Fill(dt5);
                        Short = Short + Convert.ToInt32(dt5.Rows[0][0]);

                        MySqlDataAdapter sda6 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'A4' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt6 = new DataTable();
                        sda6.Fill(dt6);
                        A4 = A4 + Convert.ToInt32(dt6.Rows[0][0]);

                        MySqlDataAdapter sda7 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LEGAL' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt7 = new DataTable();
                        sda7.Fill(dt7);
                        Legal = Legal + Convert.ToInt32(dt7.Rows[0][0]);

                        MySqlDataAdapter sda8 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LONG' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt8 = new DataTable();
                        sda8.Fill(dt8);
                        Long1 = Long1 + Convert.ToInt32(dt8.Rows[0][0]);

                        MySqlDataAdapter sda9 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'SHORT' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt9 = new DataTable();
                        sda9.Fill(dt9);
                        Short1 = Short1 + Convert.ToInt32(dt9.Rows[0][0]);

                        MySqlDataAdapter sda10 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'A4' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt10 = new DataTable();
                        sda10.Fill(dt10);
                        A41 = A41 + Convert.ToInt32(dt10.Rows[0][0]);

                        MySqlDataAdapter sda11 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LEGAL' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt11 = new DataTable();
                        sda11.Fill(dt11);
                        Legal1 = Legal1 + Convert.ToInt32(dt11.Rows[0][0]);

                        MySqlDataAdapter sda12 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Research' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt12 = new DataTable();
                        sda12.Fill(dt12);
                        Research = Research + Convert.ToInt32(dt12.Rows[0][0]);

                        MySqlDataAdapter sda13 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Word' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt13 = new DataTable();
                        sda13.Fill(dt13);
                        MSWord = MSWord + Convert.ToInt32(dt13.Rows[0][0]);

                        MySqlDataAdapter sda14 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS PowerPoint' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt14 = new DataTable();
                        sda14.Fill(dt14);
                        MSPowerpoint = MSPowerpoint + Convert.ToInt32(dt14.Rows[0][0]);

                        MySqlDataAdapter sda15 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Excel' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt15 = new DataTable();
                        sda15.Fill(dt15);
                        MSExcel = MSExcel + Convert.ToInt32(dt15.Rows[0][0]);

                        MySqlDataAdapter sda16 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Seminar and Training' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt16 = new DataTable();
                        sda16.Fill(dt16);
                        SeminarTraining = SeminarTraining + Convert.ToInt32(dt16.Rows[0][0]);
                    }
                }
                else if (cbQuarts.SelectedIndex == 2)
                {
                    for (int i = 6; i < 9; i++)
                    {
                        MySqlDataAdapter sda0 = new MySqlDataAdapter("select count(*) from transactiontable where MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt0 = new DataTable();
                        sda0.Fill(dt0);
                        total = total + Convert.ToInt32(dt0.Rows[0][0]);

                        MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);
                        Print = Print + Convert.ToInt32(dt1.Rows[0][0]);

                        MySqlDataAdapter sda2 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);
                        PC = PC + Convert.ToInt32(dt2.Rows[0][0]);

                        MySqlDataAdapter sda3 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt3 = new DataTable();
                        sda3.Fill(dt3);
                        Scan = Scan + Convert.ToInt32(dt3.Rows[0][0]);

                        MySqlDataAdapter sda4 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LONG' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt4 = new DataTable();
                        sda4.Fill(dt4);
                        Long = Long + Convert.ToInt32(dt4.Rows[0][0]);

                        MySqlDataAdapter sda5 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'SHORT' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt5 = new DataTable();
                        sda5.Fill(dt5);
                        Short = Short + Convert.ToInt32(dt5.Rows[0][0]);

                        MySqlDataAdapter sda6 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'A4' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt6 = new DataTable();
                        sda6.Fill(dt6);
                        A4 = A4 + Convert.ToInt32(dt6.Rows[0][0]);

                        MySqlDataAdapter sda7 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LEGAL' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt7 = new DataTable();
                        sda7.Fill(dt7);
                        Legal = Legal + Convert.ToInt32(dt7.Rows[0][0]);

                        MySqlDataAdapter sda8 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LONG' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt8 = new DataTable();
                        sda8.Fill(dt8);
                        Long1 = Long1 + Convert.ToInt32(dt8.Rows[0][0]);

                        MySqlDataAdapter sda9 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'SHORT' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt9 = new DataTable();
                        sda9.Fill(dt9);
                        Short1 = Short1 + Convert.ToInt32(dt9.Rows[0][0]);

                        MySqlDataAdapter sda10 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'A4' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt10 = new DataTable();
                        sda10.Fill(dt10);
                        A41 = A41 + Convert.ToInt32(dt10.Rows[0][0]);

                        MySqlDataAdapter sda11 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LEGAL' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt11 = new DataTable();
                        sda11.Fill(dt11);
                        Legal1 = Legal1 + Convert.ToInt32(dt11.Rows[0][0]);

                        MySqlDataAdapter sda12 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Research' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt12 = new DataTable();
                        sda12.Fill(dt12);
                        Research = Research + Convert.ToInt32(dt12.Rows[0][0]);

                        MySqlDataAdapter sda13 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Word' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt13 = new DataTable();
                        sda13.Fill(dt13);
                        MSWord = MSWord + Convert.ToInt32(dt13.Rows[0][0]);

                        MySqlDataAdapter sda14 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS PowerPoint' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt14 = new DataTable();
                        sda14.Fill(dt14);
                        MSPowerpoint = MSPowerpoint + Convert.ToInt32(dt14.Rows[0][0]);

                        MySqlDataAdapter sda15 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Excel' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt15 = new DataTable();
                        sda15.Fill(dt15);
                        MSExcel = MSExcel + Convert.ToInt32(dt15.Rows[0][0]);

                        MySqlDataAdapter sda16 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Seminar and Training' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt16 = new DataTable();
                        sda16.Fill(dt16);
                        SeminarTraining = SeminarTraining + Convert.ToInt32(dt16.Rows[0][0]);
                    }
                }
                else if (cbQuarts.SelectedIndex == 3)
                {
                    for (int i = 9; i < 12; i++)
                    {
                        MySqlDataAdapter sda0 = new MySqlDataAdapter("select count(*) from transactiontable where MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt0 = new DataTable();
                        sda0.Fill(dt0);
                        total = total + Convert.ToInt32(dt0.Rows[0][0]);

                        MySqlDataAdapter sda1 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);
                        Print = Print + Convert.ToInt32(dt1.Rows[0][0]);

                        MySqlDataAdapter sda2 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);
                        PC = PC + Convert.ToInt32(dt2.Rows[0][0]);

                        MySqlDataAdapter sda3 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt3 = new DataTable();
                        sda3.Fill(dt3);
                        Scan = Scan + Convert.ToInt32(dt3.Rows[0][0]);

                        MySqlDataAdapter sda4 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LONG' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt4 = new DataTable();
                        sda4.Fill(dt4);
                        Long = Long + Convert.ToInt32(dt4.Rows[0][0]);

                        MySqlDataAdapter sda5 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'SHORT' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt5 = new DataTable();
                        sda5.Fill(dt5);
                        Short = Short + Convert.ToInt32(dt5.Rows[0][0]);

                        MySqlDataAdapter sda6 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'A4' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt6 = new DataTable();
                        sda6.Fill(dt6);
                        A4 = A4 + Convert.ToInt32(dt6.Rows[0][0]);

                        MySqlDataAdapter sda7 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PRINTING' and Type = 'LEGAL' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt7 = new DataTable();
                        sda7.Fill(dt7);
                        Legal = Legal + Convert.ToInt32(dt7.Rows[0][0]);

                        MySqlDataAdapter sda8 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LONG' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt8 = new DataTable();
                        sda8.Fill(dt8);
                        Long1 = Long1 + Convert.ToInt32(dt8.Rows[0][0]);

                        MySqlDataAdapter sda9 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'SHORT' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt9 = new DataTable();
                        sda9.Fill(dt9);
                        Short1 = Short1 + Convert.ToInt32(dt9.Rows[0][0]);

                        MySqlDataAdapter sda10 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'A4' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt10 = new DataTable();
                        sda10.Fill(dt10);
                        A41 = A41 + Convert.ToInt32(dt10.Rows[0][0]);

                        MySqlDataAdapter sda11 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'SCANNING' and Type = 'LEGAL' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt11 = new DataTable();
                        sda11.Fill(dt11);
                        Legal1 = Legal1 + Convert.ToInt32(dt11.Rows[0][0]);

                        MySqlDataAdapter sda12 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Research' and MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt12 = new DataTable();
                        sda12.Fill(dt12);
                        Research = Research + Convert.ToInt32(dt12.Rows[0][0]);

                        MySqlDataAdapter sda13 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Word' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt13 = new DataTable();
                        sda13.Fill(dt13);
                        MSWord = MSWord + Convert.ToInt32(dt13.Rows[0][0]);

                        MySqlDataAdapter sda14 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS PowerPoint' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt14 = new DataTable();
                        sda14.Fill(dt14);
                        MSPowerpoint = MSPowerpoint + Convert.ToInt32(dt14.Rows[0][0]);

                        MySqlDataAdapter sda15 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Use of MS Excel' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt15 = new DataTable();
                        sda15.Fill(dt15);
                        MSExcel = MSExcel + Convert.ToInt32(dt15.Rows[0][0]);

                        MySqlDataAdapter sda16 = new MySqlDataAdapter("select count(*) from transactiontable where TransactionType = 'PC ACCESS' and Type = 'Seminar and Training' and  MONTH(CurrentTime1) = " + mons[i] + " and YEAR(CurrentTime1) = " + year[j] + "", connect);
                        DataTable dt16 = new DataTable();
                        sda16.Fill(dt16);
                        SeminarTraining = SeminarTraining + Convert.ToInt32(dt16.Rows[0][0]);
                    }
                }



                TransactionChart.Titles.Add("Transaction");
                TransactionChart.Series["s1"].Points.AddXY("Printing", Print);
                TransactionChart.Series["s1"].Points.AddXY("PC Access", PC);
                TransactionChart.Series["s1"].Points.AddXY("Scanning", Scan);

                lblPrint.Text = String.Format("{0:0.00}%", (Print / total) * 100);
                lblPCAccess.Text = String.Format("{0:0.00}%", (PC / total) * 100);
                lblScan.Text = String.Format("{0:0.00}%", (Scan / total) * 100);

                PrintChart.Titles.Add("Printing");
                PrintChart.Series["s2"].Points.AddXY("Long", Long);
                PrintChart.Series["s2"].Points.AddXY("Short", Short);
                PrintChart.Series["s2"].Points.AddXY("A4", A4);
                PrintChart.Series["s2"].Points.AddXY("Legal", Legal);

                lblLong.Text = String.Format("{0:0.00}%", (Long / Print) * 100);
                lblShort.Text = String.Format("{0:0.00}%", (Short / Print) * 100);
                lblA4.Text = String.Format("{0:0.00}%", (A4 / Print) * 100);
                lblLegal.Text = String.Format("{0:0.00}%", (Legal / Print) * 100);

                ScanChart.Titles.Add("Scanning");
                ScanChart.Series["s3"].Points.AddXY("Long", Long1);
                ScanChart.Series["s3"].Points.AddXY("Short", Short1);
                ScanChart.Series["s3"].Points.AddXY("A4", A41);
                ScanChart.Series["s3"].Points.AddXY("Legal", Legal1);

                lblLong1.Text = String.Format("{0:0.00}%", (Long1 / Scan) * 100);
                lblShort1.Text = String.Format("{0:0.00}%", (Short1 / Scan) * 100);
                lblA41.Text = String.Format("{0:0.00}%", (A41 / Scan) * 100);
                lblLegal1.Text = String.Format("{0:0.00}%", (Legal1 / Scan) * 100);

                PCAccessChart.Titles.Add("PC Access");
                PCAccessChart.Series["s4"].Points.AddXY("Research", Research);
                PCAccessChart.Series["s4"].Points.AddXY("MS Word", MSWord);
                PCAccessChart.Series["s4"].Points.AddXY("MS Powerpoint", MSPowerpoint);
                PCAccessChart.Series["s4"].Points.AddXY("MS Excel", MSExcel);
                PCAccessChart.Series["s4"].Points.AddXY("Seminar and Training", SeminarTraining);


                lblResearch.Text = String.Format("{0:0.00}%", (Research / PC) * 100);
                lblMSWord.Text = String.Format("{0:0.00}%", (MSWord / PC) * 100);
                lblMSPowerpoint.Text = String.Format("{0:0.00}%", (MSPowerpoint / PC) * 100);
                lblMSExcel.Text = String.Format("{0:0.00}%", (MSExcel / PC) * 100);
                lblSeminarTraining.Text = String.Format("{0:0.00}%", (SeminarTraining / PC) * 100);

            }
        }

        private void TransactionChart_Click(object sender, EventArgs e)
        {

        }

        private void serverLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gbCharts.Hide();
        }
    }
}
