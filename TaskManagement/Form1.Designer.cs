namespace TaskManagement
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonTerminate = new System.Windows.Forms.Button();
            this.buttonInvoke = new System.Windows.Forms.Button();
            this.buttonInvokeAll = new System.Windows.Forms.Button();
            this.buttonTerminateAll = new System.Windows.Forms.Button();
            this.listBoxRunning = new System.Windows.Forms.ListBox();
            this.listBoxClose = new System.Windows.Forms.ListBox();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TitalbarLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NarrowLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTerminate
            // 
            this.buttonTerminate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(99)))));
            this.buttonTerminate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTerminate.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonTerminate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.buttonTerminate.Location = new System.Drawing.Point(580, 140);
            this.buttonTerminate.Name = "button2";
            this.buttonTerminate.Size = new System.Drawing.Size(156, 68);
            this.buttonTerminate.TabIndex = 3;
            this.buttonTerminate.Text = "終止程序";
            this.buttonTerminate.UseVisualStyleBackColor = false;
            this.buttonTerminate.Click += new System.EventHandler(this.TerminateProcess);
            // 
            // buttonInvoke
            // 
            this.buttonInvoke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(99)))));
            this.buttonInvoke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInvoke.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonInvoke.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(203)))), ((int)(((byte)(158)))));
            this.buttonInvoke.Location = new System.Drawing.Point(580, 66);
            this.buttonInvoke.Name = "button3";
            this.buttonInvoke.Size = new System.Drawing.Size(156, 68);
            this.buttonInvoke.TabIndex = 4;
            this.buttonInvoke.Text = "開啟程序";
            this.buttonInvoke.UseVisualStyleBackColor = false;
            this.buttonInvoke.Click += new System.EventHandler(this.InvokeBtn);
            // 
            // buttonInvokeAll
            // 
            this.buttonInvokeAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(99)))));
            this.buttonInvokeAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInvokeAll.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonInvokeAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(203)))), ((int)(((byte)(158)))));
            this.buttonInvokeAll.Location = new System.Drawing.Point(742, 66);
            this.buttonInvokeAll.Name = "button1";
            this.buttonInvokeAll.Size = new System.Drawing.Size(156, 68);
            this.buttonInvokeAll.TabIndex = 6;
            this.buttonInvokeAll.Text = "全部開啟";
            this.buttonInvokeAll.UseVisualStyleBackColor = false;
            this.buttonInvokeAll.Click += new System.EventHandler(this.InvokeAll);
            // 
            // buttonTerminateAll
            // 
            this.buttonTerminateAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(99)))));
            this.buttonTerminateAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTerminateAll.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonTerminateAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.buttonTerminateAll.Location = new System.Drawing.Point(742, 140);
            this.buttonTerminateAll.Name = "button4";
            this.buttonTerminateAll.Size = new System.Drawing.Size(156, 68);
            this.buttonTerminateAll.TabIndex = 7;
            this.buttonTerminateAll.Text = "全部關閉";
            this.buttonTerminateAll.UseVisualStyleBackColor = false;
            this.buttonTerminateAll.Click += new System.EventHandler(this.TerminateAll);
            // 
            // listBoxRunning
            // 
            this.listBoxRunning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(99)))));
            this.listBoxRunning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxRunning.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBoxRunning.ForeColor = System.Drawing.Color.White;
            this.listBoxRunning.FormattingEnabled = true;
            this.listBoxRunning.ItemHeight = 21;
            this.listBoxRunning.Location = new System.Drawing.Point(5, 31);
            this.listBoxRunning.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxRunning.Name = "listBoxRunning";
            this.listBoxRunning.Size = new System.Drawing.Size(268, 357);
            this.listBoxRunning.Sorted = true;
            this.listBoxRunning.TabIndex = 8;
            this.listBoxRunning.DoubleClick += new System.EventHandler(this.SetConsoleForeground);
            // 
            // listBoxClose
            // 
            this.listBoxClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(99)))));
            this.listBoxClose.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxClose.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBoxClose.ForeColor = System.Drawing.Color.White;
            this.listBoxClose.FormattingEnabled = true;
            this.listBoxClose.ItemHeight = 21;
            this.listBoxClose.Location = new System.Drawing.Point(5, 31);
            this.listBoxClose.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxClose.Name = "listBoxClose";
            this.listBoxClose.Size = new System.Drawing.Size(268, 357);
            this.listBoxClose.Sorted = true;
            this.listBoxClose.TabIndex = 9;
            // 
            // CloseLabel
            // 
            this.CloseLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.CloseLabel.Location = new System.Drawing.Point(882, 4);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(39, 32);
            this.CloseLabel.TabIndex = 12;
            this.CloseLabel.Text = "X";
            this.CloseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxRunning);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(203)))), ((int)(((byte)(158)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 397);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Running:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxClose);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.groupBox2.Location = new System.Drawing.Point(296, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 397);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Closed:";
            // 
            // TitalbarLabel
            // 
            this.TitalbarLabel.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitalbarLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(203)))), ((int)(((byte)(158)))));
            this.TitalbarLabel.Location = new System.Drawing.Point(0, 4);
            this.TitalbarLabel.Name = "TitalbarLabel";
            this.TitalbarLabel.Size = new System.Drawing.Size(831, 32);
            this.TitalbarLabel.TabIndex = 15;
            this.TitalbarLabel.Text = "程序管理工具";
            this.TitalbarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TitalbarLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitalbarLabel_MouseDown);
            this.TitalbarLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitalbarLabel_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(692, 286);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(32)))), ((int)(((byte)(52)))));
            this.panel1.Controls.Add(this.NarrowLabel);
            this.panel1.Controls.Add(this.TitalbarLabel);
            this.panel1.Controls.Add(this.CloseLabel);
            this.panel1.Location = new System.Drawing.Point(-4, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 36);
            this.panel1.TabIndex = 17;
            // 
            // NarrowLabel
            // 
            this.NarrowLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NarrowLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NarrowLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NarrowLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.NarrowLabel.Location = new System.Drawing.Point(837, 4);
            this.NarrowLabel.Name = "NarrowLabel";
            this.NarrowLabel.Size = new System.Drawing.Size(39, 32);
            this.NarrowLabel.TabIndex = 16;
            this.NarrowLabel.Text = "_";
            this.NarrowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NarrowLabel.Click += new System.EventHandler(this.NarrowLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(915, 480);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonTerminateAll);
            this.Controls.Add(this.buttonInvokeAll);
            this.Controls.Add(this.buttonInvoke);
            this.Controls.Add(this.buttonTerminate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "TaskManager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        }
        #endregion
        private System.Windows.Forms.Button buttonTerminate;
        private System.Windows.Forms.Button buttonInvoke;
        private System.Windows.Forms.Button buttonInvokeAll;
        private System.Windows.Forms.Button buttonTerminateAll;
        private System.Windows.Forms.ListBox listBoxRunning;
        private System.Windows.Forms.ListBox listBoxClose;
        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label TitalbarLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label NarrowLabel;
    }
}

