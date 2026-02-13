using DVLD.Driver;
using DVLD.License;
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

namespace DVLD.Applications.ReleaseDetainLicenseApplication
{
    
    public partial class frmReleaseDetainedLicenes : Form
    {
        private int _LicenseID = -1;
        public frmReleaseDetainedLicenes()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicenes(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
            ctrlDriverInfoWithFilter1.LoadData(LicenseID);
            ctrlDriverInfoWithFilter1.FilterEnabled = false;
            btnRelease.Enabled = true;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDriverInfoWithFilter1_OnLicenseSelected(int obj)
        {

            _LicenseID = obj;
            llblShowLicHis.Enabled = (_LicenseID != -1);
            if(_LicenseID==-1)
            {
                return;
            }
            if(!ctrlDriverInfoWithFilter1.SelectedLicenseInfo.IsDetained())
            {
                MessageBox.Show("License is not detained");
                return;
            }

            lblAppFees.Text = clsApplicationType.Find((int)clsApplicationType.enApplicationType.ReleaseDetained).Fees.ToString();
            lblCretaedBy.Text = clsGlobal.CurrentUser.Username;

            lblDetainID.Text = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.DetainInfo.DetainID.ToString();
            lblLicenseID.Text = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
            lblDetainDate.Text = DateTime.Now.ToString("d");
            lblFineFees.Text = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.DetainInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblFineFees.Text) + Convert.ToSingle(lblAppFees.Text)).ToString();
            btnRelease.Enabled = true;
        }

        private void frmReleaseDetainedLicenes_Load(object sender, EventArgs e)
        {
          
            llblShowLicInfo.Enabled = false;
          


        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to realease","Confirm",MessageBoxButtons.YesNo)==DialogResult.No)
            { return; }

            int AppID = -1;
            bool isreleased = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID,ref AppID);
            if(!isreleased)
            {
                MessageBox.Show("Faild to release");
                return;
            }
            MessageBox.Show("Done Released");
            lblAppID.Text = AppID.ToString();
            btnRelease.Enabled = false;
            ctrlDriverInfoWithFilter1.FilterEnabled = false;
            llblShowLicInfo.Enabled = true;

        }
    }
}
