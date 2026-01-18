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
    public partial class frmDriverInfo : Form
    {
        int _LocalLicenseID;
        public frmDriverInfo(int LocalLicenseID)
        {
            InitializeComponent();
            _LocalLicenseID = LocalLicenseID;
        }

      

        private void frmDriverInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoadData(_LocalLicenseID); 
        }
    }
}
