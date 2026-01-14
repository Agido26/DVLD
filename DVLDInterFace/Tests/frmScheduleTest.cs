using DVLD.Login;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests.VisionTest
{
    public partial class frmScheduleTest : Form
    {
        enum enMode { enAdd=1, enUpdate=2,Retake=3}
        enMode _Mode;
        int LicenseID;
        clsLocalDrivingLicenseApplication _Local;

        int TestAppID;
        clsTestAppointment TestAppoinment ;
        clsApplicationType.enApplicationType ApplicationType;
        clsTestTypes.enTestType TestTypeID;
        public frmScheduleTest(int LocaLicenseID,clsTestTypes.enTestType testTypeid)
        {
            InitializeComponent();
            this.LicenseID = LocaLicenseID;
            
            this.TestTypeID = testTypeid;
            _Mode = enMode.enAdd;
        }
        public frmScheduleTest(int TestAppointmentID)
        {

            InitializeComponent();
            this.TestAppID = TestAppointmentID;
            TestTypeID=(clsTestTypes.enTestType)clsTestAppointment.FindTestAppointmentByID(TestAppointmentID).TestTypeID;
            
            _Mode = enMode.enUpdate;
        }
        public frmScheduleTest(int LocaLicenseID, clsTestTypes.enTestType testTypeid, clsApplicationType.enApplicationType AppType)
        {
            InitializeComponent();
            this.LicenseID = LocaLicenseID;
            TestTypeID = testTypeid;
            ApplicationType = AppType;
            _Mode = enMode.Retake;
        }
        void GroupBoxText()
        {

            switch (TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    this.Name = "Vision Test";
                    groupBox1.Text = "Vesion Test";
                    pictureBox1.Image = Properties.Resources.Vision_512;
                    break;

                case clsTestTypes.enTestType.WrittenTest:
                    groupBox1.Text = "Written Test";
                    this.Name = "Written Test";
                    pictureBox1.Image = Properties.Resources.Written_Test_512;
                    break;

                case clsTestTypes.enTestType.StreetTest:
                    this.Name = "Street Test";
                    groupBox1.Text = "Street Test";
                    pictureBox1.Image = Properties.Resources.driving_test_512;
                    break;
            }
        }
        
        void LoadData()
        {
            decimal TestFees;
            if (_Mode == enMode.enAdd)
            {
                
                lblDLAppID.Text = _Local.LocalDrivingLicenseID.ToString();
                lblDClass.Text = _Local.Licenseclass.className;
                lblName.Text = _Local.FullName;
                lblTrail.Text = clsTestAppointment.CountTrailsByLocalID(LicenseID, (int)TestTypeID).ToString();
                dtpDate.Text = DateTime.Now.ToString("d");

                 TestFees = clsTestTypes.Find(TestTypeID).Fees;
                lblFees.Text = TestFees.ToString();
                ctrlRetakeTest1.DefaultValue();
                ctrlRetakeTest1.TotalFees=(int)TestFees;
                ctrlRetakeTest1.Enable = false;


            }
            if (_Mode == enMode.enUpdate)
            {
                lblDLAppID.Text = TestAppoinment.LocalDrivingLicenseID.ToString();
                lblDClass.Text = TestAppoinment.LocalDrivingLicense.Licenseclass.className;
                lblName.Text = TestAppoinment.LocalDrivingLicense.FullName;
                lblTrail.Text = TestAppoinment.CountTrails().ToString();
                dtpDate.Text = TestAppoinment.AppointmentDate.ToString();

                 TestFees = TestAppoinment.TestTypes.Fees;
                lblFees.Text = TestFees.ToString();
                ctrlRetakeTest1.Enable = true;
                
                if(TestAppoinment.ReTakeTestApplicationID==-1)
                {
                    ctrlRetakeTest1.ReTakeAppID = -1;
                    ctrlRetakeTest1.RetakeFees = 0;
                }
                else 
                {
                    ctrlRetakeTest1.ReTakeAppID = TestAppoinment.ReTakeTestApplicationID;
                    ctrlRetakeTest1.RetakeFees = 0;
                }
            }
            if(_Mode==enMode.Retake)
            {
                label1.Text = "Schdual Retake Test";
                lblDLAppID.Text = _Local.LocalDrivingLicenseID.ToString();
                lblDClass.Text = _Local.Licenseclass.className;
                lblName.Text = _Local.FullName;
                lblTrail.Text = clsTestAppointment.CountTrailsByLocalID(LicenseID, (int)TestTypeID).ToString();
                dtpDate.Text = DateTime.Now.ToString("d");
                 TestFees = clsTestTypes.Find(TestTypeID).Fees;
                lblFees.Text = TestFees.ToString();

                ctrlRetakeTest1.RetakeFees = (int)clsApplicationType.Find((int)ApplicationType).Fees;
                ctrlRetakeTest1.TotalFees =(int)(TestFees + ctrlRetakeTest1.RetakeFees);
                
            }
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
           
            GroupBoxText();
            if (_Mode == enMode.enAdd|| _Mode == enMode.Retake)
            {
                TestAppoinment = new clsTestAppointment();
                _Local = clsLocalDrivingLicenseApplication.FindByLocalLicenseID(this.LicenseID);
                if (_Local == null) { MessageBox.Show("Local License Couldn't be found"); this.Close(); return; }
                LoadData();
            }

            if (_Mode==enMode.enUpdate)
            { 
                TestAppoinment=clsTestAppointment.FindTestAppointmentByID(this.TestAppID);
                if (TestAppoinment == null) { MessageBox.Show("Test Appointment Couldn't be found"); this.Close(); return; }

                LoadData();
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ApplicationType==clsApplicationType.enApplicationType.RetakeTest)
            {
                clsApplication newApp = new clsApplication();
                newApp.PersonID= TestAppoinment.LocalDrivingLicense.PersonID;
                newApp.ApplicationDate = DateTime.Now;
                newApp.ApplicationTypeID = (int)ApplicationType;
                newApp.ApplicationStatus= TestAppoinment.LocalDrivingLicense.ApplicationStatus;
                newApp.LastStatusDate= DateTime.Now;
                newApp.PaidFees = clsApplicationType.Find((int)ApplicationType).Fees;
                newApp.UserID=clsGlobal.CurrentUser.UserID;
                if(newApp.Save())
                {
                    MessageBox.Show("Done");
                    TestAppoinment.ReTakeTestApplicationID = newApp.ApplicationID;

                }
                else { MessageBox.Show("Somethin went wrong in save new app"); }
                

            }
            TestAppoinment.TestTypeID = (int)TestTypeID;
            TestAppoinment.LocalDrivingLicenseID = int.Parse(lblDLAppID.Text);
            TestAppoinment.AppointmentDate=dtpDate.Value;
            TestAppoinment.PaidFees = clsTestTypes.Find(TestTypeID).Fees;
            TestAppoinment.CreatByUserID=clsGlobal.CurrentUser.UserID;
            TestAppoinment.IsLocked = false;
            if(TestAppoinment.Save())
            {
                MessageBox.Show("Done");
            }
            else { MessageBox.Show("Faild"); }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
