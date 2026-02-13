using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.LocalDrivingLicense
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        int _LocalDrivingLicenseApplictionID;
        public frmLocalDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplictionID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplictionID=LocalDrivingLicenseApplictionID;
        }

        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlLocalLicenseInfo1.LoadInfo(_LocalDrivingLicenseApplictionID);
        }
    }
}
