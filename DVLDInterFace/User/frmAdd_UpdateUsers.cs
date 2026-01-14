using DVLD.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmAdd_UpdateUsers : Form
    {
        enum enMode { enAdd=0, enUpdate=1}
        enMode _Mode=enMode.enAdd; 
        clsUser _User;
        int PersonID;
        public frmAdd_UpdateUsers()
        {
            InitializeComponent();
            _Mode=enMode.enAdd;

        }
        public frmAdd_UpdateUsers(int PersonID)
        {
            InitializeComponent();
            this.PersonID=PersonID;
            _Mode = enMode.enUpdate;
        }
      
        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (ctrlCardInfoWithFilter2.PersonInfo == null)
            { MessageBox.Show("You need Person to add new user");return; }
            
            if(clsUser.FindByPersonID(ctrlCardInfoWithFilter2.PersonID)!=null)
            { MessageBox.Show("This Person is already User"); return; }
            
            tabControl1.SelectedIndex=1;
            
            btnNext.Visible = false;
        }

        private bool ValidatePassword()
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Doesn't match the password");
                return false;
            }
           else
                { errorProvider1.SetError(txtConfirmPassword, ""); return true; }

        }

        private bool validateChildren()
        {
            foreach (System.Windows.Forms.Control control in LoginPage.Controls)
            {
                if (control is TextBox)
                {
                    if (control.Text == "")
                    {
                        errorProvider1.SetError(control, "Cant be empty");
                        return false;
                    }

                    errorProvider1.SetError(control, "");
                }

            }
            
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

           if(!ValidatePassword() || !validateChildren())
            {
                return;
            }
           _User.Username= txtUsername.Text;
            _User.Password= txtPassword.Text;
            _User.IsActive = checkBox1.Checked;
            _User.PersonID = ctrlCardInfoWithFilter2.PersonID;
            if(_User.Save())
            {
                MessageBox.Show("Done Succefully");
                lblUserID.Text=_User.UserID.ToString();
            }
            else { MessageBox.Show("Somthing went wrong"); }
        }
        private void textbox_Validating(object sender, CancelEventArgs e)
        {
           var textbox=sender as TextBox;

            if(textbox.Text == "")
            {
                errorProvider1.SetError(textbox, "Can't be Empty");
                e.Cancel=true;
            }
            errorProvider1.SetError(textbox, "");
            e.Cancel = false;
        }

        private void LoadUser()
        {
            _User = clsUser.FindByPersonID(PersonID);
            if(_User == null)
            { MessageBox.Show("Somthing went wrong");return; }

            ctrlCardInfoWithFilter2.LoadPersonData(PersonID);

            lblUserID.Text = _User.UserID.ToString();
            txtUsername.Text=_User.Username;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            checkBox1.Checked = _User.IsActive;
            
        }
        private void ResetToDefault()
        {
            ctrlCardInfoWithFilter2.ResetDefautValue();
            lblUserID.Text = "????";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            checkBox1.Checked = false;
           
        }
       
       
        private void frmAdd_UpdateUsers_Load(object sender, EventArgs e)
        {
            ResetToDefault();
           

            if (_Mode == enMode.enUpdate)
              { lblFormStatus.Text = "Update User Info";
                LoginPage.Enabled=true;
            }

            if (_Mode == enMode.enAdd)
               {
                lblFormStatus.Text = "Add New User";
                _User=new clsUser();
                LoginPage.Enabled = false;

            }

            if (_Mode == enMode.enUpdate) 
            {
                LoadUser();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
