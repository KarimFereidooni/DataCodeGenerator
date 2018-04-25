namespace DataCodeGenerator.UI
{
    partial class GeneratorBase
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
            this.panel_top = new System.Windows.Forms.Panel();
            this.panel_top_inner = new System.Windows.Forms.Panel();
            this.txt_namespace = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_buttons = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox_options = new System.Windows.Forms.GroupBox();
            this.panel_options_inner = new System.Windows.Forms.Panel();
            this.panel_top.SuspendLayout();
            this.panel_top_inner.SuspendLayout();
            this.panel_buttons.SuspendLayout();
            this.groupBox_options.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.panel_top_inner);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(10, 10);
            this.panel_top.Name = "panel_top";
            this.panel_top.Padding = new System.Windows.Forms.Padding(5);
            this.panel_top.Size = new System.Drawing.Size(482, 73);
            this.panel_top.TabIndex = 0;
            // 
            // panel_top_inner
            // 
            this.panel_top_inner.Controls.Add(this.txt_namespace);
            this.panel_top_inner.Controls.Add(this.label1);
            this.panel_top_inner.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_top_inner.Location = new System.Drawing.Point(8, 5);
            this.panel_top_inner.Name = "panel_top_inner";
            this.panel_top_inner.Size = new System.Drawing.Size(469, 63);
            this.panel_top_inner.TabIndex = 0;
            // 
            // txt_namespace
            // 
            this.txt_namespace.FormattingEnabled = true;
            this.txt_namespace.Items.AddRange(new object[] {
            "ManagementSoftware.DataAccess",
            "ManagementSoftware.Model",
            "ManagementSoftware.DataClasses"});
            this.txt_namespace.Location = new System.Drawing.Point(6, 22);
            this.txt_namespace.Name = "txt_namespace";
            this.txt_namespace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_namespace.Size = new System.Drawing.Size(387, 21);
            this.txt_namespace.TabIndex = 6;
            this.txt_namespace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_namespace_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "NameSpace:";
            // 
            // panel_buttons
            // 
            this.panel_buttons.Controls.Add(this.btn_cancel);
            this.panel_buttons.Controls.Add(this.btn_ok);
            this.panel_buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_buttons.Location = new System.Drawing.Point(10, 343);
            this.panel_buttons.Name = "panel_buttons";
            this.panel_buttons.Padding = new System.Windows.Forms.Padding(3);
            this.panel_buttons.Size = new System.Drawing.Size(482, 29);
            this.panel_buttons.TabIndex = 2;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_cancel.Location = new System.Drawing.Point(3, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "انصراف";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_ok.Location = new System.Drawing.Point(404, 3);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "تایید";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // groupBox_options
            // 
            this.groupBox_options.Controls.Add(this.panel_options_inner);
            this.groupBox_options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_options.Location = new System.Drawing.Point(10, 83);
            this.groupBox_options.Name = "groupBox_options";
            this.groupBox_options.Size = new System.Drawing.Size(482, 260);
            this.groupBox_options.TabIndex = 1;
            this.groupBox_options.TabStop = false;
            // 
            // panel_options_inner
            // 
            this.panel_options_inner.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_options_inner.Location = new System.Drawing.Point(17, 17);
            this.panel_options_inner.Name = "panel_options_inner";
            this.panel_options_inner.Size = new System.Drawing.Size(462, 240);
            this.panel_options_inner.TabIndex = 0;
            // 
            // GeneratorBase
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(502, 372);
            this.Controls.Add(this.groupBox_options);
            this.Controls.Add(this.panel_buttons);
            this.Controls.Add(this.panel_top);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneratorBase";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تولید کد";
            this.Load += new System.EventHandler(this.GeneratorBase_Load);
            this.panel_top.ResumeLayout(false);
            this.panel_top_inner.ResumeLayout(false);
            this.panel_top_inner.PerformLayout();
            this.panel_buttons.ResumeLayout(false);
            this.groupBox_options.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel_top;
        protected System.Windows.Forms.Panel panel_top_inner;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Panel panel_buttons;
        protected System.Windows.Forms.Button btn_cancel;
        protected System.Windows.Forms.Button btn_ok;
        protected System.Windows.Forms.GroupBox groupBox_options;
        protected System.Windows.Forms.Panel panel_options_inner;
        protected System.Windows.Forms.ComboBox txt_namespace;

    }
}