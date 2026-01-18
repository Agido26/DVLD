using DVLD.Applications.LocalDrivingLicense;
using DVLD.Driver;
using DVLD.Tests;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalDrivingLicense
{
    public partial class frmMangelocalDrivingLicense : frmDataGridWithFilter
    {
        DataTable Data;
        int _LicenseID;
        public frmMangelocalDrivingLicense()
        {
            InitializeComponent();
        }

        void LoadDataTable()
        {
            Data = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication();
            dataGridView1.DataSource = Data;

            Data.Columns[0].ColumnName = "L.D.L ApplicationID";
            dataGridView1.Columns[0].Name = "L.D.L ApplicationID";
            dataGridView1.Columns[0].Width = 100;

            //dataGridView1.Columns[4].
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 100;

            dataGridView1.Columns[5].Name = "Passed Test";
            Data.Columns[5].ColumnName = "Passed Test";
            dataGridView1.Columns[5].Width = 100;


            dataGridView1.Columns[6].Width = 60;
            lblRecords.Text = dataGridView1.RowCount.ToString();

        }
        void FillComboBox()
        {
            cbFilter.Items.Add("None");
            cbFilter.Items.Add(Data.Columns[0].ColumnName);//L.D.L ApplicationID.
            cbFilter.Items.Add(Data.Columns[1].ColumnName);//Class Name.
            cbFilter.Items.Add(Data.Columns[2].ColumnName);//National No.
            cbFilter.Items.Add(Data.Columns[3].ColumnName);//Full Name.
            cbFilter.Items.Add(Data.Columns[6].ColumnName);//Status.
        }
        private void frmMangelocalDrivingLicense_Load(object sender, EventArgs e)
        {
            LoadDataTable();
            FillComboBox();
            cbFilter.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            cbFilter_SelectedIndexChanged(null, null);
        }     

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbFilter.Text)
            {
                case "None":
                    txtSearchBar.Visible = false;
                    cbStatus.Visible = false;
                    break;
                case "L.D.L ApplicationID":
                    txtSearchBar.Visible = true;
                    cbStatus.Visible = false;
                    break;
                case "Status":
                    cbStatus.Visible = true;
                    txtSearchBar.Visible = false;
                    break;
                default:
                    cbStatus.Visible = false;
                    txtSearchBar.Visible = true;
                    break;
            }
            Data.DefaultView.RowFilter = ""; //restet the filter
            txtSearchBar.Text = "";//Reset text box in case are there any char  
            lblRecords.Text = dataGridView1.RowCount.ToString();


        }

        private void txtSearchBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "L.D.L ApplicationID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBar.Text != "")
            {
                if (cbFilter.Text == "L.D.L ApplicationID")
                {
                   
                    Data.DefaultView.RowFilter = $"[{cbFilter.Text}] = {txtSearchBar.Text}";
                }
              
                else { Data.DefaultView.RowFilter = $"[{cbFilter.Text}] LIKE '{txtSearchBar.Text}%'"; }


            }
            else
                Data.DefaultView.RowFilter = "";

            dataGridView1.DataSource = Data;
            lblRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "Status")
            {
              
                if (cbStatus.Text != "All")
                    Data.DefaultView.RowFilter = $"[{cbFilter.Text}] LIKE '{cbStatus.Text}%'";
                else
                    Data.DefaultView.RowFilter = "";
            }


            dataGridView1.DataSource = Data;
            lblRecords.Text = dataGridView1.RowCount.ToString();
        }


        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateLocalDrivingLicense LocalLicnese = new frmAdd_UpdateLocalDrivingLicense((int)dataGridView1.CurrentRow.Cells[0].Value);
            LocalLicnese.ShowDialog();
            LoadDataTable();
        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
          var Message=  MessageBox.Show("Are You Sure you want to cancel this application?", "Cancel Application", MessageBoxButtons.YesNo);
            if(Message==DialogResult.Yes)
            {
                clsLocalDrivingLicenseApplication app = clsLocalDrivingLicenseApplication.FindByLocalLicenseID((int)dataGridView1.CurrentRow.Cells[0].Value);
                if (app.CancelApplication())
                {
                    MessageBox.Show("Application was cancelled succefully");
                    LoadDataTable();
                }
                else { MessageBox.Show("Something went wrong"); return; }
            }   
        }
        private void btnAddLocalLicense_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateLocalDrivingLicense LocalLicnese = new frmAdd_UpdateLocalDrivingLicense();
            LocalLicnese.ShowDialog();
            LoadDataTable();
        }
        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo Info = new frmLocalDrivingLicenseApplicationInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            Info.ShowDialog();
            LoadDataTable();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            clsLocalDrivingLicenseApplication Local = clsLocalDrivingLicenseApplication.FindByLocalLicenseID((int)dataGridView1.CurrentRow.Cells[0].Value);



            bool IsLicensExist = clsLicenses.IsLicenseExistByApplicationID(Local.ApplicationID, Local.LicenseClassID);

            int PassedTests = (int)dataGridView1.CurrentRow.Cells[5].Value;

            issueDrivingLicenseToolStripMenuItem.Enabled = (PassedTests == 3 && !IsLicensExist);
            editApplicationToolStripMenuItem.Enabled = (!IsLicensExist && (Local.ApplicationStatus != clsApplication.enStatus.enCancelled && Local.ApplicationStatus != clsApplication.enStatus.enCompleted));
            deleteApplicationToolStripMenuItem.Enabled = (!IsLicensExist );
            cancelApplicationToolStripMenuItem.Enabled = !IsLicensExist && Local.ApplicationStatus != clsApplication.enStatus.enCancelled;
            sechduleTestToolStripMenuItem.Enabled = (!IsLicensExist && PassedTests < 3 && Local.ApplicationStatus != clsApplication.enStatus.enCancelled);
            sToolStripMenuItem.Enabled = IsLicensExist;




            bool Vision = clsTests.TestResultByLocalDrivingLicenseID(Local.LocalDrivingLicenseID, clsTestTypes.enTestType.VisionTest);
            bool Wrriten = clsTests.TestResultByLocalDrivingLicenseID(Local.LocalDrivingLicenseID, clsTestTypes.enTestType.WrittenTest);
            bool street = clsTests.TestResultByLocalDrivingLicenseID(Local.LocalDrivingLicenseID, clsTestTypes.enTestType.StreetTest);

            sechduleVisionTestToolStripMenuItem.Enabled = !Vision;
            sechduleWrittenTestToolStripMenuItem.Enabled = (!Wrriten && Vision);
            sechduleStreetTestToolStripMenuItem.Enabled = (!street && Wrriten);


        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete?","Delete",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                if(clsLocalDrivingLicenseApplication.DeleteLocalApplicationByID((int)dataGridView1.CurrentRow.Cells[0].Value))
                
                {
                    MessageBox.Show("Done");
                }
                else MessageBox.Show("You Cant Delete this person because there data linked to it");
            }

            LoadDataTable();
        }

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments VTest = new frmTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.VisionTest);
            VTest.ShowDialog();
            LoadDataTable();
        }

        private void sechduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments WTest = new frmTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.WrittenTest);
            WTest.ShowDialog();
            LoadDataTable();
        }

        private void sechduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments STest = new frmTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.StreetTest);
            STest.ShowDialog();
            LoadDataTable();
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueLicense frmIssueLicense = new frmIssueLicense((int)dataGridView1.CurrentRow.Cells[0].Value);
           
            frmIssueLicense.ShowDialog();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverInfo driverInfo = new frmDriverInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            driverInfo.ShowDialog();
        }
    }
}
