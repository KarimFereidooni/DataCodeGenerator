namespace DataCodeGenerator.UI
{
    partial class ShowCode
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
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.panel_buttons = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel_buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.richTextBox.Location = new System.Drawing.Point(10, 10);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.richTextBox.Size = new System.Drawing.Size(770, 452);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // panel_buttons
            // 
            this.panel_buttons.Controls.Add(this.btnExit);
            this.panel_buttons.Controls.Add(this.btnCopy);
            this.panel_buttons.Controls.Add(this.btnSave);
            this.panel_buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_buttons.Location = new System.Drawing.Point(10, 462);
            this.panel_buttons.Name = "panel_buttons";
            this.panel_buttons.Padding = new System.Windows.Forms.Padding(3);
            this.panel_buttons.Size = new System.Drawing.Size(770, 29);
            this.panel_buttons.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Location = new System.Drawing.Point(511, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(73, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCopy.Location = new System.Drawing.Point(584, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(96, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "کپی در کلیپ بورد";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(680, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "ذخیره...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "C# Files|*.cs|All Files|*.*";
            // 
            // ShowCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(790, 491);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.panel_buttons);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "ShowCode";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "کد تولید شده";
            this.Load += new System.EventHandler(this.ShowCode_Load);
            this.panel_buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox;
        protected System.Windows.Forms.Panel panel_buttons;
        protected System.Windows.Forms.Button btnExit;
        protected System.Windows.Forms.Button btnCopy;
        protected System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}