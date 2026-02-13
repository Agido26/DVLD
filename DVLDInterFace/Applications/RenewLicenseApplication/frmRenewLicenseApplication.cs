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

namespace DVLD.Applications.RenewLicenseApplication
{
   
    public partial class frmRenewLicenseApplication : Form
    {
        private int _NewLicenseID = -1;
        public frmRenewLicenseApplication()
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
            frmInternationalInfo internationalInfo = new frmInternationalInfo(ctrlDriverInfoWithFilter1.SelectedLicenseInfo.Drivers.PersonID);
            internationalInfo.ShowDialog();
        }

        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            llblShowLicInfo.Enabled = false;
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewLocalLicense).Fees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.Username;
            lblAppDate.Text = DateTime.Now.ToString("d");
            lblIssueDate.Text = DateTime.Now.ToString("d");

        }

        private void ctrlDriverInfoWithFilter1_OnLicenseSelected(int obj)
        {
            //This Event will fire only after find Licnese Class if not will pop License not found message

            int LicenseID = obj;
            clsLicenses License = clsLicenses.Find(LicenseID);
           

            lblOldLicenseID.Text = obj.ToString();
            llblShowLicHis.Enabled = (LicenseID != -1);
            lblLicenseFees.Text = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.LinceseClass.ClassFees.ToString();
            lblExpDate.Text = DateTime.Now.AddYears(License.LinceseClass.validLength).ToString("d");  
            lblTotalFees.Text = (decimal.Parse(lblApplicationFees.Text) + decimal.Parse(lblLicenseFees.Text)).ToString();
            txtNote.Text = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.Notes;
            if (!License.IsLicenseExpired())
            {
                MessageBox.Show("Licese Does not Expaird yet , will Expired in " + License.ExpirationDate.ToString("d"));
                btnRenew.Enabled = false;
                return;

            }
            if(!ctrlDriverInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Licese Does not Active" );
                btnRenew.Enabled = false;
                return;
            }

            btnRenew.Enabled = true;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are sure you want to renew this license?","Confirm",MessageBoxButtons.YesNo)==DialogResult.No)
            {
                return;
            }
            clsLicenses RenewLicese = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.RenewLicense(txtNote.Text,clsGlobal.CurrentUser.UserID);
            if(RenewLicese==null)
            {
                MessageBox.Show("Failed to save new License");
                return;
            }
            _NewLicenseID = RenewLicese.LicenseID;
            lblAppID.Text = RenewLicese.ApplicationID.ToString();
            lblRenewLicID.Text = RenewLicese.LicenseID.ToString();
            MessageBox.Show("Licesne has ben Renewed Succfully with ID = "+RenewLicese.LicenseID.ToString());
            btnRenew.Enabled = false;
            ctrlDriverInfoWithFilter1.FilterEnabled = false;
            llblShowLicInfo.Enabled = true;
        }
    }
}
