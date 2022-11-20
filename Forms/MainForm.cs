using My_Soldiers.Backend_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace My_Soldiers
{
    public partial class MainForm : Form
    {
        //        DashboardControl dashboardCont;


        public MainForm()
        {
            InitializeComponent();
        }

        private void mySoldiersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult about = new AboutForm().ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // dashboardCont = new DashboardControl();
            // tabControl.TabPages.Add(dashboardCont);
            try
            {
                loadXML();
            }
            catch
            {
                Console.WriteLine("XML ERROR");

            };

        }

        private void soldierToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SoldierControl newSoldierTab = new SoldierControl();

            tabControl.TabPages.Add(newSoldierTab);
            tabControl.SelectedIndex = tabControl.TabCount - 1;
        }

        private void loadXML()
        {
            XmlDocument document = new XmlDocument();
            document.Load(StaticLibrary.XML_DOCUMENT);
            XmlNode rootNode = document.SelectSingleNode(StaticLibrary.XML_ROOT);
            XmlNodeList soldierList = rootNode.SelectNodes(StaticLibrary.XML_SOLDIER);
            foreach (XmlNode soldier in soldierList)
            {
                SoldierControl control = new SoldierControl();
                // SINGLE STRINGS
                control.fNameBx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_FNAME).InnerText;
                control.mNameBx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_MNAME).InnerText;
                control.lNameTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_LNAME).InnerText;
                control.rankCbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_RANK).InnerText;
                control.pointsTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_POINTS).InnerText;
                control.dependTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_DEPENDENTS).InnerText;
                control.addressesTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_ADDRESSES).InnerText;
                control.vehicleTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_VEHICLES).InnerText;
                control.noteTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_NOTE).InnerText;
                control.mosTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_MOS).InnerText;
                // SINGLE DATES
                control.dorDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_RANK_DATE).InnerText;
                control.barDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_BAR_DATE).InnerText;
                control.flaggedDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_FLAG_DATE).InnerText;
                control.basdDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_BASD).InnerText;
                control.pebdDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_PEBD).InnerText;
                control.besdDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_BESD).InnerText;
                control.etsDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_ETS).InnerText;
                control.diemsDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_DIEMS).InnerText;
                control.agcsmDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_AGCSM).InnerText;
                control.pcsDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_PCS).InnerText;
                // SINGLE BOOLS
                if (soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_PROMOTABLE).InnerText == "True")
                    control.promotableChk.Checked = true;
                if (soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_BAR).InnerText == "True")
                    control.barChk.Checked = true;
                if (soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_FLAG).InnerText == "True")
                    control.flaggedChk.Checked = true;
                control.validateTab();
                // MEDPROS-Dental
                XmlNode dentalNode = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_DENTAL);
                control.medprosControl1.dentalCbx.Text = dentalNode.Attributes.GetNamedItem(StaticLibrary.XML_SOLDIER_DENTAL_CLASS).InnerText;
                control.medprosControl1.dentalDTP.Text = dentalNode.InnerText;
                // MEDPROS-Vision
                control.medprosControl1.visionDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_VISION).InnerText;
                // MEDPROS-Hearing
                control.medprosControl1.hearingDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_HEARING).InnerText;
                // MEDPROS-PHA
                control.medprosControl1.phaDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_PHA).InnerText;
                // APFT
                XmlNodeList recordList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_APFT);
                foreach (XmlNode r in recordList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.apftDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_DATE) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_DATE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_PUSH) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_PUSH).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_SIT) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_SIT).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_TIME) != null)
                            row.Cells[3].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_TIME).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_ALTERNATE) != null)
                            row.Cells[4].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_ALTERNATE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_SCORE) != null)
                            row.Cells[5].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_SCORE).InnerText;

                        control.apftDGV.Rows.Add(row);
                    }
                }


                // AWARD
                XmlNodeList awardList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_APFT);
                foreach (XmlNode r in awardList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.awardsDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_AWARD_NAME) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_AWARD_NAME).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_AWARD_DATE) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_AWARD_DATE).InnerText;

                        control.awardsDGV.Rows.Add(row);
                    }
                }
                // WEAPON
                XmlNodeList weaponsList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_WEAPON);
                foreach (XmlNode r in weaponsList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.weaponsDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_WEAPON_SYSTEM) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_WEAPON_SYSTEM).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_WEAPON_SCORE) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_WEAPON_SCORE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_WEAPON_DATE) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_WEAPON_DATE).InnerText;

                        control.weaponsDGV.Rows.Add(row);
                    }
                }
                // ABCP
                XmlNodeList abcpList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_ABCP);
                foreach (XmlNode r in abcpList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.weaponsDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_ABCP_DATE) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_ABCP_DATE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_ABCP_PERCENT) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_ABCP_PERCENT).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_ABCP_MAX) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_ABCP_MAX).InnerText;

                        control.abcpDGV.Rows.Add(row);
                    }
                }
                // MILED
                XmlNodeList miledList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_MILED);
                foreach (XmlNode r in miledList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.milEdDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_MILED_COURSE) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_MILED_COURSE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_MILED_DATE) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_MILED_DATE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_MILED_ANNUAL) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_MILED_ANNUAL).InnerText;

                        control.milEdDGV.Rows.Add(row);
                    }
                }

                // CIVED
                XmlNodeList civedList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_CIVED);
                foreach (XmlNode r in civedList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.civEdDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_INSTITUTION) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_INSTITUTION).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_START) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_START).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_END) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_END).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_CREDITS) != null)
                            row.Cells[3].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_CREDITS).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_GRADUATE) != null)
                            row.Cells[4].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_GRADUATE).InnerText;

                        control.civEdDGV.Rows.Add(row);
                    }
                }

                // CERTIFICATIONS
                XmlNodeList certList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_CERT);
                foreach (XmlNode r in certList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.certificationsDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CERT_NAME) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CERT_NAME).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CERT_DATE) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CERT_DATE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CERT_RENEW) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CERT_RENEW).InnerText;

                        control.certificationsDGV.Rows.Add(row);
                    }
                }

                // COUNSELLINGS
                XmlNodeList counselList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_COUNSELLING);
                foreach (XmlNode r in counselList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.counsellingDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_COUNSELLING_DATE) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_COUNSELLING_DATE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_COUNSELLING_TITLE) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_COUNSELLING_TITLE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_COUNSELLING_FILE) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_COUNSELLING_FILE).InnerText;

                        control.counsellingDGV.Rows.Add(row);
                    }
                }



                // ADD AND FINISH
                tabControl.TabPages.Add(control);
                control.medprosControl1.validate();
                validateDataGridView(control.apftDGV);
                validateDataGridView(control.awardsDGV);
                validateDataGridView(control.weaponsDGV);
                validateDataGridView(control.abcpDGV);
                validateDataGridView(control.milEdDGV);
                validateDataGridView(control.civEdDGV);
                validateDataGridView(control.certificationsDGV);
                validateDataGridView(control.counsellingDGV);
                control.toggleAdminBoxLock(true);
            }

        }

        private void loadXML(String filename)
        {
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode rootNode = document.SelectSingleNode(StaticLibrary.XML_ROOT);
            XmlNodeList soldierList = rootNode.SelectNodes(StaticLibrary.XML_SOLDIER);
            foreach (XmlNode soldier in soldierList)
            {
                SoldierControl control = new SoldierControl();
                // SINGLE STRINGS
                control.fNameBx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_FNAME).InnerText;
                control.mNameBx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_MNAME).InnerText;
                control.lNameTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_LNAME).InnerText;
                control.rankCbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_RANK).InnerText;
                control.pointsTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_POINTS).InnerText;
                control.dependTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_DEPENDENTS).InnerText;
                control.addressesTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_ADDRESSES).InnerText;
                control.vehicleTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_VEHICLES).InnerText;
                control.noteTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_NOTE).InnerText;
                control.mosTbx.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_MOS).InnerText;
                // SINGLE DATES
                control.dorDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_RANK_DATE).InnerText;
                control.barDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_BAR_DATE).InnerText;
                control.flaggedDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_FLAG_DATE).InnerText;
                control.basdDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_BASD).InnerText;
                control.pebdDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_PEBD).InnerText;
                control.besdDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_BESD).InnerText;
                control.etsDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_ETS).InnerText;
                control.diemsDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_DIEMS).InnerText;
                control.agcsmDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_AGCSM).InnerText;
                control.pcsDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_PCS).InnerText;
                // SINGLE BOOLS
                if (soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_PROMOTABLE).InnerText == "True")
                    control.promotableChk.Checked = true;
                if (soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_BAR).InnerText == "True")
                    control.barChk.Checked = true;
                if (soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_FLAG).InnerText == "True")
                    control.flaggedChk.Checked = true;
                // MEDPROS-Dental
                XmlNode dentalNode = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_DENTAL);
                control.medprosControl1.dentalCbx.Text = dentalNode.Attributes.GetNamedItem(StaticLibrary.XML_SOLDIER_DENTAL_CLASS).InnerText;
                control.medprosControl1.dentalDTP.Text = dentalNode.InnerText;
                // MEDPROS-Vision
                control.medprosControl1.visionDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_VISION).InnerText;
                // MEDPROS-Hearing
                control.medprosControl1.hearingDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_HEARING).InnerText;
                // MEDPROS-PHA
                control.medprosControl1.phaDTP.Text = soldier.SelectSingleNode(StaticLibrary.XML_SOLDIER_PHA).InnerText;
                // APFT
                XmlNodeList recordList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_APFT);
                foreach (XmlNode r in recordList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.apftDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_DATE) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_DATE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_PUSH) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_PUSH).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_SIT) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_SIT).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_TIME) != null)
                            row.Cells[3].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_TIME).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_ALTERNATE) != null)
                            row.Cells[4].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_ALTERNATE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_SCORE) != null)
                            row.Cells[5].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_APFT_SCORE).InnerText;

                        control.apftDGV.Rows.Add(row);
                    }
                }


                // AWARD
                XmlNodeList awardList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_APFT);
                foreach (XmlNode r in awardList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.awardsDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_AWARD_NAME) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_AWARD_NAME).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_AWARD_DATE) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_AWARD_DATE).InnerText;

                        control.awardsDGV.Rows.Add(row);
                    }
                }
                // WEAPON
                XmlNodeList weaponsList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_WEAPON);
                foreach (XmlNode r in weaponsList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.weaponsDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_WEAPON_SYSTEM) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_WEAPON_SYSTEM).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_WEAPON_SCORE) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_WEAPON_SCORE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_WEAPON_DATE) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_WEAPON_DATE).InnerText;

                        control.weaponsDGV.Rows.Add(row);
                    }
                }
                // ABCP
                XmlNodeList abcpList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_ABCP);
                foreach (XmlNode r in abcpList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.weaponsDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_ABCP_DATE) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_ABCP_DATE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_ABCP_PERCENT) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_ABCP_PERCENT).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_ABCP_MAX) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_ABCP_MAX).InnerText;

                        control.abcpDGV.Rows.Add(row);
                    }
                }
                // MILED
                XmlNodeList miledList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_MILED);
                foreach (XmlNode r in miledList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.milEdDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_MILED_COURSE) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_MILED_COURSE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_MILED_DATE) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_MILED_DATE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_MILED_ANNUAL) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_MILED_ANNUAL).InnerText;

                        control.milEdDGV.Rows.Add(row);
                    }
                }

                // CIVED
                XmlNodeList civedList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_CIVED);
                foreach (XmlNode r in civedList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.civEdDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_INSTITUTION) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_INSTITUTION).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_START) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_START).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_END) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_END).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_CREDITS) != null)
                            row.Cells[3].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_CREDITS).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_GRADUATE) != null)
                            row.Cells[4].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CIVED_GRADUATE).InnerText;

                        control.civEdDGV.Rows.Add(row);
                    }
                }

                // CERTIFICATIONS
                XmlNodeList certList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_CERT);
                foreach (XmlNode r in certList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.certificationsDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CERT_NAME) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CERT_NAME).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CERT_DATE) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CERT_DATE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CERT_RENEW) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_CERT_RENEW).InnerText;

                        control.certificationsDGV.Rows.Add(row);
                    }
                }

                // COUNSELLINGS
                XmlNodeList counselList = soldier.SelectNodes(StaticLibrary.XML_SOLDIER_COUNSELLING);
                foreach (XmlNode r in counselList)
                {
                    if (r.HasChildNodes)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(control.counsellingDGV);
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_COUNSELLING_DATE) != null)
                            row.Cells[0].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_COUNSELLING_DATE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_COUNSELLING_TITLE) != null)
                            row.Cells[1].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_COUNSELLING_TITLE).InnerText;
                        if (r.SelectSingleNode(StaticLibrary.XML_SOLDIER_COUNSELLING_FILE) != null)
                            row.Cells[2].Value = r.SelectSingleNode(StaticLibrary.XML_SOLDIER_COUNSELLING_FILE).InnerText;

                        control.counsellingDGV.Rows.Add(row);
                    }
                }



                // ADD AND FINISH
                tabControl.TabPages.Add(control);
                control.medprosControl1.validate();
                validateDataGridView(control.apftDGV);
                validateDataGridView(control.awardsDGV);
                validateDataGridView(control.weaponsDGV);
                validateDataGridView(control.abcpDGV);
                validateDataGridView(control.milEdDGV);
                validateDataGridView(control.civEdDGV);
                validateDataGridView(control.certificationsDGV);
                validateDataGridView(control.counsellingDGV);

                control.toggleAdminBoxLock(true);
                control.validateTab();
            }

        }
        private void validateDataGridView(DataGridView dataGridView)
        {
            for (int i = dataGridView.Rows.Count - 1; i > -1; i--)
            {
                DataGridViewRow row = dataGridView.Rows[i];
                if (!row.IsNewRow && row.Cells[0].Value == null)
                {
                    dataGridView.Rows.RemoveAt(i);
                }
            }
        }
        private void saveXML()
        {
            XmlTextWriter tw = new XmlTextWriter(StaticLibrary.XML_DOCUMENT, null);
            tw.WriteStartDocument();
            tw.WriteStartElement(StaticLibrary.XML_ROOT);
            foreach (SoldierControl soldier in tabControl.TabPages)
            {

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
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_MOS, soldier.mosTbx.Text);
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
            }


            tw.WriteEndElement();
            tw.Close();
        }
        private void saveXML(String filename)
        {
            XmlTextWriter tw = new XmlTextWriter(filename, null);
            tw.WriteStartDocument();
            tw.WriteStartElement(StaticLibrary.XML_ROOT);
            foreach (SoldierControl soldier in tabControl.TabPages)
            {

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
                tw.WriteElementString(StaticLibrary.XML_SOLDIER_MOS, soldier.mosTbx.Text);
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
            }


            tw.WriteEndElement();
            tw.Close();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //dashboardCont.Dispose();
            saveXML();
        }

        private void mEDPROSSpreadsheetExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create Summary HTML Document
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Soldier..";
            saveFileDialog.Filter = "Web Files|*.html";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.InitialDirectory = "C:\\";

            String fileName;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamWriter document = new StreamWriter(stream);
                document.Write("<html>" +
                    "<head>" +
                    "<title> Summarized Leaders Book </title>" +
                    "</head>" +
                    "<body>    " +
                    "<h1 align = \" center\" > Summarized Leaders Book </h1>" +
                    "<hr /> ");
                document.WriteLine("<table align=\"center\" border=\"1\" width=\"75%\">");
                document.WriteLine("<tr><td>Rank</td><td>Name</td><td>MOS</td><td>BESD</td><td>DOR</td><td>PCS</td><td>ETS</td><td>PP</td><td>Flagged</td></tr>");
                foreach (SoldierControl soldier in tabControl.TabPages)
                {
                    document.WriteLine("<tr><td>" +
                        soldier.rankCbx.SelectedItem.ToString() +
                        "</td><td>" + soldier.fNameBx.Text + " " + soldier.mNameBx.Text + " " + soldier.lNameTbx.Text +
                        "</td><td>" + soldier.mosTbx.Text +
                        "</td><td>" + soldier.besdDTP.Value.ToShortDateString() +
                        "</td><td>" + soldier.dorDTP.Value.ToShortDateString() +
                        "</td><td>" + soldier.pcsDTP.Value.ToShortDateString() +
                        "</td><td>" + soldier.etsDTP.Value.ToShortDateString() +
                        "</td><td>" + soldier.pointsTbx.Text +
                        "</td><td>" + soldier.flaggedChk.Checked + "</td></tr>");

                }

                document.WriteLine("</table></body></html>");
                document.Flush();
                document.Close();

            }
        }

        private void leadersBookWordDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.Description = "Choose Folder to Build Leader's Book";

            if(folderBrowserDialog.ShowDialog() == DialogResult.OK) 
            {
                String path = folderBrowserDialog.SelectedPath;
                // Create Summary Page
                {
                    Console.WriteLine("Creating Summary Page");
                    FileStream stream = new FileStream(path + "\\summary.html", FileMode.OpenOrCreate);
                    StreamWriter document = new StreamWriter(stream);
                    document.Write("<html>" +
                        "<head>" +
                        "<title> Summarized Leaders Book </title>" +
                        "</head>" +
                        "<body>    " +
                        "<h2 align = \" center\" > Summarized Leaders Book </h2>" +
                        "<hr /> ");
                    document.WriteLine("<table align=\"center\" border=\"1\" width=\"75%\">");
                    document.WriteLine("<tr><td>Rank</td><td>Name</td><td>MOS</td><td>BESD</td><td>DOR</td><td>PCS</td><td>ETS</td><td>PP</td><td>Flagged</td></tr>");
                    foreach (SoldierControl soldier in tabControl.TabPages)
                    {
                        document.WriteLine("<tr><td>" +
                            soldier.rankCbx.SelectedItem.ToString() +
                            "</td><td>" + soldier.fNameBx.Text + " " + soldier.mNameBx.Text + " " + soldier.lNameTbx.Text +
                            "</td><td>" + soldier.mosTbx.Text +
                            "</td><td>" + soldier.besdDTP.Value.ToShortDateString() +
                            "</td><td>" + soldier.dorDTP.Value.ToShortDateString() +
                            "</td><td>" + soldier.pcsDTP.Value.ToShortDateString() +
                            "</td><td>" + soldier.etsDTP.Value.ToShortDateString() +
                            "</td><td>" + soldier.pointsTbx.Text +
                            "</td><td>" + soldier.flaggedChk.Checked + "</td></tr>");
                        

                    }

                    document.WriteLine("</table></body></html>");
                    document.Flush();
                    document.Close();
                }
                // Create Index Page
                {
                    Console.WriteLine("Creating Index Page");
                    FileStream stream = new FileStream(path + "\\index.html", FileMode.OpenOrCreate);
                    StreamWriter document = new StreamWriter(stream);
                    document.Write("<html>" +
                        "<head>" +
                        "<title> Leaders Book (Updated " + DateTime.Now.ToShortDateString() +")</title>" +
                        "</head>" +
                        "<body>    ");
                    document.WriteLine("<h1 align=\"center\">Leaders Book (Updated " + DateTime.Now.ToShortDateString() + ")</h1><hr>");
                    document.WriteLine("<iframe src=\"side_menu.html\" name=\"iframe_menu\"  height=\"100%\" width = \"25%\" title=\"Iframe Example\"></iframe>");
                    document.WriteLine("<iframe src=\"summary.html\" name=\"iframe_target\"  height=\"100%\" width = \"70%\" title=\"Iframe Example\"></iframe>");

                    document.WriteLine("</body></html>");
                    document.Flush();
                    document.Close();

                }
                // Create Side Menu Page
                System.Console.WriteLine("Creating Side Menu page");
                    FileStream menuStream = new FileStream(path + "\\side_menu.html", FileMode.OpenOrCreate);
                    StreamWriter menuDocument = new StreamWriter(menuStream);
                menuDocument.Write("<html>" +
                    "<head>" +
                    "<title> Leaders Book (Updated " + DateTime.Now.ToShortDateString() + ")</title>" +
                    

                    "</head>" +
                    "<body>    ") ;
                menuDocument.WriteLine("<h3>REPORTS</h3>");
                menuDocument.WriteLine("<ul>");
                menuDocument.WriteLine("<li><a href=\"summary.html\" target=\"iframe_target\">Summary</a></li>");
                menuDocument.WriteLine("</ul>");

                menuDocument.WriteLine("<h3>SOLDIERS</h3>");
                menuDocument.WriteLine("<ul>");
                // Create Soldier Pages and Menu Items
                foreach (SoldierControl soldier in tabControl.TabPages)
                {
                    
                    String fileName = path + "\\"+soldier.rankCbx.SelectedItem + soldier.fNameBx.Text + soldier.lNameTbx.Text + ".html";
                    Console.WriteLine("Creating " + fileName);
                    FileStream stream = new FileStream(fileName, FileMode.CreateNew);
                    StreamWriter document = new StreamWriter(stream);
                    document.Write("<html>" +
                        "<head>" +
                        "<title> Leaders Book (Updated " + DateTime.Now.ToShortDateString() + ")</title>" +
                        "<style>table{border-collapse:collapse;}            table tr td, th{border: 1px solid #000000;padding: 5px;            }table td:hover{background: #f1f1f1;}.center_boxed {margin: auto; width: 80 %; border: 3px solid #73AD21; padding: 10px;}</style>" +
                        "</head>" +
                        "<body>    ");
                    document.WriteLine("<h2>" + soldier.rankCbx.SelectedItem + " " + soldier.lNameTbx.Text +", "+soldier.fNameBx.Text + "</h2><hr>");

                    document.WriteLine("<h3>Admin Data</h3>");
                    document.WriteLine("<table class=\"center_boxed\"><tr><td>Rank</td><td>First Name</td><td>Middle Name</td><td>Last Name</td><td>Date of Rank</td><td>Promotion Points</td><td>MOS</td></tr>");
                    document.WriteLine("<tr><td>" + soldier.rankCbx.SelectedItem.ToString() +
                        "</td><td>" + soldier.fNameBx.Text +
                        "</td><td>" + soldier.mNameBx.Text +
                        "</td><td>" + soldier.lNameTbx.Text +
                        "</td><td>" + soldier.dorDTP.Value.ToShortDateString() +
                        "</td><td>" + soldier.pointsTbx.Text + "</td>" +
                        "</td><td>" + soldier.mosTbx.Text +
                        "</tr></table");
                    document.WriteLine("<br /><br />");

                    document.WriteLine("<table class=\"center_boxed\"><tr><td>BASD</td><td>PEBD</td><td>DIEMS</td><td>AGCSM</td><td>PCS</td><td>ETS</td></tr>");
                    document.WriteLine("<tr><td>" + soldier.basdDTP.Value.ToShortDateString() +
                        "</td><td>" + soldier.pebdDTP.Value.ToShortDateString() +
                        "</td><td>" + soldier.diemsDTP.Value.ToShortDateString() +
                        "</td><td>" + soldier.agcsmDTP.Value.ToShortDateString() +
                        "</td><td>" + soldier.pcsDTP.Value.ToShortDateString() +
                        "</td><td>" + soldier.etsDTP.Value.ToShortDateString() + "</td></tr></table>");
                    document.WriteLine("<br /><br />");

                    document.WriteLine("<h3>Personal Data</h3>");
                    document.WriteLine("<table class=\"center_boxed\"><tr><td>Dependents</td><td>Addresses</td><td>Vehicles</td></tr><tr>");
                    document.Write("<td>" + soldier.dependTbx.Text.Replace("\n", "<br>").ToString() + "</td>");
                    document.Write("<td>" + soldier.addressesTbx.Text.Replace("\n","<br>").ToString() + "</td>");
                    document.Write("<td>" + soldier.vehicleTbx.Text.Replace("\n", "<br>").ToString() + "</td></tr></table>");
                    document.WriteLine("<br /><br />");

                    document.WriteLine("<h3>Training Data</h3>");
                    document.WriteLine("<table class=\"center_boxed\"><tr><td>Physical Training</td><td>Weapons</td></tr><tr>");
                    document.WriteLine("<td><table><tr><td>Date</td><td>PUs</td><td>SUs</td><td>Time</td><td>Event</td><td>Score</td></tr>");
                    foreach(DataGridViewRow row in soldier.apftDGV.Rows)    
                        document.WriteLine("<tr><td>" + row.Cells[0].Value + "</td><td>" + row.Cells[1].Value + "</td><td>" + row.Cells[2].Value + "</td><td>" + row.Cells[3].Value + "</td><td>" + row.Cells[4].Value + "</td><td>" + row.Cells[5].Value + "</td></tr>");
                    document.WriteLine("</table></td>");
                    document.WriteLine("<td><table><tr><td>System</td><td>Score</td><td>Date</td></tr>");
                    foreach (DataGridViewRow row in soldier.weaponsDGV.Rows)
                        document.WriteLine("<tr><td>" + row.Cells[0].Value + "</td><td>" + row.Cells[1].Value + "</td><td>" + row.Cells[2].Value + "</td></tr>");
                    document.WriteLine("</table></td>");
                    document.WriteLine("</table>");
                    document.WriteLine("<br /><br />");

                    document.WriteLine("<h3>Awards</h3>");
                    document.WriteLine("<table class=\"center_boxed\">");
                    document.WriteLine("<tr><td>Award</td><td>Date</td></tr>");
                    foreach(DataGridViewRow row in soldier.awardsDGV.Rows)
                        document.WriteLine("<tr><td>"+row.Cells[0].Value+"</td><td>"+row.Cells[1].Value+"</td></tr>");
                    document.WriteLine("</table>");
                    document.WriteLine("<br /><br />");

                    document.WriteLine("<h3>Education Data</h3>");
                    document.WriteLine("<table class=\"center_boxed\">");
                    document.WriteLine("<tr><td>Military Courses</td><td>Civilian Education</td></tr>");
                    document.WriteLine("<tr>");
                    document.WriteLine("<td>");
                    // Military Courses Table
                    document.WriteLine("<table class=\"center_boxed\">");
                    document.WriteLine("<tr><td>Course Name</td><td>Date</td></tr");
                    foreach (DataGridViewRow row in soldier.milEdDGV.Rows)
                        document.WriteLine("<tr><td>" + row.Cells[0].Value + "</td><td>" + row.Cells[1].Value + "</td></tr>");
                    document.WriteLine("</table>");
                    document.WriteLine("</td>");



                    document.WriteLine("<td>");
                    // Civilian Education Table
                    document.WriteLine("<table class=\"center_boxed\">");
                    document.WriteLine("<tr><td>School Name</td><td>Credit Hours</td><td>Graduated</td></tr");
                    foreach (DataGridViewRow row in soldier.civEdDGV.Rows)
                        document.WriteLine("<tr><td>" + row.Cells[0].Value + "</td><td>" + row.Cells[3].Value + "</td><td>"+row.Cells[4].Value+"</td></tr>");
                    document.WriteLine("</table>");

                    document.WriteLine("</td></tr></table>");

                    document.WriteLine("<br /><br />");

                    document.WriteLine("<h3>Certification</h3>");
                    document.WriteLine("<table class=\"center_boxed\">");
                    foreach (DataGridViewRow row in soldier.certificationsDGV.Rows)
                        document.WriteLine("<tr><td>" + row.Cells[0].Value + "</td></tr>");
                    document.WriteLine("</table>");
                    document.WriteLine("<br /><br />");


                    document.WriteLine("<h3>Notes</h3>");
                    document.WriteLine("<p>" +soldier.noteTbx.Text.Replace("\n","<br />").ToString() +"</p>");

                    document.WriteLine("<br /><br />");

                    document.WriteLine("<h3>Documentation</h3>");
                    document.WriteLine("<table class=\"center_boxed\">");
                    document.WriteLine("<tr><td>Date</td><td>Document Title</td></tr>");
                    foreach (DataGridViewRow row in soldier.counsellingDGV.Rows)
                    {
                        document.WriteLine("<tr><td>" + row.Cells[0].Value + "</td><td>" + row.Cells[1].Value + "</td></tr>");
                    }
                    document.WriteLine("</table>");
                    document.WriteLine("</body></html>");
                    document.Flush();
                    document.Close();

                    menuDocument.WriteLine("<li><a href=\"" +soldier.rankCbx.SelectedItem + soldier.fNameBx.Text + soldier.lNameTbx.Text + ".html\"" + "\" target=\"iframe_target\">" +soldier.rankCbx.SelectedItem+" "+soldier.lNameTbx.Text+ ", "+soldier.fNameBx.Text+ "</a></li>");
                }
                // Close Menu Document
                menuDocument.WriteLine("</ul></body></html>");
                menuDocument.Flush();
                menuDocument.Close();
                System.Console.WriteLine("Finish Side Menu Page");
            }

        }
    }
}