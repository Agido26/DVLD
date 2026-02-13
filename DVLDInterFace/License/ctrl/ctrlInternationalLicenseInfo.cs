using DVLD_Buisness;
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

namespace DVLD.License.ctrl
{
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        private int _PersonID;
        
        private clsDriver _Driver;
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void _SetPersonImage()
        {
            if(_Driver.PersonInfo.Image_Path=="")
            {
                if(_Driver.PersonInfo.GendorText=="Male")
               { pictureBox1.Image = Properties.Resources.Male_512; }
                else if (_Driver.PersonInfo.GendorText == "Female")
                { pictureBox1.Image = Properties.Resources.Female_512; }

               
                

            }
            else if (_Driver.PersonInfo.Image_Path != "")
            {
                string path = _Driver.PersonInfo.Image_Path;
                if (!File.Exists(path))
                {
                    MessageBox.Show("There no image in" + path);
                }
                pictureBox1.ImageLocation = _Driver.PersonInfo.Image_Path;
            }
        }
    

    public bool LoadData(int PersonID)
        {
            _PersonID = PersonID;
            _Driver = clsDriver.FindDriverByPersonID(_PersonID);
            int InternationalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(_Driver.DriverID);
            clsInternationalLicense InternationalLicense = clsInternationalLicense.Find(InternationalLicenseID);
            if(InternationalLicense == null)
            { MessageBox.Show("No Licnes founded"); return false; }
            lblName.Text = _Driver.PersonInfo.First_Name;
            lblIntLicID.Text= InternationalLicense.InternationalLicenseID.ToString();
            lblDriverID.Text = _Driver.DriverID.ToString();
            lblLicenseID.Text = InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = InternationalLicense.DriverInfo.PersonInfo.GendorText;
            lblIssueDate.Text = InternationalLicense.IssueDate.ToString();
            lblAppID.Text = InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = InternationalLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToString();
            lblExpDate.Text = InternationalLicense.ExpirationDate.ToString();
            _SetPersonImage();
            return true;
        }
    
    }
}
