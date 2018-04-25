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
    public partial class ShowCode : Form
    {
        public ShowCode(string text)
        {
            InitializeComponent();
            richTextBox.Text = text;
        }

        //private static ShowCode _Instance;
        //public static ShowCode GetInstance(string text)
        //{
        //    if (_Instance == null)
        //        _Instance = new ShowCode();
        //    if (_Instance.IsDisposed)
        //        _Instance = new ShowCode();
        //    _Instance.richTextBox.Text = text;
        //    return _Instance;
        //}

        private void ShowCode_Load(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox.Text);
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, richTextBox.Text);
                this.Close();
            }
        }
    }
}
