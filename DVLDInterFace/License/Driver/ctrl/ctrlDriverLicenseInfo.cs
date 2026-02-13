using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Driver.ctrl
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {

        int _LocalLicenseID;
        clsLicenses _LocalLicense;

        public int LicenseID { get { return _LocalLicenseID; } }
        public clsLicenses SelectedLicenseInfo { get { return _LocalLicense; } }
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void setImage()
        {
            
            if(_LocalLicense.Drivers.PersonInfo.Gendor==0)
            {
                pictureBox1.Image = Properties.Resources.Male_512;
            }
            else
                pictureBox1.Image = Properties.Resources.Female_512;

            string ImagePath = _LocalLicense.Drivers.PersonInfo.Image_Path;
            if (!string.IsNullOrEmpty(_LocalLicense.Drivers.PersonInfo.Image_Path))
            {
                if (File.Exists(ImagePath))
                {
                    pictureBox1.ImageLocation = _LocalLicense.Drivers.PersonInfo.Image_Path;
                    return;
                }
                else
                    MessageBox.Show("The Couldn't be found with " + ImagePath);
            }
        }
        public void LoadData(int LicenseID)
        {
            _LocalLicenseID = LicenseID;
            
            this._LocalLicense = clsLicenses.Find(LicenseID);
            if (this._LocalLicense == null)
            {
                MessageBox.Show("Wrong licenseID");
                return;
            }

            setImage();
            lblClass.Text = this._LocalLicense.LinceseClass.className;
            lblName.Text = this._LocalLicense.FullName;
           lblLicenseID.Text=_LocalLicense.LicenseID.ToString();
            lblNationalNo.Text = this._LocalLicense.Drivers.PersonInfo.NationalNo;
            lblGendor.Text = this._LocalLicense.Drivers.PersonInfo.GendorText;
            lblIssueDate.Text=_LocalLicense.IssueDate.ToString();
            lblIssueReason.Text=_LocalLicense.IssueReasonText;
            lblNote.Text = _LocalLicense.Notes==""?"No Note":_LocalLicense.Notes;
            lblIsActive.Text = _LocalLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = this._LocalLicense.Drivers.PersonInfo.DateOfBirth.ToString();
            lblDriverID.Text=_LocalLicense.DriverID.ToString();
            lblExpDate.Text=_LocalLicense.ExpirationDate.ToString();
            lblIsDetained.Text = _LocalLicense.IsDetained() ? "Yes" : "No";

        }
       
        
    }
}
