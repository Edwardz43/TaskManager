using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            for (int i = 0; i < AppArray.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                string root = ConfigurationManager.AppSettings["AppPath"].ToString();
                string path =
                    sb.Append(root) // 記得修改路徑
                    .Append(AppArray[i])
                    .Append("\\")
                    .Append(AppArray[i])
                    .Append(".exe").ToString();
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

        private void TerminateProcess(object sender, EventArgs e)
        {
            ProcessInfo info = (ProcessInfo)listBox1.SelectedItem;
            if (info != null)
            {
                try
                {
                    Process p = Process.GetProcessById(info.ID);                    
                    info.ID = 0;
                    p.Kill();
                    MessageBox.Show(info.ID.ToString());
                    listBox1.Items.Remove(info);
                    info.ID = 0;
                    listBox2.ValueMember = null;
                    listBox2.DisplayMember = "Name";
                    listBox2.Items.Add(info);                   
                }
                catch
                {                    
                    MessageBox.Show("程序已終止");
                }                               
            }

        }

        /*private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue != null)
            {
                ProcessInfo current = (ProcessInfo)listBox1.SelectedValue;
                //MessageBox.Show(current.ID + ":" + current.Name);
            }
        }*/

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
                process.ID = 1;
                listBox1.Items.Add(process);               
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
