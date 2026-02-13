using DVLD.People;
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

namespace DVLD.LocalDrivingLicense.ctrl
{
    public partial class ctrlApplicationInfo : UserControl
    {
        clsApplication App;
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }
        public bool LoadInfo(int ApplicationID)
        {
             App = clsApplication.FindBase(ApplicationID);
            if (App != null)
            {
                lblID.Text=App.ApplicationID.ToString();
                switch(App.ApplicationStatus)
                { 
                    case clsApplication.enStatus.enNew:
                        lblStatus.Text = "New";
                        break;
                    case clsApplication.enStatus.enCompleted:
                        lblStatus.Text = "Completed";
                        break;
                    case clsApplication.enStatus.enCancelled:
                        lblStatus.Text = "Cancelled";
                        break;

                }
               
                
                lblFees.Text=App.PaidFees.ToString();
                lblType.Text = App.ApplicationType.Title;
                lblApplicant.Text = App.Person.FullName;
                lblDate.Text = App.ApplicationDate.ToString("d");
                lblStatusDate.Text = App.LastStatusDate.ToString("d");
                lblCretedBy.Text = App.User.Username;
                return true;
            }
            return false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo personInfo = new frmShowPersonInfo(App.PersonID);
            personInfo.ShowDialog();
        }
    }
}
