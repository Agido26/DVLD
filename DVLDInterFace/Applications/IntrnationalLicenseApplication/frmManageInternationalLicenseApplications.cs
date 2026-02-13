using DVLD.Applications.InternationalLicense;
using DVLD.Driver;
using DVLD.License;
using DVLD.People;
using DVLD_Buisness;
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

namespace DVLD.Applications.IntrnationalLicenseApplication
{
    public partial class frmManageInternationalLicenseApplications : Form
    {
        DataTable Data;
        clsInternationalLicense InternationalLicenseInfo;
        public frmManageInternationalLicenseApplications()
        {
            InitializeComponent();
        }
        void LoadDataTable()
        {
            Data = clsInternationalLicense.GetAllInternationalLicenses();
            dataGridView1.DataSource = Data;

            Data.Columns[0].ColumnName = "I.D.L ApplicationID";
            dataGridView1.Columns[0].Name = "I.D.L ApplicationID";
            dataGridView1.Columns[0].Width = 100;

            //dataGridView1.Columns[4].
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;

            Data.Columns[3].ColumnName = "L.D.L ID";
            dataGridView1.Columns[6].Name = "L.D.L ID";
            dataGridView1.Columns[3].Width = 100;


            dataGridView1.Columns[4].Width = 100; 
            dataGridView1.Columns[5].Width = 100;

            Data.Columns[6].ColumnName = "Status";
            dataGridView1.Columns[6].Name = "Status";
            dataGridView1.Columns[6].Width = 60;
            lblRecords.Text = dataGridView1.RowCount.ToString();

        }

        void FillComboBox()
        {
            cbFilter.Items.Add("None");
            cbFilter.Items.Add(Data.Columns[0].ColumnName);//I.D.L ApplicationID.
            cbFilter.Items.Add(Data.Columns[1].ColumnName);//App ID.
            cbFilter.Items.Add(Data.Columns[2].ColumnName);//Driver ID.
            cbFilter.Items.Add(Data.Columns[3].ColumnName);//Local License ID.
            cbFilter.Items.Add(Data.Columns[6].ColumnName);//Status.


            
        }

        private void frmManageInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            LoadDataTable();
            FillComboBox();
            cbFilter.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            cbFilter_SelectedIndexChanged(null, null);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilter.Text)
            {
                case "None":
                    txtSearchBar.Visible = false;
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

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "Status")
            {

                if (cbStatus.Text == "Not Active")
                    Data.DefaultView.RowFilter = $"[{Data.Columns[6].ColumnName}] = 0";
              else if(cbStatus.Text == "Active")
                    Data.DefaultView.RowFilter = $"[{Data.Columns[6].ColumnName}] = 1";

                else
                    Data.DefaultView.RowFilter = "";
            }

            dataGridView1.DataSource = Data;
            lblRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void txtSearchBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "I.D.L ApplicationID"|| cbFilter.Text == "ApplicationID"
                || cbFilter.Text == "DriverID"|| cbFilter.Text == "L.D.L ID")
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
                if (cbFilter.Text == "I.D.L ApplicationID" || cbFilter.Text == "ApplicationID"
                 || cbFilter.Text == "DriverID" || cbFilter.Text == "L.D.L ID")
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

        private void btnNewInternationallicenseApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicense newInternationalLicense = new frmNewInternationalLicense();
            newInternationalLicense.ShowDialog();
            LoadDataTable();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo(InternationalLicenseInfo.PersonID);
            personInfo.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory LicenseHistory = new frmLicenseHistory(InternationalLicenseInfo.PersonID);
            LicenseHistory.ShowDialog();
            LoadDataTable();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverLicenseInfo licenseInfo = new frmDriverLicenseInfo(InternationalLicenseInfo.IssuedUsingLocalLicenseID);
            licenseInfo.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
             InternationalLicenseInfo = clsInternationalLicense.Find((int)dataGridView1.CurrentRow.Cells[0].Value);

        }

    }
}
