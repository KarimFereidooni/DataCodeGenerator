namespace DataCodeGenerator.UI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip_main = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDown_connect = new System.Windows.Forms.ToolStripDropDownButton();
            this.menu_connect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_dis = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbTableView = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_about = new System.Windows.Forms.ToolStripButton();
            this.listView_database = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_database = new System.Windows.Forms.ImageList(this.components);
            this.listView_table = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GenerateCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList_table = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_TableAdapter = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_class = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_line = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.toolStrip_main.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_main
            // 
            this.toolStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDown_connect,
            this.toolStripButton_dis,
            this.toolStripSeparator2,
            this.cmbTableView,
            this.toolStripSeparator1,
            this.toolStripButton_about});
            this.toolStrip_main.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_main.Name = "toolStrip_main";
            this.toolStrip_main.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip_main.Size = new System.Drawing.Size(784, 25);
            this.toolStrip_main.TabIndex = 0;
            this.toolStrip_main.Text = "toolStrip2";
            // 
            // toolStripDropDown_connect
            // 
            this.toolStripDropDown_connect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_connect});
            this.toolStripDropDown_connect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDown_connect.Name = "toolStripDropDown_connect";
            this.toolStripDropDown_connect.Size = new System.Drawing.Size(75, 22);
            this.toolStripDropDown_connect.Text = "اتصال به ...";
            this.toolStripDropDown_connect.ToolTipText = "اتصال به ...";
            // 
            // menu_connect
            // 
            this.menu_connect.Name = "menu_connect";
            this.menu_connect.Size = new System.Drawing.Size(139, 22);
            this.menu_connect.Text = "SQL Server...";
            this.menu_connect.Click += new System.EventHandler(this.menu_connect_Click);
            // 
            // toolStripButton_dis
            // 
            this.toolStripButton_dis.Image = global::DataCodeGenerator.Properties.Resources.delete;
            this.toolStripButton_dis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_dis.Name = "toolStripButton_dis";
            this.toolStripButton_dis.Size = new System.Drawing.Size(83, 22);
            this.toolStripButton_dis.Text = "قطع اتصال";
            this.toolStripButton_dis.Click += new System.EventHandler(this.toolStripButton_dis_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cmbTableView
            // 
            this.cmbTableView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTableView.Items.AddRange(new object[] {
            "Table",
            "View",
            "Table & View"});
            this.cmbTableView.Name = "cmbTableView";
            this.cmbTableView.Size = new System.Drawing.Size(121, 25);
            this.cmbTableView.SelectedIndexChanged += new System.EventHandler(this.cmbTableView_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_about
            // 
            this.toolStripButton_about.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_about.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_about.Image")));
            this.toolStripButton_about.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_about.Name = "toolStripButton_about";
            this.toolStripButton_about.Size = new System.Drawing.Size(48, 22);
            this.toolStripButton_about.Text = "درباره...";
            this.toolStripButton_about.Click += new System.EventHandler(this.toolStripButton_about_Click);
            // 
            // listView_database
            // 
            this.listView_database.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.listView_database.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_database.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView_database.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_database.HideSelection = false;
            this.listView_database.LargeImageList = this.imageList_database;
            this.listView_database.Location = new System.Drawing.Point(0, 0);
            this.listView_database.MultiSelect = false;
            this.listView_database.Name = "listView_database";
            this.listView_database.RightToLeftLayout = true;
            this.listView_database.Size = new System.Drawing.Size(253, 383);
            this.listView_database.SmallImageList = this.imageList_database;
            this.listView_database.StateImageList = this.imageList_database;
            this.listView_database.TabIndex = 0;
            this.listView_database.UseCompatibleStateImageBehavior = false;
            this.listView_database.View = System.Windows.Forms.View.Details;
            this.listView_database.SelectedIndexChanged += new System.EventHandler(this.listView_database_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "دیتابیس ها";
            this.columnHeader1.Width = 332;
            // 
            // imageList_database
            // 
            this.imageList_database.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_database.ImageStream")));
            this.imageList_database.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_database.Images.SetKeyName(0, "database.png");
            // 
            // listView_table
            // 
            this.listView_table.BackColor = System.Drawing.Color.Beige;
            this.listView_table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_table.ContextMenuStrip = this.contextMenuStrip1;
            this.listView_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_table.HideSelection = false;
            this.listView_table.LargeImageList = this.imageList_table;
            this.listView_table.Location = new System.Drawing.Point(0, 0);
            this.listView_table.Name = "listView_table";
            this.listView_table.RightToLeftLayout = true;
            this.listView_table.Size = new System.Drawing.Size(527, 383);
            this.listView_table.SmallImageList = this.imageList_table;
            this.listView_table.TabIndex = 0;
            this.listView_table.UseCompatibleStateImageBehavior = false;
            this.listView_table.View = System.Windows.Forms.View.List;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GenerateCodeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // GenerateCodeToolStripMenuItem
            // 
            this.GenerateCodeToolStripMenuItem.Name = "GenerateCodeToolStripMenuItem";
            this.GenerateCodeToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.GenerateCodeToolStripMenuItem.Text = "تولید کد";
            this.GenerateCodeToolStripMenuItem.Click += new System.EventHandler(this.GenerateCodeToolStripMenuItem_Click);
            // 
            // imageList_table
            // 
            this.imageList_table.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_table.ImageStream")));
            this.imageList_table.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_table.Images.SetKeyName(0, "table.gif");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_TableAdapter);
            this.panel1.Controls.Add(this.btn_exit);
            this.panel1.Controls.Add(this.btn_class);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 483);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(784, 29);
            this.panel1.TabIndex = 3;
            // 
            // btn_TableAdapter
            // 
            this.btn_TableAdapter.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_TableAdapter.Location = new System.Drawing.Point(523, 3);
            this.btn_TableAdapter.Name = "btn_TableAdapter";
            this.btn_TableAdapter.Size = new System.Drawing.Size(146, 23);
            this.btn_TableAdapter.TabIndex = 1;
            this.btn_TableAdapter.Text = "تولید TableAdapter ...";
            this.btn_TableAdapter.UseVisualStyleBackColor = true;
            this.btn_TableAdapter.Click += new System.EventHandler(this.btn_TableAdapter_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_exit.Location = new System.Drawing.Point(3, 3);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "خروج";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_class
            // 
            this.btn_class.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_class.Location = new System.Drawing.Point(669, 3);
            this.btn_class.Name = "btn_class";
            this.btn_class.Size = new System.Drawing.Size(112, 23);
            this.btn_class.TabIndex = 0;
            this.btn_class.Text = "تولید Class ...";
            this.btn_class.UseVisualStyleBackColor = true;
            this.btn_class.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 100);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView_database);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView_table);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(784, 383);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::DataCodeGenerator.Properties.Resources.Main_Title;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.lbl_line);
            this.panel2.Controls.Add(this.lbl_status);
            this.panel2.Controls.Add(this.lbl_title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 75);
            this.panel2.TabIndex = 1;
            // 
            // lbl_line
            // 
            this.lbl_line.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_line.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_line.Location = new System.Drawing.Point(0, 72);
            this.lbl_line.Name = "lbl_line";
            this.lbl_line.Size = new System.Drawing.Size(784, 2);
            this.lbl_line.TabIndex = 2;
            this.lbl_line.Visible = false;
            // 
            // lbl_status
            // 
            this.lbl_status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_status.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_status.Location = new System.Drawing.Point(0, 45);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(784, 27);
            this.lbl_status.TabIndex = 1;
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_title.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_title.Size = new System.Drawing.Size(784, 45);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "ارتباط برقرار نیست";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Main
            // 
            this.AcceptButton = this.btn_class;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_exit;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip_main);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تولید کد برای دیتابیس";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.toolStrip_main.ResumeLayout(false);
            this.toolStrip_main.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_main;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDown_connect;
        private System.Windows.Forms.ToolStripMenuItem menu_connect;
        private System.Windows.Forms.ToolStripButton toolStripButton_dis;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ListView listView_database;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label lbl_line;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView_table;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList_database;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList_table;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_class;
        private System.Windows.Forms.ToolStripButton toolStripButton_about;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GenerateCodeToolStripMenuItem;
        private System.Windows.Forms.Button btn_TableAdapter;
        private System.Windows.Forms.ToolStripComboBox cmbTableView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

