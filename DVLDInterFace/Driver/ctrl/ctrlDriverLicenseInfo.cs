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

namespace DVLD.Driver.ctrl
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {

        int _LocalLicenseID;
        clsLocalDrivingLicenseApplication _LocalLicense;
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }


        public void LoadData(int LocalLicenseID)
        {
            _LocalLicenseID = LocalLicenseID;
            
            _LocalLicense =clsLocalDrivingLicenseApplication.FindByLocalLicenseID(LocalLicenseID);
            if (_LocalLicense == null)
            {
                MessageBox.Show("Wrong licenseID");
                return;
            }
            int LicID = _LocalLicense.GetActiveLicenseID();
            if (LicID == -1)
            {
                MessageBox.Show("Wrong");
                return;
            }
            clsLicenses License=clsLicenses.Find(LicID);
            lblClass.Text = _LocalLicense.Licenseclass.className;
            lblName.Text = _LocalLicense.FullName;
           lblLicenseID.Text=License.LicenseID.ToString();
            lblNationalNo.Text = _LocalLicense.Person.NationalNo;
            lblGendor.Text = _LocalLicense.Person.GendorText;
            lblIssueDate.Text=License.IssueDate.ToString();
            lblIssueReason.Text=License.IssueReasonText;
            lblNote.Text = License.Notes;
            lblIsActive.Text = License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text=_LocalLicense.Person.DateOfBirth.ToString();
            lblDriverID.Text=License.DriverID.ToString();
            lblExpDate.Text=License.ExpirationDate.ToString();
            lblIsDetained.Text = License.IsDetained() ? "Yes" : "No";

        }



    }
}
