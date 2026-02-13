using DVLD.Applications.ReleaseDetainLicenseApplication;
using DVLD.Driver;
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

namespace DVLD.License.DetainLicense
{
    public partial class frmManageDetainLicenseApplication : Form
    {
        DataTable Data;
        clsLicenses License;
        public frmManageDetainLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void LoadDataTable()
        {
            Data = clsDetainedLicense.GetAllDetainedLicenses();
            dataGridView1.DataSource = Data;

            

            dataGridView1.Columns[8].Width = 100;
            lblRecords.Text = dataGridView1.RowCount.ToString();

        }
        void FillComboBox()
        {
            cbFilter.Items.Add("None");
            cbFilter.Items.Add(Data.Columns[0].ColumnName);//Detain ID.
            cbFilter.Items.Add(Data.Columns[1].ColumnName);//License ID.
            cbFilter.Items.Add(Data.Columns[3].ColumnName);//Is relsed.
            cbFilter.Items.Add(Data.Columns[7].ColumnName);//National No.
            cbFilter.Items.Add(Data.Columns[8].ColumnName);//Full Name.
        }

        private void frmManageDetainLicenseApplication_Load(object sender, EventArgs e)
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


                case "IsReleased":
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
            if (cbFilter.Text == "IsReleased")
            {

                if (cbStatus.Text == "Not Released")
                    Data.DefaultView.RowFilter = $"[{Data.Columns[6].ColumnName}] = 0";
                else if (cbStatus.Text == "Released")
                    Data.DefaultView.RowFilter = $"[{Data.Columns[6].ColumnName}] = 1";

                else
                    Data.DefaultView.RowFilter = "";
            }

            dataGridView1.DataSource = Data;
            lblRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void txtSearchBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text==Data.Columns[0].ColumnName || cbFilter.Text==Data.Columns[1].ColumnName)
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
                if (cbFilter.Text == Data.Columns[0].ColumnName || cbFilter.Text == Data.Columns[1].ColumnName)
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

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense Detain = new frmDetainLicense();
            Detain.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenes ReleaceLicense = new frmReleaseDetainedLicenes();
            ReleaceLicense.ShowDialog();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo PersonInfo = new frmShowPersonInfo((string)dataGridView1.CurrentRow.Cells[6].Value);
            PersonInfo.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverLicenseInfo LicenseInfo = new frmDriverLicenseInfo((int)dataGridView1.CurrentRow.Cells[1].Value);
            LicenseInfo.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            License = clsLicenses.Find((int)dataGridView1.CurrentRow.Cells[1].Value);
            frmLicenseHistory History = new frmLicenseHistory(License.Drivers.PersonID);
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            frmReleaseDetainedLicenes Release = new frmReleaseDetainedLicenes((int)dataGridView1.CurrentRow.Cells[1].Value);
            Release.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bool isReleased = (bool)dataGridView1.CurrentRow.Cells[3].Value;
            releaseDetainedLicenseToolStripMenuItem.Enabled = !isReleased;
        }
    }
}
