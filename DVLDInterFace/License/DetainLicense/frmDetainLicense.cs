using DVLD.Driver;
using DVLD.Login;
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
    public partial class frmDetainLicense : Form
    {
        private int _DetainedID = -1;
        private int _LicenseID = -1;
        clsLicenses _License;
        public frmDetainLicense()
        {
            InitializeComponent();
        }
        public frmDetainLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }
        private void llblShowLicHis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory History = new frmLicenseHistory(ctrlDriverInfoWithFilter1.SelectedLicenseInfo.Drivers.PersonID);
            History.ShowDialog();
        }

        private void llblShowLicInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo DriverInfo = new frmDriverLicenseInfo(ctrlDriverInfoWithFilter1.LicenseID);
            DriverInfo.ShowDialog();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
           
            llblShowLicHis.Enabled = false;
            llblShowLicInfo.Enabled = false;
            btnDetain.Enabled = false;

            lblDetainDate.Text = DateTime.Now.ToString("d");
            lblCretaedBy.Text = clsGlobal.CurrentUser.Username;

            if (_LicenseID == -1)
            {
                return;
            }
            //if got here that mean there already license ID 
            ctrlDriverInfoWithFilter1.FilterEnabled = false;
            ctrlDriverInfoWithFilter1.LoadData(_LicenseID);
            if(ctrlDriverInfoWithFilter1.SelectedLicenseInfo.IsDetained())
            {
                MessageBox.Show("This License is already Detained");
                return;
            }
            lblLicenseID.Text = ctrlDriverInfoWithFilter1.LicenseID.ToString();
            btnDetain.Enabled = !ctrlDriverInfoWithFilter1.SelectedLicenseInfo.IsDetained();
            llblShowLicHis.Enabled = true;

        }

        private void ctrlDriverInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;
            lblLicenseID.Text = _LicenseID.ToString();
            _License = clsLicenses.Find(_LicenseID);

            if(_License==null)
            {
                MessageBox.Show("Wrong License I");
           
                return;
            }
            llblShowLicHis.Enabled = true;
            if(!_License.IsActive)
            {
                MessageBox.Show("This License Is UnActive try anthor one");
                return;
            }
            if (_License.IsDetained())
            {
                MessageBox.Show("This Licenes Is already Detained ");
                return;
            }

            btnDetain.Enabled = true;
           
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if(txtFineFees.Text=="")
            {
                MessageBox.Show("Write Fine Fees Before Detained");
                return;
            }
            if(MessageBox.Show("Are you sure you want to detain this license","Confirmed",MessageBoxButtons.YesNo)==DialogResult.No)
            { return; }

            _DetainedID = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text),clsGlobal.CurrentUser.UserID);
            if(_DetainedID==-1)
            {
                MessageBox.Show("Failed to Detain");
                return;
            }

            lblDetainID.Text = _DetainedID.ToString();
            MessageBox.Show("Detained Succfully");

            btnDetain.Enabled = false;
            ctrlDriverInfoWithFilter1.FilterEnabled = false;
            llblShowLicInfo.Enabled = true;
            txtFineFees.Enabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
