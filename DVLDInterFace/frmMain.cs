using DVLD.LocalDrivingLicense;
using DVLD.Login;
using DVLD.ManageTestTypes;
using DVLD.MangeApplicationType;
using DVLD.People;
using DVLD.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        frmLoginScreen _LoginScreen;
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(frmLoginScreen login)
        {
            InitializeComponent();
            _LoginScreen = login;
        }


        private void tsmPeople_Click(object sender, EventArgs e)
        {
            frmManagePeople managePeople = new frmManagePeople();
            managePeople.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LoginScreen.Show();
            this.Close();
        }

        private void tsmUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers ManageUserScreen= new frmManageUsers();
            ManageUserScreen.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails frmUserDetails= new frmShowUserDetails(clsGlobal.CurrentUser.PersonID);
            frmUserDetails.ShowDialog();
        }

        private void ChangePasswordToolMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(clsGlobal.CurrentUser.PersonID);
            frmChangePassword.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangeApplicationTypes applicationTypes= new frmMangeApplicationTypes();
            applicationTypes.ShowDialog();

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _LoginScreen.Show();

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes testType=new frmManageTestTypes();
            testType.ShowDialog();
        }

        private void localTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateLocalDrivingLicense frmLocalDrivingLicense = new frmAdd_UpdateLocalDrivingLicense();
            frmLocalDrivingLicense.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangelocalDrivingLicense MangeLocalLincese = new frmMangelocalDrivingLicense();
            MangeLocalLincese.ShowDialog();
        }
    }
}
