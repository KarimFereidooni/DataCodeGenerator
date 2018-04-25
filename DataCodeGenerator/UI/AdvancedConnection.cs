using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataCodeGenerator.UI
{
    public partial class AdvancedConnection : Form
    {
        public AdvancedConnection(System.Data.SqlClient.SqlConnectionStringBuilder ConnectionStringBuilder)
        {
            InitializeComponent();
            this.ConnectionStringBuilder = ConnectionStringBuilder;
            propertyGrid1.SelectedObject = ConnectionStringBuilder;
        }

        System.Data.SqlClient.SqlConnectionStringBuilder _ConnectionStringBuilder;
        public System.Data.SqlClient.SqlConnectionStringBuilder ConnectionStringBuilder
        {
            get
            {
                return _ConnectionStringBuilder;
            }
            set
            {
                _ConnectionStringBuilder = value;
            }
        }

        private void AdvancedConnection_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveControl == btn_ok))
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
