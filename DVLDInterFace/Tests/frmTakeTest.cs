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

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {
        int TestAppointmentID;
        clsTestAppointment TestAppointment;
       
        clsTests Test;
        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            this.TestAppointmentID= TestAppointmentID;
         
        }
       
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this Test", "Save Test", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Test = new clsTests();
                Test.TestAppointmentID = TestAppointmentID;
                
                Test.TestResult = rdPass.Checked;//return true if he pass or false if failed
                Test.Notes = txtNote.Text;
                Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (Test.Save())
                {
                    TestAppointment.IsLocked=true;
                    if(TestAppointment.Save())
                   { MessageBox.Show("Done"); }
                }
                else { MessageBox.Show("Faild"); }
            }
        }
        private void MainLableText()
        {
            switch ((clsTestTypes.enTestType)TestAppointment.TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    groupBox1.Text= "Vision Test";
                    this.Name = "Vision Test";
                    pictureBox1.Image = Properties.Resources.Vision_512;
                    break;

                case clsTestTypes.enTestType.WrittenTest:
                    groupBox1.Text = "Written Test";
                    this.Name = "Written Test";
                    pictureBox1.Image = Properties.Resources.Written_Test_512;
                    break;

                case clsTestTypes.enTestType.StreetTest:
                    groupBox1.Text = "Street Test";
                    this.Name = "Street Test";
                    pictureBox1.Image = Properties.Resources.driving_test_512;
                    break;
            }

        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
           

            TestAppointment = clsTestAppointment.FindTestAppointmentByID(this.TestAppointmentID);
            MainLableText();
            if (TestAppointment == null) { MessageBox.Show("Coudn't find TestAppoimnt"); }
            lblDLAppID.Text = TestAppointment.LocalDrivingLicenseID.ToString();
            lblDClass.Text = TestAppointment.LocalDrivingLicense.FullName;
            lblName.Text = TestAppointment.LocalDrivingLicense.FullName;
           
            lblDate.Text = TestAppointment.AppointmentDate.ToString();
            lblFees.Text = TestAppointment.PaidFees.ToString();

            Test = clsTests.FindTestByTestAppointmentID(TestAppointmentID);
            if (Test == null)
            {
                lblTestID.Text = "Not Taken Yet";
                return;
            }

            txtNote.Text = Test.Notes;
          
            if (Test.TestResult == true)
            {
                rdPass.Checked = true;
                rdFail.Checked = false;
            }
            else {
                rdPass.Checked = false;
                rdFail.Checked = true;
            }

        }
    }
}
