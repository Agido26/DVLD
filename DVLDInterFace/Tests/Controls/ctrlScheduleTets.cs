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

namespace DVLD.Tests.Controls
{
    public partial class ctrlScheduleTets : UserControl
    {
        public ctrlScheduleTets()
        {
            InitializeComponent();
        }

        public enum enMode { Addnew=0,Update=1}
        private enMode _Mode= enMode.Addnew;
        public enum enCreationMode { FirstTimeSchedule=1, RetakeTest=2}
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private int _LocalDrivingLicenseApplicationID=-1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _TestAppointmentID;
        private clsTestAppointment _TestAppointment;
        private clsTestTypes.enTestType _TestTypeID= clsTestTypes.enTestType.VisionTest;
       

       
        public clsTestTypes.enTestType TestTypeID
        {
        get { return _TestTypeID; }
            set 
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        gbScheduleTest.Text = "Vision Test";
                        pictureBox1.Image = Properties.Resources.Vision_512;
                        break;

                    case clsTestTypes.enTestType.WrittenTest:
                        gbScheduleTest.Text = "Written Test";
                        pictureBox1.Image = Properties.Resources.Written_Test_512;
                        break;

                    case clsTestTypes.enTestType.StreetTest:
                        gbScheduleTest.Text = "Street Test";
                        pictureBox1.Image = Properties.Resources.driving_test_512;
                        break;
                }
            }
        
        }


        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            //if no appointment id this means AddNew mode otherwise it's update mode.
            if (AppointmentID == -1)
                _Mode = enMode.Addnew;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            //decide if the createion mode is retake test or not based if the person attended this test before
            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))

                _CreationMode = enCreationMode.RetakeTest;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;


            if (_CreationMode == enCreationMode.RetakeTest)
            {
                lblRAppFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).Fees.ToString();
                gbRetakeTest.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRTestAppID.Text = "0";
            }
            else
            {
                gbRetakeTest.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRAppFees.Text = "0";
                lblRTestAppID.Text = "N/A";
            }

            lblDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseID.ToString();
            lblDClass.Text = _LocalDrivingLicenseApplication.Licenseclass.className;
            lblName.Text = _LocalDrivingLicenseApplication.FullName;

            //this will show the trials for this test before  
            lblTrail.Text = _LocalDrivingLicenseApplication.TotalTrailsPerTest((int)_TestTypeID).ToString();


            if (_Mode == enMode.Addnew)
            {
                lblFees.Text = clsTestTypes.Find(_TestTypeID).Fees.ToString();
                dtpDate.MinDate = DateTime.Now;
                lblRTestAppID.Text = "N/A";

                _TestAppointment = new clsTestAppointment();
            }

            else
            {

                if (!_LoadTestAppointmentData())
                    return;
            }


            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRAppFees.Text)).ToString();


            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePrviousTestConstraint())
                return;



        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment=clsTestAppointment.FindTestAppointmentByID(_TestAppointmentID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Test Appointment was found");
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text=_TestAppointment.PaidFees.ToString();

            if(DateTime.Compare(DateTime.Now,_TestAppointment.AppointmentDate)<0)
                dtpDate.MinDate=DateTime.Now;
            else
                dtpDate.MinDate=_TestAppointment.AppointmentDate;

            dtpDate.Value = _TestAppointment.AppointmentDate;

            if (_TestAppointment.ReTakeTestApplicationID == -1)
            {
                lblRAppFees.Text = "0";
                lblRTestAppID.Text = "[N/A]";
            }

            else
            {
                lblRAppFees.Text = _TestAppointment.RetakeAppInfo.PaidFees.ToString();
                gbRetakeTest.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRTestAppID.Text = _TestAppointment.ReTakeTestApplicationID.ToString();

            }
            return true;
        }
        private bool _HandleActiveTestAppointmentConstraint()
        {
            if(_Mode==enMode.Addnew && clsLocalDrivingLicenseApplication.IsThereActiveTestAppointment(_LocalDrivingLicenseApplicationID,(int)_TestTypeID))
            {
                lblShowUserMessage.Text = "This Person has already have active appointment, Appointment Lock";
                lblShowUserMessage.Visible = true;
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }
            return true;
        }
        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointment.IsLocked)
            {
                lblShowUserMessage.Visible = true;
                lblShowUserMessage.Text = "This Person has already set for test, Appointment Lock";
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }
            else
                lblShowUserMessage.Visible = false;

            return true;
        }
        private bool _HandlePrviousTestConstraint()
        {
            switch(_TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    lblShowUserMessage.Visible = false;
                    return true;
                case clsTestTypes.enTestType.WrittenTest:

                    if(!_LocalDrivingLicenseApplication.DoesPassTestType((int)clsTestTypes.enTestType.VisionTest))
                    {
                        lblShowUserMessage.Text = "Cannot Schdeule Vision Test should be passed first";
                        lblShowUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblShowUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                    }
                        return true;

                case clsTestTypes.enTestType.StreetTest:

                    if (!_LocalDrivingLicenseApplication.DoesPassTestType((int)clsTestTypes.enTestType.WrittenTest))
                    {
                        lblShowUserMessage.Text = "Cannot Schdeule Written Test should be passed first";
                        lblShowUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpDate.Enabled = false;
                        return false;
                    }
                    else
                    {

                        lblShowUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                       
                    }
                    return true;

            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
                return;

            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseID = _LocalDrivingLicenseApplication.LocalDrivingLicenseID;
            _TestAppointment.AppointmentDate = dtpDate.Value;
            _TestAppointment.PaidFees = Convert.ToDecimal(lblFees.Text);
            _TestAppointment.CreatByUserID = clsGlobal.CurrentUser.UserID;
            if(_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data saved succefully");
            }
            else
                MessageBox.Show("Error: Data is not saved succefully");
        }
        private bool _HandleRetakeApplication()
        {
            if(_Mode==enMode.Addnew && _CreationMode==enCreationMode.RetakeTest)
            {
                clsApplication Application=new clsApplication();
                Application.PersonID = _LocalDrivingLicenseApplication.PersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)clsApplicationType.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplication.enStatus.enCompleted;
                Application.LastStatusDate=DateTime.Now;
                Application.PaidFees = (int)clsApplicationType.Find((int)clsApplicationType.enApplicationType.RetakeTest).Fees;
                Application.UserID=clsGlobal.CurrentUser.UserID;

                if(!Application.Save())
                {
                    _TestAppointment.ReTakeTestApplicationID = -1;
                    MessageBox.Show("Failed To create application");
                    return false;
                }
                _TestAppointment.ReTakeTestApplicationID = Application.ApplicationID;
            }
            return true;
        }
    }
}
