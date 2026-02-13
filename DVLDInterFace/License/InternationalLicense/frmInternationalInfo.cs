using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.License.InternationalLicense
{
    public partial class frmInternationalInfo : Form
    {
        int PersonID;

        public frmInternationalInfo(int PersonID)
        {
            InitializeComponent();
            this.PersonID= PersonID;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInternationalInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseInfo1.LoadData(PersonID);
            
        }
    }
}
