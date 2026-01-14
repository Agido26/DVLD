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

namespace DVLD.User
{
    public partial class frmShowUserDetails : Form
    {
        clsUser _User;
       
        public frmShowUserDetails(int PersonID)
        {
            InitializeComponent();
            _User=clsUser.FindByPersonID(PersonID);
        }

        private void frmShowUserDetails_Load(object sender, EventArgs e)
        {
            ctrlUserLoginInfo1.Fill(_User.PersonID);
            controlPersonIfo1.LoadPersonData(_User.PersonID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
