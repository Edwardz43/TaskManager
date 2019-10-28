using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
             
        private string[] GameArray;

        private Point mouseOffset;      

        public Form1()
        {
            InitializeComponent();
            objects = new BindingList<ProcessInfo>();            
            GameArray = ConfigurationManager.AppSettings["GameList"].Split(',');            
            GetAppList();
            var toggle = bool.Parse(ConfigurationManager.AppSettings["ButtonSwitch"]);
            this.buttonInvokeAll.Enabled = toggle;
            this.buttonTerminate.Enabled = toggle;
            this.buttonInvoke.Enabled = toggle;
            this.buttonTerminateAll.Enabled = toggle;
        }

        /// <summary>
        /// 讀取 App 列表
        /// </summary>
        private void GetAppList()
        {
            objects.Clear();

            Process[] processesList = Process.GetProcessesByName("DemoApp");

            Dictionary<string, bool> pathDic = new Dictionary<string, bool>(); 

            string[] gameList = ConfigurationManager.AppSettings["GameList"].Split(',');

            foreach (string game in GameArray)
            {
                string root = ConfigurationManager.AppSettings["AppPath"].ToString(); // 記得修改路徑

                List<string>deskList =  SearchDeskList(root, game);

                if (deskList != null)
                {
                    foreach (string desk in deskList)
                    {
                        string path = new StringBuilder(root)
                            .Append(game)
                            .Append('\\')
                            .Append(desk)
                            .Append("\\DemoApp.exe").ToString();

                        ProcessInfo process = new ProcessInfo
                        {
                            Name = new StringBuilder(game).Append('\\').Append(desk).ToString(),
                            ID = 0,
                            Path = path
                        };

                        objects.Add(process);
                        pathDic[path] = false;
                    }
                }
            }            

            foreach (ProcessInfo pi in objects)
            {
                if (processesList.Length == 0)
                {
                    listBoxClose.ValueMember = null;
                    listBoxClose.DisplayMember = "Name";
                    listBoxClose.Items.Add(pi);
                }
                else
                {
                    foreach (Process p in processesList)
                    {
                        string sourcePath = p.MainModule.FileName;
                        if (sourcePath == pi.Path)
                        {
                            pi.ID = p.Id;                            
                            listBoxRunning.ValueMember = null;
                            listBoxRunning.DisplayMember = "Name";
                            listBoxRunning.Items.Add(pi);
                            pathDic[pi.Path] = true;
                        }                      
                    }

                    if (!pathDic[pi.Path])
                    {
                        listBoxClose.ValueMember = null;
                        listBoxClose.DisplayMember = "Name";
                        listBoxClose.Items.Add(pi);
                        pathDic[pi.Path] = true;
                    }
                }
            }            
        }

        /// <summary>
        /// 搜索各遊戲桌別列表
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private List<string> SearchDeskList(string root, string target)
        {
            List<string> result = new List<string>();

            string path = new StringBuilder(root).Append('\\').Append(target).ToString();

            string[] pathList;
            try
            {
                pathList = Directory.GetDirectories(path);
                foreach (string pathName in pathList)
                {
                    var p = pathName.Split('\\');
                    result.Add(p[p.Length - 1]);
                }
                return result;
            }
            catch
            {
                //MessageBox.Show("設定檔錯誤! 請確認遊戲列表是否正確");
                return null;
            }
        }

        /// <summary>
        /// 關閉程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TerminateProcess(object sender, EventArgs e)
        {
            ProcessInfo info = (ProcessInfo)listBoxRunning.SelectedItem;
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
                listBoxRunning.Items.Remove(info);
                info.ID = 0;
                listBoxClose.ValueMember = null;
                listBoxClose.DisplayMember = "Name";
                listBoxClose.Items.Add(info);
            }

        }

        /// <summary>
        /// 開啟程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvokeBtn(object sender, EventArgs e)
        {            
            ProcessInfo process = ((ProcessInfo)listBoxClose.SelectedItem);
            if (process != null)
            {
                Process p = Process.Start(process.Path);                
                process.ID = p.Id;               
                listBoxClose.Items.Remove(process);
                listBoxRunning.ValueMember = null;
                listBoxRunning.DisplayMember = "Name";
                process.ID = p.Id;
                listBoxRunning.Items.Add(process);               
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
                    listBoxClose.Items.Remove(process);
                    listBoxRunning.ValueMember = null;
                    listBoxRunning.DisplayMember = "Name";
                    process.ID = p.Id;
                    listBoxRunning.Items.Add(process);
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
                    listBoxRunning.Items.Remove(process);                  
                    listBoxClose.ValueMember = null;
                    listBoxClose.DisplayMember = "Name";
                    listBoxClose.Items.Add(process);
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

        /// <summary>
        /// 關閉程式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseLabel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        /// <summary>
        /// 拖移視窗 (mouse move)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitalbarLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        /// <summary>
        /// 拖移視窗 (mouse down)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitalbarLabel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseOffset = new Point(-e.X, -e.Y);
        }

        /// <summary>
        /// 縮小視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NarrowLabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = true;
        }

        /// <summary>
        /// 確認是否關閉視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("確認結束程式?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
