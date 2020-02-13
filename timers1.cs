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
    public partial class Form6 : Form
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


        System.Timers.Timer t;
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=netcafedatabase;";

        int h, m,s;

       
        public Form6(string str_value)
        {
            InitializeComponent();
            labelhidden.Text = str_value;
           
            
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width, 0);
            FormBorderStyle = FormBorderStyle.None;
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
            t = new System.Timers.Timer();
            t.Interval = 1000;//1s 
            t.Elapsed += OnTimeEvent;
           
            MySqlConnection connect = new MySqlConnection(connectionString);
            connect.Open();

            MySqlCommand cmd = new MySqlCommand("select * from timetable where AccountID = '" + labelhidden.Text +"'", connect);
            MySqlDataReader readreadme = cmd.ExecuteReader();
            readreadme.Read();

            string sawakas = readreadme.GetString("AccountID");
            h = readreadme.GetInt16(1);
            m = readreadme.GetInt16(2);
            s = readreadme.GetInt16(3);



            readreadme.Close();

            connect.Close();
          





            //h = 1;
            //m = 1;
            //s = 59;



            t.Start();
            HookStop();


          

        }
        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
           {
               

                   s -= 1;
                   if (s == -1)
                   {
                       s = 59;
                       m -= 1;
                   }
                   if (m == -1)
                   {
                       m = 59;
                       h -= 1;
                   }
                   if (h == 0 && s == 0 && m == 0)
                   {
                       MessageBox.Show("time ka na");

                       FormBorderStyle = FormBorderStyle.None;
                       WindowState = FormWindowState.Maximized;
                       EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);


                       int hwnd = FindWindow("Shell_TrayWnd", "");
                       ShowWindow(hwnd, SW_HIDE);
                       HookStart();

                       this.Hide();
                       new Login().Show();
                   





                   }

                   textBox1.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
               
           }));


        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            
            MySqlConnection connect = new MySqlConnection(connectionString);
            connect.Open();

            MySqlCommand cmd = new MySqlCommand("select AcountID from accounttable where AcountID = '" + labelhidden.Text + "' ", connect);
            MySqlDataReader read = cmd.ExecuteReader();
            read.Read();
            string ActId = read.GetString("AcountID");
            read.Close();
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO customerlogtable(AccountID, Status) VALUES('" + ActId + "','OUT')", connect);
            cmd1.ExecuteNonQuery();


            connect.Close();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);


            int hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_HIDE);
            HookStart();

            this.Hide();
            new Login().Show();
            connect.Close();



        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            t.Stop();
            Application.DoEvents();
            string query = "Update timetable set H = '"+h+"', M = '" +m+ "', S = '" + s + "' where AccountID ='" + labelhidden.Text + "'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                commandDatabase.ExecuteNonQuery();

         

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
            
 


        }

        private void labelhidden_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            t.Start();

        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            t.Stop();
        }
    }
}
