namespace My_Soldiers.UI_Classes
{
    partial class MedprosControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dentalLbl = new System.Windows.Forms.Label();
            this.visionLbl = new System.Windows.Forms.Label();
            this.hearLbl = new System.Windows.Forms.Label();
            this.phaLbl = new System.Windows.Forms.Label();
            this.dentalDTP = new System.Windows.Forms.DateTimePicker();
            this.visionDTP = new System.Windows.Forms.DateTimePicker();
            this.hearingDTP = new System.Windows.Forms.DateTimePicker();
            this.phaDTP = new System.Windows.Forms.DateTimePicker();
            this.dentalCbx = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(283, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "MEDPROS";
            // 
            // dentalLbl
            // 
            this.dentalLbl.AutoSize = true;
            this.dentalLbl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dentalLbl.ForeColor = System.Drawing.Color.White;
            this.dentalLbl.Location = new System.Drawing.Point(103, 21);
            this.dentalLbl.Name = "dentalLbl";
            this.dentalLbl.Size = new System.Drawing.Size(38, 13);
            this.dentalLbl.TabIndex = 1;
            this.dentalLbl.Text = "Dental";
            // 
            // visionLbl
            // 
            this.visionLbl.AutoSize = true;
            this.visionLbl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.visionLbl.ForeColor = System.Drawing.Color.White;
            this.visionLbl.Location = new System.Drawing.Point(226, 21);
            this.visionLbl.Name = "visionLbl";
            this.visionLbl.Size = new System.Drawing.Size(35, 13);
            this.visionLbl.TabIndex = 2;
            this.visionLbl.Text = "Vision";
            // 
            // hearLbl
            // 
            this.hearLbl.AutoSize = true;
            this.hearLbl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.hearLbl.ForeColor = System.Drawing.Color.White;
            this.hearLbl.Location = new System.Drawing.Point(346, 21);
            this.hearLbl.Name = "hearLbl";
            this.hearLbl.Size = new System.Drawing.Size(44, 13);
            this.hearLbl.TabIndex = 3;
            this.hearLbl.Text = "Hearing";
            // 
            // phaLbl
            // 
            this.phaLbl.AutoSize = true;
            this.phaLbl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.phaLbl.ForeColor = System.Drawing.Color.White;
            this.phaLbl.Location = new System.Drawing.Point(475, 21);
            this.phaLbl.Name = "phaLbl";
            this.phaLbl.Size = new System.Drawing.Size(29, 13);
            this.phaLbl.TabIndex = 4;
            this.phaLbl.Text = "PHA";
            // 
            // dentalDTP
            // 
            this.dentalDTP.CustomFormat = "MM/dd/yyyy";
            this.dentalDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dentalDTP.Location = new System.Drawing.Point(82, 47);
            this.dentalDTP.Name = "dentalDTP";
            this.dentalDTP.Size = new System.Drawing.Size(85, 20);
            this.dentalDTP.TabIndex = 5;
            this.dentalDTP.Leave += new System.EventHandler(this.validate_MEDPROS);
            // 
            // visionDTP
            // 
            this.visionDTP.CustomFormat = "MM/dd/yyyy";
            this.visionDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.visionDTP.Location = new System.Drawing.Point(197, 47);
            this.visionDTP.Name = "visionDTP";
            this.visionDTP.Size = new System.Drawing.Size(85, 20);
            this.visionDTP.TabIndex = 7;
            this.visionDTP.Leave += new System.EventHandler(this.validate_MEDPROS);
            // 
            // hearingDTP
            // 
            this.hearingDTP.CustomFormat = "MM/dd/yyyy";
            this.hearingDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hearingDTP.Location = new System.Drawing.Point(326, 47);
            this.hearingDTP.Name = "hearingDTP";
            this.hearingDTP.Size = new System.Drawing.Size(85, 20);
            this.hearingDTP.TabIndex = 8;
            this.hearingDTP.Leave += new System.EventHandler(this.validate_MEDPROS);
            // 
            // phaDTP
            // 
            this.phaDTP.CustomFormat = "MM/dd/yyyy";
            this.phaDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.phaDTP.Location = new System.Drawing.Point(451, 47);
            this.phaDTP.Name = "phaDTP";
            this.phaDTP.Size = new System.Drawing.Size(85, 20);
            this.phaDTP.TabIndex = 9;
            this.phaDTP.Leave += new System.EventHandler(this.validate_MEDPROS);
            // 
            // dentalCbx
            // 
            this.dentalCbx.FormattingEnabled = true;
            this.dentalCbx.Items.AddRange(new object[] {
            "Class 1",
            "Class 2",
            "Class 3",
            "Class 4"});
            this.dentalCbx.Location = new System.Drawing.Point(82, 73);
            this.dentalCbx.Name = "dentalCbx";
            this.dentalCbx.Size = new System.Drawing.Size(85, 21);
            this.dentalCbx.TabIndex = 10;
            this.dentalCbx.Leave += new System.EventHandler(this.validate_MEDPROS);
            // 
            // MedprosControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.dentalCbx);
            this.Controls.Add(this.phaDTP);
            this.Controls.Add(this.hearingDTP);
            this.Controls.Add(this.visionDTP);
            this.Controls.Add(this.dentalDTP);
            this.Controls.Add(this.phaLbl);
            this.Controls.Add(this.hearLbl);
            this.Controls.Add(this.visionLbl);
            this.Controls.Add(this.dentalLbl);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MedprosControl";
            this.Size = new System.Drawing.Size(628, 97);
            this.Leave += new System.EventHandler(this.validate_MEDPROS);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label dentalLbl;
        public System.Windows.Forms.Label visionLbl;
        public System.Windows.Forms.Label hearLbl;
        public System.Windows.Forms.Label phaLbl;
        public System.Windows.Forms.DateTimePicker dentalDTP;
        public System.Windows.Forms.DateTimePicker visionDTP;
        public System.Windows.Forms.DateTimePicker hearingDTP;
        public System.Windows.Forms.DateTimePicker phaDTP;
        public System.Windows.Forms.ComboBox dentalCbx;
    }
}
