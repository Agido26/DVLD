using DVLD.License;
using DVLD.License.InternationalLicense;
using DVLD.Login;
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

namespace DVLD.Applications.InternationalLicense
{
    public partial class frmNewInternationalLicense : Form
    {
        private int _InternationalLiceseID=-1;
        private clsInternationalLicense _InternationalLicenseInfo;
        public frmNewInternationalLicense()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void ctrlDriverInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblLoclLicenseID.Text = SelectedLicenseID.ToString();
            llblShowLicHis.Enabled = (SelectedLicenseID != -1);
            if(SelectedLicenseID==-1)
            {
                return;
            }

            if(ctrlDriverInfoWithFilter1.SelectedLicenseInfo.LicenseClassID!=3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error); btnIssue.Enabled = false;
                btnIssue.Enabled = false;
                return;
            }

            int ActiveInternationalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlDriverInfoWithFilter1.SelectedLicenseInfo.DriverID);
            if (ActiveInternationalLicenseID != -1)
            {
                MessageBox.Show("Person Already have and Active International License ");
                _InternationalLiceseID = ActiveInternationalLicenseID;
                llblShowLicInfo.Enabled = true;
                btnIssue.Enabled = false;
                _InternationalLicenseInfo = clsInternationalLicense.Find(ActiveInternationalLicenseID);
                return;

            }
            btnIssue.Enabled = true;

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(ctrlDriverInfoWithFilter1.SelectedLicenseInfo==null)
                { return; }
            if(MessageBox.Show("Are you sure you want to issue the License?","Confirm",MessageBoxButtons.YesNo)==DialogResult.No)
            {
                return;
            }

            clsInternationalLicense internationalLicense=new clsInternationalLicense();
            internationalLicense.PersonID = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.Drivers.PersonID;
            internationalLicense.ApplicationDate = DateTime.Now;
            internationalLicense.ApplicationStatus = clsApplication.enStatus.enCompleted;
            internationalLicense.LastStatusDate = DateTime.Now;
            internationalLicense.PaidFees = clsApplicationType.Find((int)clsApplicationType.enApplicationType.NewLocalDrivingLicense).Fees;
            internationalLicense.UserID = clsGlobal.CurrentUser.UserID;

            internationalLicense.DriverID = ctrlDriverInfoWithFilter1.SelectedLicenseInfo.DriverID;
            internationalLicense.IssuedUsingLocalLicenseID = ctrlDriverInfoWithFilter1.LicenseID;
            internationalLicense.IssueDate = DateTime.Now;
            internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            
            if(!internationalLicense.Save())
            {
                MessageBox.Show("Failed");
                return;
            }

            lblILAppID.Text = internationalLicense.ApplicationID.ToString();
            _InternationalLiceseID = internationalLicense.InternationalLicenseID;
            lblILLicenseID.Text = internationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + _InternationalLiceseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssue.Enabled = false;
            ctrlDriverInfoWithFilter1.FilterEnabled = false;
            llblShowLicInfo.Enabled = true;



        }

        private void llblShowLicHis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory licenseHistory = new frmLicenseHistory(ctrlDriverInfoWithFilter1.SelectedLicenseInfo.Drivers.PersonID);
            licenseHistory.ShowDialog();
        }

        private void frmInternationalLicense_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = DateTime.Now.ToString("d");
            lblIssueDate.Text = lblAppDate.Text;
            lblEXPDate.Text = DateTime.Now.AddYears(1).ToString("d");//add one year.
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.InternationalLicense).Fees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.Username;

        }

        private void llblShowLicInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalInfo internationalInfo = new frmInternationalInfo(ctrlDriverInfoWithFilter1.SelectedLicenseInfo.Drivers.PersonID);
            internationalInfo.ShowDialog();
        }
    }
}
