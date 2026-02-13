using DVLD.Properties;
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
using static DVLD_Business.clsTestTypes;

namespace DVLD.Tests.Controls
{
    public partial class ctrlSchdeuledTest : UserControl
    {
        public ctrlSchdeuledTest()
        {
            InitializeComponent();
        }
        private clsTestTypes.enTestType _TestTypeID;
        private int _TestID = -1;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public clsTestTypes.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case clsTestTypes.enTestType.VisionTest:
                        {
                            groupBox1.Text = "Vision Test";
                            pictureBox1.Image = Resources.Vision_512;
                            break;
                        }

                    case clsTestTypes.enTestType.WrittenTest:
                        {
                            groupBox1.Text = "Written Test";
                            pictureBox1.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {
                            groupBox1.Text = "Street Test";
                            pictureBox1.Image = Resources.driving_test_512;
                            break;


                        }
                }
            }
        }

        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
            set {
                _TestID = value;
                lblTestID.Text = _TestID.ToString(); 
            }
        }

        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointment _TestAppointment;
        public void LoadData(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;
            _TestAppointment = clsTestAppointment.FindTestAppointmentByID(TestAppointmentID);
            if (_TestAppointment == null)
            {
                MessageBox.Show("TestAppoinment could't be found");
                _TestAppointmentID = -1;
                return;
            }
            _TestID = _TestAppointment._GetTestID();
            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseID.ToString();
            lblDClass.Text = _LocalDrivingLicenseApplication.Licenseclass.className;
            lblName.Text = _LocalDrivingLicenseApplication.FullName;


            //this will show the trials for this test before 
            lblTrail.Text = _LocalDrivingLicenseApplication.TotalTrailsPerTest((int)_TestTypeID).ToString();



            lblDate.Text = _TestAppointment.AppointmentDate.ToString("d");
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = (_TestAppointment._GetTestID() == -1) ? "Not Taken Yet" : _TestAppointment._GetTestID().ToString();


        }

        private void ctrlSchdeuledTest_Load(object sender, EventArgs e)
        {

        }
    }
}
