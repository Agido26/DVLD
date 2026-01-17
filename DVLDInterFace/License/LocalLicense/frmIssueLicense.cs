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

namespace DVLD.Driver
{
    public partial class frmIssueLicense : Form
    {
        private int _LocalLicenseID;
        private clsLocalDrivingLicenseApplication _LocalLicense;
        public frmIssueLicense(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _LocalLicenseID = LocalDrivingLicenseID;
        }
    
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDriverList_Load(object sender, EventArgs e)
        {   
            _LocalLicense = clsLocalDrivingLicenseApplication.FindByLocalLicenseID(_LocalLicenseID);

            if (_LocalLicense==null)
            {
                MessageBox.Show("Local Licnese Couldn't be found");
                this.Close();
                return;
            }

            if (!_LocalLicense.PassedAllTests())
            {
                MessageBox.Show("Can't continue bec he didn't pass all exams");
                this.Close();
                return;
            }
            int LicenseID = _LocalLicense.GetActiveLicenseID();
            if (LicenseID != -1)
            {
                MessageBox.Show("This person already has Licesne with ID" + LicenseID);
                this.Close();
                return;
            }
            ctrlLocalLicenseInfo1.LoadInfo(_LocalLicenseID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicneseID = _LocalLicense.IssueLicenseForFirstTime(txtNote.Text,clsGlobal.CurrentUser.UserID);
            
            if(LicneseID !=-1)
            {
                MessageBox.Show($"Saved With License ID : {LicneseID}");
                this.Close();
            }
            else { MessageBox.Show("License was not Issues"); }

        }
    }
}
