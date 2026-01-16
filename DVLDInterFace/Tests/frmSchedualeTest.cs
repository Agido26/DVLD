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
using static DVLD_Business.clsTestTypes;

namespace DVLD.Tests
{
    public partial class frmSchedualeTest : Form
    {
        int _LocalLicneseID = -1;
        clsTestTypes.enTestType _TestType= clsTestTypes.enTestType.VisionTest;
        int _AppointmentID = -1;
        public frmSchedualeTest(int LocalLicenseID, clsTestTypes.enTestType TestType,int AppoinmentID=-1)
        {
            InitializeComponent();
            _LocalLicneseID = LocalLicenseID;
            _AppointmentID = AppoinmentID;
            _TestType = TestType;
        }

        private void SchedualeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTets1.TestTypeID = _TestType;
            ctrlScheduleTets1.LoadInfo(_LocalLicneseID, _AppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
