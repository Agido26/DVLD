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

namespace DVLD.LocalDrivingLicense.ctrl
{
    public partial class ctrlLocalLicenseInfo : UserControl
    {
        clsLocalDrivingLicenseApplication _local;
        
        int _LiceseID;
        int _LocalDrivingLicenseApplicationID = -1;
        public int LocalDrivingLicenseApplicationID { get { return _LocalDrivingLicenseApplicationID; } }
        public ctrlLocalLicenseInfo()
        {
            InitializeComponent();
        }

        public bool LoadInfo(int LocalApplicationID)
        {
            _local = clsLocalDrivingLicenseApplication.FindByLocalLicenseID(LocalApplicationID);
            _LiceseID =_local.GetActiveLicenseID();

            if (_local != null) 
            { 
                ctrlApplicationInfo1.LoadInfo(_local.ApplicationID);
            
            lblDLAppID.Text = LocalApplicationID.ToString();
            lblLicenseName.Text = _local.Licenseclass.className;
                int PassTests = clsLocalDrivingLicenseApplication.GetPassedTests(LocalApplicationID);
                lblPassedTests.Text=PassTests.ToString()+"/3";

                
                    llblShowLicenseInfo.Enabled = _LiceseID!=-1;
                
            }


            
                return false;
        }

        public void EnableShowInfo(bool ShowInfo)
        {
            llblShowLicenseInfo.Enabled = ShowInfo;
        }
    }
}
