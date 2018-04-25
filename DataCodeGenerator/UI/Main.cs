using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataCodeGenerator.UI
{
    public partial class Main : Form
    {
        private Main()
        {
            InitializeComponent();
            cmbTableView.SelectedIndex = 2;
        }

        //public EnvDTE80.DTE2 ApplicationObject;
        //public EnvDTE.AddIn AddInInstance;

        private static Main _Instance;

        public static Main Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Main();
                if (_Instance.IsDisposed)
                    _Instance = new Main();
                return _Instance;
            }
        }

        //public static Main GetInstance(EnvDTE80.DTE2 ApplicationObject, EnvDTE.AddIn AddInInstance)
        //{
        //    if (_Instance == null)
        //        _Instance = new Main();
        //    if (_Instance.IsDisposed)
        //        _Instance = new Main();
        //    _Instance.ApplicationObject = ApplicationObject;
        //    _Instance.AddInInstance = AddInInstance;
        //    return _Instance;
        //}

        private void Main_Shown(object sender, EventArgs e)
        {
            ConnectToSql();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void ConnectToSql()
        {
            if (LoginForm.Instance.ShowDialog(this) == DialogResult.OK)
            {
                Database_List = LoginForm.Instance.databaseList;
                UserName = LoginForm.Instance.ConnectionStringBuilder.UserID;
                ServerName = LoginForm.Instance.ConnectionStringBuilder.InitialCatalog;
                Connected = LoginForm.Instance.connected;
            }
        }

        //----------------------
        private DataTable _TableList;

        public DataTable TableList
        {
            get
            {
                return _TableList;
            }
            set
            {
                _TableList = value;
                listView_table.Items.Clear();
                if (_TableList != null)
                {
                    foreach (DataRow r in _TableList.Select(null, "name"))
                    {
                        listView_table.Items.Add(r["name"].ToString(), r["name"].ToString(), 0);
                    }
                }
            }
        }

        //----------------------
        private DataTable _Database_List = new DataTable();

        private DataTable Database_List
        {
            set
            {
                _Database_List = value;
                TableList = null;
                listView_database.Items.Clear();
                lbl_status.Text = "";
                if (_Database_List != null)
                {
                    foreach (DataRow r in _Database_List.Rows)
                    {
                        listView_database.Items.Add(r["name"].ToString(), r["name"].ToString(), 0);
                    }
                    lbl_status.Text = "تعداد دیتابیس ها = " + _Database_List.Rows.Count.ToString();
                }
            }
            get
            {
                return _Database_List;
            }
        }

        //----------------------
        private string _UserName = "";

        private string UserName
        {
            set
            {
                _UserName = value;
            }
            get
            {
                return _UserName;
            }
        }

        //----------------------
        private string _ServerName = "";

        private string ServerName
        {
            set
            {
                _ServerName = value;
            }
            get
            {
                return _ServerName;
            }
        }

        //----------------------
        private bool _Connected;

        private bool Connected
        {
            set
            {
                _Connected = value;
                if (value == true)
                {
                    lbl_title.ForeColor = Color.Green;
                    lbl_title.Text = "ارتباط برقرار است";
                    lbl_title.Text = ServerName + "  -  " + UserName;
                }
                else
                {
                    listView_database.Items.Clear();
                    Database_List = new DataTable();
                    lbl_title.ForeColor = Color.Red;
                    lbl_title.Text = "ارتباط برقرار نیست";
                }
            }
            get
            {
                return _Connected;
            }
        }

        private void menu_connect_Click(object sender, EventArgs e)
        {
            ConnectToSql();
        }

        //----------------------
        private void toolStripButton_dis_Click(object sender, EventArgs e)
        {
            if (!Connected)
            {
                MessageBox.Show("اتصال برقرار نیست");
                return;
            }
            Database_List = null;
            Connected = false;
            DataAccess.Instance = null;
        }

        //----------------------
        private void Refresh_data()
        {
            if (!Connected)
            {
                MessageBox.Show("اتصال برقرار نیست");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            Database_List = DataAccess.Instance.GetData("SELECT * FROM master.sys.databases");
            this.Cursor = Cursors.Default;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void listView_database_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_database.SelectedIndices.Count == 0)
            {
                TableList = null;
            }
            else
            {
                try
                {
                    DataAccess.Instance.Connection.Open();
                    DataAccess.Instance.Connection.ChangeDatabase(listView_database.SelectedItems[0].Name);
                    if (cmbTableView.SelectedIndex == 0)
                        TableList = DataAccess.Instance.GetData("SELECT [name] FROM [sys].[tables]");
                    else if (cmbTableView.SelectedIndex == 1)
                        TableList = DataAccess.Instance.GetData("SELECT [name] FROM [sys].[views]");
                    else if (cmbTableView.SelectedIndex == 2)
                        TableList = DataAccess.Instance.GetData("(SELECT [name] FROM [sys].[tables]) UNION (SELECT [name] FROM [sys].[views])");
                }
                finally
                {
                    DataAccess.Instance.Connection.Close();
                }
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (!Connected)
            {
                MessageBox.Show("اتصال برقرار نیست");
                return;
            }
            if (listView_database.SelectedItems.Count == 0)
            {
                MessageBox.Show("هیچ دیتابیسی انتخاب نشده است");
                return;
            }
            if (listView_table.SelectedItems.Count == 0)
            {
                MessageBox.Show("هیچ جدولی انتخاب نشده است");
                return;
            }
            List<string> Tables = new List<string>();
            foreach (ListViewItem item in listView_table.SelectedItems)
            {
                Tables.Add(item.Name);
            }
            UI.ClassGenerator.GetInstance(listView_database.SelectedItems[0].Name, Tables).ShowDialog(this);
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                listView_table.Select();
                foreach (ListViewItem item in listView_table.Items)
                {
                    item.Selected = true;
                }
            }
        }

        private void toolStripButton_about_Click(object sender, EventArgs e)
        {
            using (AboutBox about = new AboutBox())
            {
                about.ShowDialog(this);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView_table.SelectedItems.Count == 0)
                e.Cancel = true;
        }

        private void GenerateCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvokeOnClick(btn_class, EventArgs.Empty);
        }

        private void btn_TableAdapter_Click(object sender, EventArgs e)
        {
            if (!Connected)
            {
                MessageBox.Show("اتصال برقرار نیست");
                return;
            }
            if (listView_database.SelectedItems.Count == 0)
            {
                MessageBox.Show("هیچ دیتابیسی انتخاب نشده است");
                return;
            }
            if (listView_table.SelectedItems.Count == 0)
            {
                MessageBox.Show("هیچ جدولی انتخاب نشده است");
                return;
            }
            List<string> Tables = new List<string>();
            foreach (ListViewItem item in listView_table.SelectedItems)
            {
                Tables.Add(item.Name);
            }
            UI.TableAdapterGenerator.GetInstance(listView_database.SelectedItems[0].Name, Tables).ShowDialog(this);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTableView_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView_database_SelectedIndexChanged(sender, e);
        }
    }
}