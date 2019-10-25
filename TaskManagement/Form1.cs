using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static TaskManagement.ShowWindowCommand;

namespace TaskManagement
{
    public partial class Form1 : Form
    {
        #region ConsoleWindow 相關
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);
        
        #endregion

        public BindingList<ProcessInfo> objects;

        private Dictionary<int, bool> ProcessMap;

        private string[] AppArray;

        public Form1()
        {
            InitializeComponent();
            objects = new BindingList<ProcessInfo>();
            ProcessMap = new Dictionary<int, bool>();
            AppArray = ConfigurationManager.AppSettings["AppList"].Split(',');
            GetAppList();
        }

        /// <summary>
        /// 讀取 App 列表
        /// </summary>
        private void GetAppList()
        {
            objects.Clear();
            for (int i = 0; i < AppArray.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                string root = ConfigurationManager.AppSettings["AppPath"].ToString();
                string path =
                    sb.Append(root) // 記得修改路徑
                    .Append(AppArray[i])
                    .Append("\\")                 
                    .Append("DemoApp.exe").ToString();
                ProcessInfo process = new ProcessInfo
                {
                    Name = AppArray[i],
                    ID = 0,
                    Path = path
                };
                objects.Add(process);
                string data = string.Format("name:{0}, ID:{1}, Path:{2}", process.Name, process.ID, process.Path);
                Console.WriteLine(data);

                listBox2.ValueMember = null;
                listBox2.DisplayMember = "Name";
                listBox2.Items.Add(process);
                /*listBox1.ValueMember = null;
                listBox1.DisplayMember = "Name";
                listBox1.DataSource = objects;*/
            }
            
            //listBox1.BeginUpdate();            
        }

        /// <summary>
        /// 關閉程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TerminateProcess(object sender, EventArgs e)
        {
            ProcessInfo info = (ProcessInfo)listBox1.SelectedItem;
            if (info != null)
            {
                try
                {
                    //MessageBox.Show(info.ID.ToString());
                    Process p = Process.GetProcessById(info.ID);                                        
                    p.Kill();                                      
                }
                catch
                {                    
                    MessageBox.Show("程序已終止");
                }
                listBox1.Items.Remove(info);
                info.ID = 0;
                listBox2.ValueMember = null;
                listBox2.DisplayMember = "Name";
                listBox2.Items.Add(info);
            }

        }

        /// <summary>
        /// 開啟程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvokeBtn(object sender, EventArgs e)
        {            
            ProcessInfo process = ((ProcessInfo)listBox2.SelectedItem);
            if (process != null)
            {
                Process p = Process.Start(process.Path);                
                process.ID = p.Id;               
                listBox2.Items.Remove(process);
                listBox1.ValueMember = null;
                listBox1.DisplayMember = "Name";
                process.ID = p.Id;
                listBox1.Items.Add(process);               
            }
            else
            {
                MessageBox.Show("程序執行中 ");
            }
        }

        /// <summary>
        /// 全部開啟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvokeAll(object sender, EventArgs e)
        {
            foreach (ProcessInfo process in objects)
            {
                if (process.ID == 0)
                {
                    Process p = Process.Start(process.Path);                 
                    listBox2.Items.Remove(process);
                    listBox1.ValueMember = null;
                    listBox1.DisplayMember = "Name";
                    process.ID = p.Id;
                    listBox1.Items.Add(process);
                }
            }
        }

        /// <summary>
        /// 全部關閉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TerminateAll(object sender, EventArgs e)
        {
            foreach (ProcessInfo process in objects)
            {
                if (process.ID != 0)
                {
                    Process p;
                    try
                    {
                        p = Process.GetProcessById(process.ID);
                        p.Kill();
                    }
                    catch
                    {
                        //
                    }                                       
                    process.ID = 0;
                    listBox1.Items.Remove(process);                  
                    listBox2.ValueMember = null;
                    listBox2.DisplayMember = "Name";
                    listBox2.Items.Add(process);
                }
            }
        }       
        
        /// <summary>
        /// Focus選定的 console window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetConsoleForeground(object sender, EventArgs e)
        {
            ListBox box = (ListBox)sender;
            ProcessInfo processInfo = (ProcessInfo)box.SelectedItem;
            Console.WriteLine(processInfo.ID + ", " + processInfo.Name);
            //MessageBox.Show(processInfo.ID + ", " + processInfo.Name);

            try
            {
                Process process = Process.GetProcessById(processInfo.ID);
                if (process != null)
                {
                    //process.WaitForInputIdle();
                    IntPtr s = process.MainWindowHandle;                    
                    ShowWindow(s, ShowWindowCommands.Normal);
                    SetForegroundWindow(s);                    
                    //Console.Write("Proccess found: " + process.ToString());
                }
                //listProcess();
            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: Application is not running!\nException: " + exc.Message);                
                return;
            }
        }        
    }
}
