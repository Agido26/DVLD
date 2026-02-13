using DVLD.Driver;
using DVLD.License;
using DVLD.License.InternationalLicense;
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

namespace DVLD.ReplaceLicense
{
    public partial class frmReplaceLicense : Form
    {
        private int _LicenseID = -1;
        private clsLicenses _License;
        public frmReplaceLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llblShowLicHis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory licenseHistory = new frmLicenseHistory(ctrlDriverInfoWithFilter1.SelectedLicenseInfo.Drivers.PersonID);
            licenseHistory.ShowDialog();
        }

        private void llblShowLicInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo internationalInfo = new frmDriverLicenseInfo(_LicenseID);
            internationalInfo.ShowDialog();
        }



        private int _GetApplicationTypeID()
       
            {
                if (rbDamged.Checked)
                {
                    return (int)clsApplicationType.enApplicationType.ReplacementForDamged;
                }
                else 
                {
                return (int)clsApplicationType.enApplicationType.ReplacementForLost;
            }
           
            }
        private clsLicenses.enIssueReason _GetIssueTypeID()

        {
            if (rbDamged.Checked)
            {
                return clsLicenses.enIssueReason.ReplacemenForDameged;
            }
            else
            {
                return clsLicenses.enIssueReason.ReplacementForLost;
            }

        }

        private void frmReplaceLicense_Load(object sender, EventArgs e)
        {
            btnIssue.Enabled = false;
            llblShowLicHis.Enabled = false;
            llblShowLicInfo.Enabled = false;
            rbDamged.Checked = true;
            lblAppDate.Text = DateTime.Now.ToString("d");
            
        }

        private void ctrlDriverInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int LicenseID = obj;
            lblOldLicID.Text = LicenseID.ToString();
            llblShowLicHis.Enabled = (LicenseID != -1);
            if (LicenseID == -1)
                return;

            if (!ctrlDriverInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("This License have been deactivated ,try anthor one");
                btnIssue.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;
        }

        
        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?","Confirm",MessageBoxButtons.YesNo)==DialogResult.No)
            { return; }

           clsLicenses NewLicense= ctrlDriverInfoWithFilter1.SelectedLicenseInfo.Replace(_GetIssueTypeID(),clsGlobal.CurrentUser.UserID);
            if(NewLicense==null)
            {
                MessageBox.Show("Faild");
                return;
            }

            LRAppID.Text = NewLicense.ApplicationID.ToString();
            lblReLicID.Text = NewLicense.LicenseID.ToString();
            lblCreatedBY.Text = clsGlobal.CurrentUser.Username;
            llblShowLicInfo.Enabled = true;
            _LicenseID = NewLicense.LicenseID;
            _License = clsLicenses.Find(_LicenseID);
            btnIssue.Enabled = false;
        }


        private void rbDamged_CheckedChanged(object sender, EventArgs e)
        {
            lblMain.Text = "Replacement for Damged License";
            lblAppFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).Fees.ToString();
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            lblMain.Text = "Replacement for Lost License";
            lblAppFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).Fees.ToString();
        }
    }
}
