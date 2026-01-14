using DVLD.People.People_Controls;
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

namespace DVLD.Login
{
    public partial class ctrlUserLoginInfo : UserControl
    {
        clsUser _User;
        public ctrlUserLoginInfo()
        {
            InitializeComponent();
        }

        public void Fill(int PersonID)
        {
            _User=clsUser.FindByPersonID(PersonID);

            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.Username;

            if (_User.IsActive)
                lblIsActive.Text = "Yes";

            else
                lblIsActive.Text = "No";
        }

        private void ctrlUserLoginInfo_Load(object sender, EventArgs e)
        {
            
        }
    }
}
