namespace DataCodeGenerator.UI
{
    partial class TableAdapterGenerator
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
            this.checkBox_openfile = new System.Windows.Forms.CheckBox();
            this.checkBox_partial = new System.Windows.Forms.CheckBox();
            this.checkBox_use_comment = new System.Windows.Forms.CheckBox();
            this.checkBox_to_upper = new System.Windows.Forms.CheckBox();
            this.panel_top.SuspendLayout();
            this.panel_top_inner.SuspendLayout();
            this.panel_buttons.SuspendLayout();
            this.groupBox_options.SuspendLayout();
            this.panel_options_inner.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Size = new System.Drawing.Size(478, 108);
            // 
            // panel_top_inner
            // 
            this.panel_top_inner.Location = new System.Drawing.Point(4, 5);
            // 
            // panel_buttons
            // 
            this.panel_buttons.Location = new System.Drawing.Point(10, 255);
            this.panel_buttons.Size = new System.Drawing.Size(478, 29);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(400, 3);
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // groupBox_options
            // 
            this.groupBox_options.Size = new System.Drawing.Size(478, 137);
            // 
            // panel_options_inner
            // 
            this.panel_options_inner.Controls.Add(this.checkBox_to_upper);
            this.panel_options_inner.Controls.Add(this.checkBox_use_comment);
            this.panel_options_inner.Controls.Add(this.checkBox_openfile);
            this.panel_options_inner.Controls.Add(this.checkBox_partial);
            this.panel_options_inner.Location = new System.Drawing.Point(13, 17);
            this.panel_options_inner.Size = new System.Drawing.Size(462, 117);
            // 
            // checkBox_openfile
            // 
            this.checkBox_openfile.AutoSize = true;
            this.checkBox_openfile.Checked = true;
            this.checkBox_openfile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_openfile.Location = new System.Drawing.Point(273, 83);
            this.checkBox_openfile.Name = "checkBox_openfile";
            this.checkBox_openfile.Size = new System.Drawing.Size(171, 17);
            this.checkBox_openfile.TabIndex = 6;
            this.checkBox_openfile.Text = "باز کردن فایل ذخیره شده در پایان";
            this.checkBox_openfile.UseVisualStyleBackColor = true;
            // 
            // checkBox_partial
            // 
            this.checkBox_partial.AutoSize = true;
            this.checkBox_partial.Checked = true;
            this.checkBox_partial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_partial.Location = new System.Drawing.Point(335, 37);
            this.checkBox_partial.Name = "checkBox_partial";
            this.checkBox_partial.Size = new System.Drawing.Size(109, 17);
            this.checkBox_partial.TabIndex = 5;
            this.checkBox_partial.Text = "تولید کلاس Partial";
            this.checkBox_partial.UseVisualStyleBackColor = true;
            // 
            // checkBox_use_comment
            // 
            this.checkBox_use_comment.AutoSize = true;
            this.checkBox_use_comment.Location = new System.Drawing.Point(252, 60);
            this.checkBox_use_comment.Name = "checkBox_use_comment";
            this.checkBox_use_comment.Size = new System.Drawing.Size(192, 17);
            this.checkBox_use_comment.TabIndex = 7;
            this.checkBox_use_comment.Text = "استفاده از Comment برای جداسازی";
            this.checkBox_use_comment.UseVisualStyleBackColor = true;
            // 
            // checkBox_to_upper
            // 
            this.checkBox_to_upper.AutoSize = true;
            this.checkBox_to_upper.Checked = true;
            this.checkBox_to_upper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_to_upper.Location = new System.Drawing.Point(199, 14);
            this.checkBox_to_upper.Name = "checkBox_to_upper";
            this.checkBox_to_upper.Size = new System.Drawing.Size(245, 17);
            this.checkBox_to_upper.TabIndex = 8;
            this.checkBox_to_upper.Text = "اولین حرف هر Member با حرف بزرگ شروع شود";
            this.checkBox_to_upper.UseVisualStyleBackColor = true;
            // 
            // TableAdapterGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(498, 294);
            this.Name = "TableAdapterGenerator";
            this.Load += new System.EventHandler(this.TableAdapterGenerator_Load);
            this.panel_top.ResumeLayout(false);
            this.panel_top_inner.ResumeLayout(false);
            this.panel_top_inner.PerformLayout();
            this.panel_buttons.ResumeLayout(false);
            this.groupBox_options.ResumeLayout(false);
            this.panel_options_inner.ResumeLayout(false);
            this.panel_options_inner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_openfile;
        private System.Windows.Forms.CheckBox checkBox_partial;
        private System.Windows.Forms.CheckBox checkBox_use_comment;
        private System.Windows.Forms.CheckBox checkBox_to_upper;
    }
}
