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

namespace DVLD.License
{
    public partial class frmLicenseHistory : Form
    {
        int _LocalLicenseID;
        public frmLicenseHistory(int localLicenseID)
        {
            InitializeComponent();
            _LocalLicenseID = localLicenseID;
        }

        void fitDataGridView()
        {
            



        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {

            clsLocalDrivingLicenseApplication Local = clsLocalDrivingLicenseApplication.FindByLocalLicenseID(_LocalLicenseID);
            if (Local == null)
            {
                MessageBox.Show("Something wnet wrong");
                this.Close();
                return;
                
            }
            ctrlCardInfoWithFilter1.LoadPersonData(Local.PersonID);
            int LicenseID = Local.GetActiveLicenseID();   
            clsLicenses License=clsLicenses.Find(LicenseID);
            if (License != null)
            {
                
                dgvLocalDriver.DataSource = License.GetDriver();
                dgvInternationalLicense.DataSource = License.GetIntrnationalDriver();

            }

            

        }
    }
}
