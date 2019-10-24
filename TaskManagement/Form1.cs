using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace TaskManagement
{
    public partial class Form1 : Form
    {        
        public BindingList<ProcessInfo> objects;

        private Dictionary<int, bool> ProcessMap;

        private string[] AppArray = { "DemoApp1", "DemoApp2" , "DemoApp3" , "DemoApp4" };

        public Form1()
        {
            InitializeComponent();
            objects = new BindingList<ProcessInfo>();
            ProcessMap = new Dictionary<int, bool>();
            GetProccessList();
        }

        private void GetProccessList()
        {
            objects.Clear();          
            foreach (string s in AppArray)
            {               
                StringBuilder sb = new StringBuilder();
                string path =
                    sb.Append(@"C:\Users\edlo\source\repos\TaskManagement\TaskManagement\DemoApp\") // 記得修改路徑
                    .Append(s)
                    .Append("\\")
                    .Append(s)
                    .Append(".exe").ToString();
                ProcessInfo process = new ProcessInfo
                {
                    Name = s,
                    ID = 0,                    
                    Path = path
                };                
                objects.Add(process);
                string data = string.Format("name:{0}, ID:{1}, Path:{2}", process.Name, process.ID, process.Path);
                Console.WriteLine(data);
                
                comboBox1.ValueMember = null;
                comboBox1.DisplayMember = "Name";
                comboBox1.DataSource = objects;
            }                
            //comboBox1.BeginUpdate();            
        }

        private void TerminateProcess(object sender, EventArgs e)
        {
            ProcessInfo info = (ProcessInfo)comboBox1.SelectedValue;
            if (info != null)
            {
                try
                {
                    Process p = Process.GetProcessById(info.ID);                    
                    info.ID = 0;
                    p.Kill();                    
                }
                catch
                {                    
                    MessageBox.Show("程序已終止");
                }                               
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                ProcessInfo current = (ProcessInfo)comboBox1.SelectedValue;
                //MessageBox.Show(current.ID + ":" + current.Name);
            }
        }

        private void InvokeBtn(object sender, EventArgs e)
        {            
            ProcessInfo process = ((ProcessInfo)comboBox1.SelectedValue);
            if (process.ID == 0)
            {
                Process p = Process.Start(process.Path);                
                process.ID = p.Id;
            }
            else
            {
                MessageBox.Show("程序執行中 ");
            }
        }

        private void InvokeAll(object sender, EventArgs e)
        {
            foreach (ProcessInfo process in objects)
            {
                if (process.ID == 0)
                {
                    Process p = Process.Start(process.Path);                    
                    process.ID = p.Id;
                }
            }
        }

        private void TerminateAll(object sender, EventArgs e)
        {

        }
    }
}
