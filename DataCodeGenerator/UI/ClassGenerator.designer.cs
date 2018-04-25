namespace DataCodeGenerator.UI
{
    partial class ClassGenerator
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
            this.checkBox_to_upper = new System.Windows.Forms.CheckBox();
            this.checkBox_use_comment = new System.Windows.Forms.CheckBox();
            this.checkBox_create_property = new System.Windows.Forms.CheckBox();
            this.checkBox_partial = new System.Windows.Forms.CheckBox();
            this.chkDeleteS = new System.Windows.Forms.CheckBox();
            this.checkBoxAddIdentity = new System.Windows.Forms.CheckBox();
            this.checkBoxAddConstractor = new System.Windows.Forms.CheckBox();
            this.panel_top.SuspendLayout();
            this.panel_top_inner.SuspendLayout();
            this.panel_buttons.SuspendLayout();
            this.groupBox_options.SuspendLayout();
            this.panel_options_inner.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.TabIndex = 0;
            // 
            // panel_buttons
            // 
            this.panel_buttons.Location = new System.Drawing.Point(10, 307);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // groupBox_options
            // 
            this.groupBox_options.Size = new System.Drawing.Size(482, 224);
            // 
            // panel_options_inner
            // 
            this.panel_options_inner.Controls.Add(this.checkBoxAddConstractor);
            this.panel_options_inner.Controls.Add(this.checkBoxAddIdentity);
            this.panel_options_inner.Controls.Add(this.chkDeleteS);
            this.panel_options_inner.Controls.Add(this.checkBox_to_upper);
            this.panel_options_inner.Controls.Add(this.checkBox_use_comment);
            this.panel_options_inner.Controls.Add(this.checkBox_partial);
            this.panel_options_inner.Controls.Add(this.checkBox_create_property);
            this.panel_options_inner.Size = new System.Drawing.Size(462, 204);
            // 
            // txt_namespace
            // 
            this.txt_namespace.TabIndex = 1;
            // 
            // checkBox_to_upper
            // 
            this.checkBox_to_upper.AutoSize = true;
            this.checkBox_to_upper.Location = new System.Drawing.Point(199, 12);
            this.checkBox_to_upper.Name = "checkBox_to_upper";
            this.checkBox_to_upper.Size = new System.Drawing.Size(245, 17);
            this.checkBox_to_upper.TabIndex = 0;
            this.checkBox_to_upper.Text = "اولین حرف هر Member با حرف بزرگ شروع شود";
            this.checkBox_to_upper.UseVisualStyleBackColor = true;
            // 
            // checkBox_use_comment
            // 
            this.checkBox_use_comment.AutoSize = true;
            this.checkBox_use_comment.Location = new System.Drawing.Point(252, 35);
            this.checkBox_use_comment.Name = "checkBox_use_comment";
            this.checkBox_use_comment.Size = new System.Drawing.Size(192, 17);
            this.checkBox_use_comment.TabIndex = 1;
            this.checkBox_use_comment.Text = "استفاده از Comment برای جداسازی";
            this.checkBox_use_comment.UseVisualStyleBackColor = true;
            // 
            // checkBox_create_property
            // 
            this.checkBox_create_property.AutoSize = true;
            this.checkBox_create_property.Location = new System.Drawing.Point(290, 58);
            this.checkBox_create_property.Name = "checkBox_create_property";
            this.checkBox_create_property.Size = new System.Drawing.Size(154, 17);
            this.checkBox_create_property.TabIndex = 2;
            this.checkBox_create_property.Text = "تولید Property برای هر فیلد";
            this.checkBox_create_property.UseVisualStyleBackColor = true;
            // 
            // checkBox_partial
            // 
            this.checkBox_partial.AutoSize = true;
            this.checkBox_partial.Checked = true;
            this.checkBox_partial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_partial.Location = new System.Drawing.Point(335, 81);
            this.checkBox_partial.Name = "checkBox_partial";
            this.checkBox_partial.Size = new System.Drawing.Size(109, 17);
            this.checkBox_partial.TabIndex = 3;
            this.checkBox_partial.Text = "تولید کلاس Partial";
            this.checkBox_partial.UseVisualStyleBackColor = true;
            // 
            // chkDeleteS
            // 
            this.chkDeleteS.AutoSize = true;
            this.chkDeleteS.Checked = true;
            this.chkDeleteS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDeleteS.Location = new System.Drawing.Point(310, 104);
            this.chkDeleteS.Name = "chkDeleteS";
            this.chkDeleteS.Size = new System.Drawing.Size(134, 17);
            this.chkDeleteS.TabIndex = 4;
            this.chkDeleteS.Text = "حذف \'S\' از آخر نام جدول";
            this.chkDeleteS.UseVisualStyleBackColor = true;
            // 
            // checkBoxAddIdentity
            // 
            this.checkBoxAddIdentity.AutoSize = true;
            this.checkBoxAddIdentity.Checked = true;
            this.checkBoxAddIdentity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAddIdentity.Location = new System.Drawing.Point(222, 127);
            this.checkBoxAddIdentity.Name = "checkBoxAddIdentity";
            this.checkBoxAddIdentity.Size = new System.Drawing.Size(222, 17);
            this.checkBoxAddIdentity.TabIndex = 5;
            this.checkBoxAddIdentity.Text = "افزودن فیلدهای Identity به پارامترهای تابع";
            this.checkBoxAddIdentity.UseVisualStyleBackColor = true;
            // 
            // checkBoxAddConstractor
            // 
            this.checkBoxAddConstractor.AutoSize = true;
            this.checkBoxAddConstractor.Location = new System.Drawing.Point(352, 150);
            this.checkBoxAddConstractor.Name = "checkBoxAddConstractor";
            this.checkBoxAddConstractor.Size = new System.Drawing.Size(92, 17);
            this.checkBoxAddConstractor.TabIndex = 6;
            this.checkBoxAddConstractor.Text = "ساخت سازنده";
            this.checkBoxAddConstractor.UseVisualStyleBackColor = true;
            // 
            // ClassGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 336);
            this.Name = "ClassGenerator";
            this.Load += new System.EventHandler(this.Generator_Load);
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

        private System.Windows.Forms.CheckBox checkBox_to_upper;
        private System.Windows.Forms.CheckBox checkBox_use_comment;
        private System.Windows.Forms.CheckBox checkBox_create_property;
        private System.Windows.Forms.CheckBox checkBox_partial;
        private System.Windows.Forms.CheckBox chkDeleteS;
        private System.Windows.Forms.CheckBox checkBoxAddIdentity;
        private System.Windows.Forms.CheckBox checkBoxAddConstractor;
    }
}