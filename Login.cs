using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;



namespace netnetcafe
{
    public partial class Login : Form
    {
        [DllImport("user32")]
        public static extern void LockWorkStation();
        [DllImport("user32")]
        public static extern void ExitWindowsEx(GraphicsUnit uFlags, uint dwreason);
        const int SC_CLOSE = 0xF060;
        const int MF_GRAYED = 0x1;
        const int MF_DISABLED = 0x00000002;


        [DllImport("user32")]
        private static extern IntPtr GetSystemMenu(IntPtr HWNDValue, bool Revert);
        [DllImport("user32")]
        private static extern int EnableMenuItem(IntPtr tMenu, int targetItem, int targetStatus);


        [DllImport("user32")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32")]
        private static extern int ShowWindow(int hwnd, int command);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        public const int WH_KEYBOARD_LL = 13;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WM_SYSKEYUP = 0x0105;
        public const int VK_TAB = 0x9;
        public const int VK_MENU = 0x12; /* Alt key */
        public const int VK_ESCAPE = 0x1B;
        public const int VK_F4 = 0x73;
        public const int VK_LWIN = 0x5B;
        public const int VK_RWIN = 0x5C;
        public const int VK_CONTROL = 0x11;
        public const int VK_LCONTROL = 0xA2;
        public const int VK_RCONTROL = 0xA3;

        [StructLayout(LayoutKind.Sequential)]
        public class KeyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        static int hKeyboardHook = 0;
        HookProc KeyboardHookProcedure;

        public void HookStart()
        {
            if (hKeyboardHook == 0)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    IntPtr hModule = GetModuleHandle(curModule.ModuleName);
                    hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, hModule, 0);
                }
                if (hKeyboardHook == 0)
                {
                    int error = Marshal.GetLastWin32Error();
                    HookStop();
                    throw new Exception("SetWindowsHookEx() function failed. " + "Error code: " + error.ToString());
                }
            }
        }

        public void HookStop()
        {
            bool retKeyboard = true;
            if (hKeyboardHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }
            if (!(retKeyboard))
            {
                throw new Exception("UnhookWindowsHookEx failed.");
            }
        }

        private int KeyboardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            KeyBoardHookStruct kbh = (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));
            bool bMaskKeysFlag = false;
            switch (wParam)
            {
                case WM_KEYDOWN:
                case WM_KEYUP:
                case WM_SYSKEYDOWN:
                case WM_SYSKEYUP:
                    bMaskKeysFlag = ((kbh.vkCode == VK_TAB) && (kbh.flags == 32))      /* Tab + Alt */
                                    | ((kbh.vkCode == VK_ESCAPE) && (kbh.flags == 32))   /* Esc + Alt */
                                    | ((kbh.vkCode == VK_F4) && (kbh.flags == 32))       /* F4 + Alt */
                                    | ((kbh.vkCode == VK_LWIN) && (kbh.flags == 1))    /* Left Win */
                                    | ((kbh.vkCode == VK_RWIN) && (kbh.flags == 1))    /* Right Win */
                                    | ((kbh.vkCode == VK_ESCAPE) && (kbh.flags == 0)); /* Ctrl + Esc */
                    break;
                default:
                    break;
            }

            if (bMaskKeysFlag == true)
            {
                return 1;
            }
            else
            {
                return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
            }
        }
        int TryCtr = 0;
        public static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=netcafedatabase;";


        MySqlConnection connect = new MySqlConnection(connectionString);

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (rdbtnAdmin.Checked)
            {

                connect.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from accounttable where UserName1 = '" + txtUsername.Text + "' and Password1= '" + txtPassword.Text + "'", connect);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {

                    this.Hide();
                    //Form7 form7 = new Form7(txtUsername.Text);
                    //form7.ShowDialog();
                    new Menu().Show();
                    int hwnd = FindWindow("Shell_TrayWnd", "");
                    ShowWindow(hwnd, SW_SHOW);
                    HookStop();
                    connect.Close();



                }
                else
                {
                    MessageBox.Show("Please Enter Correct Username and Password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //TryCtr++;
                    //if (TryCtr > 3)
                    //{
                    //    MessageBox.Show("your account has been locked");
                    //    string sql = "update login set status = 'LOCKED' where username='" + txtUsername.Text + "'";
                    //    MySqlCommand cmd = new MySqlCommand(sql, connect);
                    //    cmd.ExecuteNonQuery();
                    //    connect.Close();
                    connect.Close();

                }


            }
            else
            {

               
                    MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from accounttable where Username1 = '" + txtUsername.Text + "' and Password1 = '" + txtPassword.Text + "'", connect);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                    connect.Open();
                    MySqlCommand cmd3 = new MySqlCommand("select AcountID from accounttable where UserName1 = '" + txtUsername.Text + "' and Password1 = '" + txtPassword.Text + "'", connect);
                    MySqlDataReader read1 = cmd3.ExecuteReader();
                    read1.Read();
                    string ActId1 = read1.GetString("AcountID");


                    read1.Close();
                    MySqlCommand cmd2 = new MySqlCommand("select * from timetable where AccountID = '" + ActId1 + "' ", connect);
                    MySqlDataReader read2 = cmd2.ExecuteReader();
                    read2.Read();

                    int x = read2.GetInt16(0);

                    int h = read2.GetInt16(1);
                    int m = read2.GetInt16(1);
                    int s = read2.GetInt16(1);

                    read2.Close();
                    connect.Close();








                    if (h <0 )
                    {
                       
                        MessageBox.Show("You cannot login because you have no time");

                        read2.Close();
                        connect.Close();

                    }
                    else
                    {
                        connect.Open();
                     
                        MySqlCommand cmd = new MySqlCommand("select AcountID from accounttable where UserName1 = '" + txtUsername.Text + "' ", connect);

                        MySqlDataReader read = cmd.ExecuteReader();
                        read.Read();
                        string ActId = read.GetString("AcountID");
                        label4.Text = ActId;
                        read.Close();
                        MySqlCommand cmd1 = new MySqlCommand("INSERT INTO customerlogtable(AccountID, Status) VALUES('" + ActId + "','IN')", connect);
                        cmd1.ExecuteNonQuery();
                        this.Hide();
                        int hwnd = FindWindow("Shell_TrayWnd", "");
                        ShowWindow(hwnd, SW_SHOW);
                        HookStop();

                        Form6 timer = new Form6(label4.Text);


                        timer.ShowDialog();





                        connect.Close();
                    }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Correct Username and Password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //TryCtr++;
                        //if (TryCtr > 3)
                        //{
                        //    MessageBox.Show("your account has been locked");
                        //    string sql = "update login set status = 'LOCKED' where username='" + txtUsername.Text + "'";
                        //    MySqlCommand cmd = new MySqlCommand(sql, connect);
                        //    cmd.ExecuteNonQuery();
                        //    connect.Close();
                        connect.Close();
                    }
                
            }

        }

        private void btnSignUp_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Registration().Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
            


            int hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_HIDE);
            HookStart();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
           
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();

            }
        }
    }
}
