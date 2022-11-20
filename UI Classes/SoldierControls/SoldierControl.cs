using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using My_Soldiers.Forms;
using My_Soldiers.Backend_Classes;
using System.Xml;
using System.Windows.Forms.DataVisualization.Charting;

namespace My_Soldiers
{
    public partial class SoldierControl : TabPage
    {
        bool adminBoxLocked = false;
        public SoldierControl()
        {
            InitializeComponent();
            rankCbx.Items.AddRange(StaticLibrary.RANK_ABRV_LIST);
            delSoldierItem.Click += DelSoldierItem_Click1;
            expXMLItem.Click += ExpXMLItem_Click;
        }

        private void ExpXMLItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Soldier..";
            saveFileDialog.Filter = "DATA Files|*.data";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.CheckFileExists = true;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ShowDialog();
            String fileName;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;



                SoldierControl soldier = this;



                XmlTextWriter tw = new XmlTextWriter(fileName, null);
                tw.WriteStartDocument();
                tw.WriteStartElement(fileName);



                tw.WriteStartElement(StaticLibrary.XML_SOLDIER);
                // SINGLE STRINGS
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_FNAME, soldier.fNameBx.Text);
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_MNAME, soldier.mNameBx.Text);
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_LNAME, soldier.lNameTbx.Text);
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_RANK, soldier.rankCbx.Text);
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_POINTS, soldier.pointsTbx.Text);
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_DEPENDENTS, soldier.dependTbx.Text);
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_ADDRESSES, soldier.addressesTbx.Text);
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_VEHICLES, soldier.vehicleTbx.Text);
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_NOTE, soldier.noteTbx.Text);
                // SINGLE DATES
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_RANK_DATE, soldier.dorDTP.Value.ToString());
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_FLAG_DATE, soldier.flaggedDTP.Value.ToString());
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_BAR_DATE, soldier.barDTP.Value.ToString());
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_BASD, soldier.basdDTP.Value.ToString());
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_PEBD, soldier.pebdDTP.Value.ToString());
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_BESD, soldier.besdDTP.Value.ToString());
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_ETS, soldier.etsDTP.Value.ToString());
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_DIEMS, soldier.diemsDTP.Value.ToString());
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_AGCSM, soldier.agcsmDTP.Value.ToString());
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_PCS, soldier.pcsDTP.Value.ToString());
                // SINGLE BOOLS
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_PROMOTABLE, soldier.promotableChk.Checked.ToString());
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_BAR, soldier.barChk.Checked.ToString());
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_FLAG, soldier.flaggedChk.Checked.ToString());
                //MEDPROS-Dental
                tw.WriteStartElement(StaticLibrary.XML_SOLDIER_DENTAL);
                tw.WriteAttributeString(StaticLibrary.XML_SOLDIER_DENTAL_CLASS, soldier.medprosControl1.dentalCbx.Text);
                tw.WriteString(soldier.medprosControl1.dentalDTP.Value.ToString());
                tw.WriteEndElement();
                //MEDPRO-Vision
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_VISION, soldier.medprosControl1.visionDTP.Value.ToString());
                //MEDPROS-Hearing
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_HEARING, soldier.medprosControl1.hearingDTP.Value.ToString());
                //MEDPROS-PHA
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_PHA, soldier.medprosControl1.phaDTP.Value.ToString());
                // APFT
                foreach (DataGridViewRow row in soldier.apftDGV.Rows)
                {
                    tw.WriteStartElement(StaticLibrary.XML_SOLDIER_APFT);

                    if (row.Cells[0].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_APFT_DATE, row.Cells[0].Value.ToString());
                    if (row.Cells[1].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_APFT_PUSH, row.Cells[1].Value.ToString());
                    if (row.Cells[2].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_APFT_SIT, row.Cells[2].Value.ToString());
                    if (row.Cells[3].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_APFT_TIME, row.Cells[3].Value.ToString());
                    if (row.Cells[4].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_APFT_ALTERNATE, row.Cells[4].Value.ToString());
                    if (row.Cells[5].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_APFT_SCORE, row.Cells[5].Value.ToString());

                    tw.WriteEndElement();
                }
                // AWARD
                foreach (DataGridViewRow row in soldier.awardsDGV.Rows)
                {
                    tw.WriteStartElement(StaticLibrary.XML_SOLDIER_APFT);

                    if (row.Cells[0].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_AWARD_NAME, row.Cells[0].Value.ToString());
                    if (row.Cells[1].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_AWARD_DATE, row.Cells[1].Value.ToString());

                    tw.WriteEndElement();
                }
                // WEAPON
                foreach (DataGridViewRow row in soldier.weaponsDGV.Rows)
                {
                    tw.WriteStartElement(StaticLibrary.XML_SOLDIER_WEAPON);

                    if (row.Cells[0].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_WEAPON_SYSTEM, row.Cells[0].Value.ToString());
                    if (row.Cells[1].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_WEAPON_SCORE, row.Cells[1].Value.ToString());
                    if (row.Cells[2].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_WEAPON_DATE, row.Cells[2].Value.ToString());

                    tw.WriteEndElement();
                }
                // ABCP
                foreach (DataGridViewRow row in soldier.abcpDGV.Rows)
                {
                    tw.WriteStartElement(StaticLibrary.XML_SOLDIER_ABCP);

                    if (row.Cells[0].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_ABCP_DATE, row.Cells[0].Value.ToString());
                    if (row.Cells[1].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_ABCP_PERCENT, row.Cells[1].Value.ToString());
                    if (row.Cells[2].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_ABCP_MAX, row.Cells[2].Value.ToString());

                    tw.WriteEndElement();
                }
                // MILED
                foreach (DataGridViewRow row in soldier.milEdDGV.Rows)
                {
                    tw.WriteStartElement(StaticLibrary.XML_SOLDIER_MILED);

                    if (row.Cells[0].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_MILED_COURSE, row.Cells[0].Value.ToString());
                    if (row.Cells[1].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_MILED_DATE, row.Cells[1].Value.ToString());
                    if (row.Cells[2].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_MILED_ANNUAL, row.Cells[2].Value.ToString());

                    tw.WriteEndElement();
                }
                // CIVED
                foreach (DataGridViewRow row in soldier.civEdDGV.Rows)
                {
                    tw.WriteStartElement(StaticLibrary.XML_SOLDIER_CIVED);

                    if (row.Cells[0].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_CIVED_INSTITUTION, row.Cells[0].Value.ToString());
                    if (row.Cells[1].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_CIVED_START, row.Cells[1].Value.ToString());
                    if (row.Cells[2].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_CIVED_END, row.Cells[2].Value.ToString());
                    if (row.Cells[3].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_CIVED_CREDITS, row.Cells[3].Value.ToString());
                    if (row.Cells[4].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_CIVED_GRADUATE, row.Cells[4].Value.ToString());

                    tw.WriteEndElement();
                }
                // CERTIFICATIONS
                foreach (DataGridViewRow row in soldier.certificationsDGV.Rows)
                {
                    tw.WriteStartElement(StaticLibrary.XML_SOLDIER_CERT);

                    if (row.Cells[0].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_CERT_NAME, row.Cells[0].Value.ToString());
                    if (row.Cells[1].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_CERT_DATE, row.Cells[1].Value.ToString());
                    if (row.Cells[2].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_CERT_RENEW, row.Cells[2].Value.ToString());

                    tw.WriteEndElement();
                }
                // COUNSELLINGS
                foreach (DataGridViewRow row in soldier.counsellingDGV.Rows)
                {
                    tw.WriteStartElement(StaticLibrary.XML_SOLDIER_COUNSELLING);

                    if (row.Cells[0].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_COUNSELLING_DATE, row.Cells[0].Value.ToString());
                    if (row.Cells[1].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_COUNSELLING_TITLE, row.Cells[1].Value.ToString());
                    if (row.Cells[2].Value != null)
                        tw.WriteElementString(StaticLibrary.XML_SOLDIER_COUNSELLING_FILE, row.Cells[2].Value.ToString());

                    tw.WriteEndElement();
                }


                tw.WriteEndElement();



                tw.WriteEndElement();
                tw.Close();
            }
            
        }

        private void DelSoldierItem_Click1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void flaggedChk_Click(object sender, EventArgs e)
        {
            if (flaggedChk.Checked) 
            { 
                flaggedDTP.Visible = true;
                promotableChk.Checked = false; 
            }
            else
                flaggedDTP.Visible = false;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (barChk.Checked)
            {
                barDTP.Visible = true;
                promotableChk.Checked = false;
            }
            else
                barDTP.Visible = false;

        }

        private void promotableChk_CheckStateChanged(object sender, EventArgs e)
        {
            if (barChk.Checked | flaggedChk.Checked)
                promotableChk.Checked = false;
        }

        
       

        private void button1_Click(object sender, EventArgs e)
        {
            toggleAdminBoxLock();
        }
        private void toggleAdminBoxLock()
        {
            if (!adminBoxLocked)
            {
                foreach (Control c in adminBox.Controls)
                {
                    c.Enabled = false;
                }
                adminLockBTN.Enabled = true;
                adminBoxLocked = true;
            }
            else
            {
                foreach (Control c in adminBox.Controls)
                {
                    c.Enabled = true;
                }
                adminBoxLocked = false;
            }
        }
        public void toggleAdminBoxLock(bool test)
        {
            if (test)
            {
                foreach (Control c in adminBox.Controls)
                {
                    c.Enabled = false;
                }
                adminLockBTN.Enabled = true;
                adminBoxLocked = true;
            }
            else
            {
                foreach (Control c in adminBox.Controls)
                {
                    c.Enabled = true;
                }
                adminBoxLocked = false;
            }
        }
       


        private void counsellingDGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (counsellingDGV.CurrentRow.Cells[2].Value != null)
                System.Diagnostics.Process.Start(counsellingDGV.CurrentRow.Cells[2].Value.ToString());
        }

        private void addCounsellingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCounsellingForm counsellingForm = new AddCounsellingForm();

            if (counsellingForm.ShowDialog() == DialogResult.OK)
                this.counsellingDGV.Rows.Add(counsellingForm.dateDTP.Value.ToString(), counsellingForm.titleTbx.Text, counsellingForm.dragDropBox.Items[0].ToString());

            else { 
                try { 
                this.counsellingDGV.Rows.Add(counsellingForm.dateDTP.Value.ToString(), counsellingForm.titleTbx.Text, counsellingForm.dragDropBox.Items[0].ToString());
                }
                catch { }
        }
        }

        public void validateTab()
        {
            if(promotableChk.Checked)
                this.Text = rankCbx.Text +  "(P) " + lNameTbx.Text + ", " + fNameBx.Text;
            else
                this.Text = rankCbx.Text + " " + lNameTbx.Text + ", " + fNameBx.Text;
        }

        private void fNameBx_TextChanged(object sender, EventArgs e)
        {
            validateTab();
        }
        //public String[] checkWarning() {}
        //public String[] checkFlagging() {}
    }
}
