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
        int PersonID;
        public frmLicenseHistory(int PersonID)
        {
            InitializeComponent();
            this.PersonID = PersonID;
        }
        public frmLicenseHistory()
        {
            InitializeComponent();
        }



        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            if(PersonID==-1)
            {
                MessageBox.Show("No person found");
                return;
            }
           
                ctrlCardInfoWithFilter1.LoadPersonData(PersonID);
                ctrlCardInfoWithFilter1.FilterEnable = false;

                ctrlCardInfoWithFilter1.LoadPersonData(PersonID);
                ctrlDriverLicenses1.LoadInfoByPersonID(PersonID);
              
           
        }
    }
}
