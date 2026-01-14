using DVLD.People.Controls;
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
    public partial class frmChangePassword : Form
    {
        private clsUser _User;
        private int _PersonID;
        public frmChangePassword(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _User = clsUser.FindByPersonID(_PersonID);
            if (_User == null) 
            {
                MessageBox.Show("Somthing went wrong");
                return;
            }
           ctrlUserLoginInfo1.Fill(_PersonID);
            controlPersonIfo1.LoadPersonData(_PersonID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateNewPassword()
        {
            if(txtNewPassword.Text==txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "");
                return true;
            }
            else 
            {
                errorProvider1.SetError(txtConfirmPassword, "Password Doesn't match"); 
                return false; 
            }
        }
        private bool ValidateCurrentPassword()
        {
            if (_User.Password != txtCurrentPassword.Text)
            {
                errorProvider1.SetError(txtCurrentPassword, "Current password is wrong try again");
                return false;
            }
            else
                errorProvider1.SetError(txtCurrentPassword, "");return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateNewPassword()||!ValidateCurrentPassword())
            {
                return;
            }
            _User.Password= txtNewPassword.Text;
          if(_User.Save())
            {
                MessageBox.Show("Saved Succefully");
                this.Close();
            }
          else
                MessageBox.Show("Some thing wnet wrong");


        }
    }
}
