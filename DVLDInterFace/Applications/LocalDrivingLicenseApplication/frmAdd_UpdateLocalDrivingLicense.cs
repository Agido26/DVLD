using DVLD.Login;
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

namespace DVLD.LocalDrivingLicense
{
  
    public partial class frmAdd_UpdateLocalDrivingLicense : Form
    {
       
        enum enMode { New=1,Update=2}
        enMode Mode;
        int LocalDrivingLicenseApplicationID;
        clsLocalDrivingLicenseApplication _LocalDrivingApplication;
        
        

        public frmAdd_UpdateLocalDrivingLicense()
        {
            InitializeComponent();
            Mode = enMode.New;
        }

        public frmAdd_UpdateLocalDrivingLicense(int LocalDrivingLicenseApplication)
        {
            InitializeComponent();
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplication;
            Mode = enMode.Update;
        }

       

        private void FillComboBox()
        {
            var Classes = clsLinceseClasses.GetAllLincesClasses();

            cbLinceseClasses.DataSource = Classes;
            cbLinceseClasses.DisplayMember = "ClassName";
            cbLinceseClasses.ValueMember = "LicenseClassID";

        }

        private void LoadData()
        {
            _LocalDrivingApplication = clsLocalDrivingLicenseApplication.FindByLocalLicenseID(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingApplication == null)
            {
                MessageBox.Show("No Application with ID=" + LocalDrivingLicenseApplicationID.ToString());
                this.Close();
                return;
            }


            ctrlCardInfoWithFilter1.FilterEnable = false;
            ctrlCardInfoWithFilter1.LoadPersonData(_LocalDrivingApplication.PersonID);
            lblID.Text = _LocalDrivingApplication.LocalDrivingLicenseID.ToString();
            cbLinceseClasses.SelectedText = _LocalDrivingApplication.Licenseclass.className;
            lblFees.Text = _LocalDrivingApplication.PaidFees.ToString();
            lblDate.Text = _LocalDrivingApplication.ApplicationDate.ToString();
            lblCreatedBy.Text = _LocalDrivingApplication.User.Username;
        }
        private void Default()
        {
            FillComboBox();
            if (Mode == enMode.New)
            { lblMain.Text = "New Local Driving License Application"; }

            else lblMain.Text = "Update Local Driving License Application";
              
            
            ctrlCardInfoWithFilter1.ResetDefautValue();
            lblID.Text = "????";
            lblFees.Text = "????";
            lblDate.Text = "????";
            lblCreatedBy.Text = "????";
            tabPageApplication.Enabled = false;

        }
        private void frmLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            Default();
            if(Mode==enMode.New)
            {
                _LocalDrivingApplication = new clsLocalDrivingLicenseApplication();
                btnSave.Enabled = false;
            }
            if(Mode==enMode.Update)
            {
                LoadData();
            }
            
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlCardInfoWithFilter1.PersonInfo == null)
            {
                MessageBox.Show("Select Person first");
                return;
            }

            lblCreatedBy.Text = clsGlobal.CurrentUser.Username;
            lblDate.Text = DateTime.Now.ToString("d");
            if (Mode == enMode.New)
            {
                lblFees.Text = clsApplicationType.Find(1).Fees.ToString();
            }
            tabPageApplication.Enabled = true;
            tabControl1.SelectedTab = tabPageApplication;
            btnSave.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //is the person have new application
            int AppID = clsApplication.GetActiveApplicationIDForLicenseClass(ctrlCardInfoWithFilter1.PersonID, (int)cbLinceseClasses.SelectedValue, 1);
            if (AppID != -1)
            {
                MessageBox.Show($"This Person Has open Application with ID{AppID}");
                return;
            }
            if (clsLicenses.IsLicenseExistByPersonID(ctrlCardInfoWithFilter1.PersonID, (int)cbLinceseClasses.SelectedValue))
            {
                MessageBox.Show($"This Person already Has License ");
                return;
            }
            _LocalDrivingApplication.PersonID = ctrlCardInfoWithFilter1.PersonID;
            _LocalDrivingApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingApplication.ApplicationTypeID = 1;//New Local Driving Lincese
            _LocalDrivingApplication.ApplicationStatus = clsApplication.enStatus.enNew;
            _LocalDrivingApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingApplication.PaidFees = clsApplicationType.Find(1).Fees;
            _LocalDrivingApplication.UserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingApplication.LicenseClassID = (int)cbLinceseClasses.SelectedValue;
            if (_LocalDrivingApplication.Save())
            {

                lblID.Text = _LocalDrivingApplication.LocalDrivingLicenseID.ToString();
                Mode = enMode.Update;
                lblMain.Text = "Update Local Driving License Application";
                MessageBox.Show("Done!");
            }
            else { MessageBox.Show("Something went wrong"); return; }

        }
    }
}
