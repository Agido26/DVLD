using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;
namespace DVLD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        clsLocalDrivingLicenseApplication Local;
        private void Form1_Load(object sender, EventArgs e)
        {
             Local=clsLocalDrivingLicenseApplication.FindByLocalLicenseID(38);
       
        
        
        
        
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            lblName.Text = Local.Person.FullName;
        }
    }
}
