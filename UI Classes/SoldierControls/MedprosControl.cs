using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Soldiers.UI_Classes
{
    public partial class MedprosControl : UserControl
    {
        public MedprosControl()
        {
            InitializeComponent();
        }

        private void validate_MEDPROS(object sender, EventArgs e)
        {
            validate();
        }
        public void validate()
        {
            DateTime now = DateTime.Now;

            // Dental
            if ((dentalCbx.Text == "Class 1") && ((now - dentalDTP.Value).TotalDays < 365))
            {
                dentalLbl.BackColor = Color.Green;
            }
            else if ((dentalCbx.Text == "Class 3") || (dentalCbx.Text == "Class 4"))
                dentalLbl.BackColor = Color.Red;

            else if ((dentalCbx.Text == "Class 2") || ((now - dentalDTP.Value).TotalDays < 365))
            {
                dentalLbl.BackColor = Color.Gold;
            }
            else
                dentalLbl.BackColor = Color.Red;



            // Hearing
            if ((now - hearingDTP.Value).TotalDays < 365)
                hearLbl.BackColor = Color.Green;
            else
                hearLbl.BackColor = Color.Red;



            // PHA
            if ((now - phaDTP.Value).TotalDays < 365)
                phaLbl.BackColor = Color.Green;
            else
                phaLbl.BackColor = Color.Red;



            // Vision
            if ((now - visionDTP.Value).TotalDays < 365)
                visionLbl.BackColor = Color.Green;
            else
                visionLbl.BackColor = Color.Red;
        }
    }
}
