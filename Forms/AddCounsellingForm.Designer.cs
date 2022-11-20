namespace My_Soldiers.Forms
{
    partial class AddCounsellingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCounsellingForm));
            this.okBtn = new System.Windows.Forms.Button();
            this.dragDropBox = new System.Windows.Forms.ListBox();
            this.titleTbx = new System.Windows.Forms.TextBox();
            this.dateDTP = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(409, 113);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // dragDropBox
            // 
            this.dragDropBox.AllowDrop = true;
            this.dragDropBox.FormattingEnabled = true;
            this.dragDropBox.Location = new System.Drawing.Point(51, 59);
            this.dragDropBox.Name = "dragDropBox";
            this.dragDropBox.Size = new System.Drawing.Size(433, 43);
            this.dragDropBox.TabIndex = 2;
            this.dragDropBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragDropBox_DragDrop);
            this.dragDropBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragDropBox_DragEnter);
            // 
            // titleTbx
            // 
            this.titleTbx.Location = new System.Drawing.Point(51, 6);
            this.titleTbx.Name = "titleTbx";
            this.titleTbx.Size = new System.Drawing.Size(433, 20);
            this.titleTbx.TabIndex = 3;
            // 
            // dateDTP
            // 
            this.dateDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDTP.Location = new System.Drawing.Point(51, 33);
            this.dateDTP.Name = "dateDTP";
            this.dateDTP.Size = new System.Drawing.Size(89, 20);
            this.dateDTP.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Date: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Title: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "File: ";
            // 
            // AddCounsellingForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 148);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateDTP);
            this.Controls.Add(this.titleTbx);
            this.Controls.Add(this.dragDropBox);
            this.Controls.Add(this.okBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddCounsellingForm";
            this.Text = "Add Document File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListBox dragDropBox;
        public System.Windows.Forms.TextBox titleTbx;
        public System.Windows.Forms.DateTimePicker dateDTP;
    }
}