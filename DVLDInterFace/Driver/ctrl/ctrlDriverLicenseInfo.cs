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
            _LocalLicense=clsLocalDrivingLicenseApplication.FindByLocalLicenseID(LocalLicenseID);
            if (_LocalLicense == null)
            {
                MessageBox.Show("Wrong licenseID");
                return;
            }
            lblClass.Text = _LocalLicense.Licenseclass.className;
            lblName.Text = _LocalLicense.FullName;
           

        }



    }
}
