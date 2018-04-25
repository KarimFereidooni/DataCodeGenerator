namespace DataCodeGenerator.UI
{
    partial class AdvancedConnection
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel_button = new System.Windows.Forms.Panel();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_button.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.propertyGrid1.Size = new System.Drawing.Size(433, 441);
            this.propertyGrid1.TabIndex = 0;
            // 
            // panel_button
            // 
            this.panel_button.Controls.Add(this.btn_ok);
            this.panel_button.Controls.Add(this.label5);
            this.panel_button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_button.Location = new System.Drawing.Point(0, 409);
            this.panel_button.Name = "panel_button";
            this.panel_button.Padding = new System.Windows.Forms.Padding(3);
            this.panel_button.Size = new System.Drawing.Size(433, 32);
            this.panel_button.TabIndex = 1;
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_ok.Location = new System.Drawing.Point(331, 5);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(99, 24);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "خروج";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(427, 2);
            this.label5.TabIndex = 8;
            // 
            // AdvancedConnection
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_ok;
            this.ClientSize = new System.Drawing.Size(433, 441);
            this.Controls.Add(this.panel_button);
            this.Controls.Add(this.propertyGrid1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedConnection";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات پیشرفته";
            this.Load += new System.EventHandler(this.AdvancedConnection_Load);
            this.panel_button.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel_button;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label5;
    }
}