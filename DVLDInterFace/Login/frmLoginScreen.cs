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
using System.Windows.Forms;

namespace DVLD.Login
{
    public partial class frmLoginScreen : Form
    {
      
        public frmLoginScreen()
        {
            InitializeComponent();
        }
        string RemeberMeFilePath = "C:\\Users\\DELL\\Desktop\\code\\Course 19\\DVLD Project\\DVLDInterface\\Login\\RemberMe.txt";

       private void SaveLoginInfo()
        {
            string RemberMe = tbUsername.Text+"\n"+tbPassword.Text;
            clsUtil.Writeinthefile(RemeberMeFilePath, RemberMe);
        }
        private bool CheckforRember()
        {

            if (string.IsNullOrEmpty(File.ReadAllText(RemeberMeFilePath)))
            {
                return false;
            }
            return true;
        }
          private void ReadUserInfoFromRemeberMeFile() 
        {
            if (CheckforRember())
            {
                string[] user = File.ReadAllLines(RemeberMeFilePath);
                
                tbUsername.Text = user[0];
                tbPassword.Text = user[1];
            } 
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
           clsUser User = clsUser.Find(tbUsername.Text, tbPassword.Text);
            if (User == null)
            {
                MessageBox.Show("UserName or Password was wrong pls try again");
                return;
            }

            if (!User.IsActive)
            {
                MessageBox.Show("This User is disActivte pls Contact your Admin");
                return;
            }

            if (cbRemeberme.Checked) { SaveLoginInfo(); }

            clsGlobal.CurrentUser = User;
            this.Hide();
            frmMain main = new frmMain(this);
            main.ShowDialog();
         
        }
        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            if(CheckforRember())
            {
                ReadUserInfoFromRemeberMeFile();
                cbRemeberme.Checked = true;
            }          
        }
        private void frmLoginScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!cbRemeberme.Checked)
            {
                File.WriteAllText(RemeberMeFilePath, "");
            }
        }
    }
}
