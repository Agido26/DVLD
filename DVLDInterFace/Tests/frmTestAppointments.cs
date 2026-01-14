using DVLD.Tests.VisionTest;
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
    public partial class frmTestAppointments : Form
    {
        int LocalID;
        clsTests Test;

        clsTestTypes.enTestType TestTypeID;
        public frmTestAppointments(int LocalLicenseID, clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            LocalID = LocalLicenseID;
            this.TestTypeID = TestTypeID;

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainLableText()
        {
            switch (TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:

                    lblMain.Text = "Vesion Test Appointment";
                    this.Name = "Vision Test";
                    pictureBox1.Image = Properties.Resources.Vision_512;
                    break;

                case clsTestTypes.enTestType.WrittenTest:
                    lblMain.Text = "Written Test Appointment";
                    this.Name = "Written Test";
                    pictureBox1.Image = Properties.Resources.Written_Test_512;
                    break;

                case clsTestTypes.enTestType.StreetTest:
                    lblMain.Text = "Street Test Appointment";
                    this.Name = "Street Test";
                    pictureBox1.Image = Properties.Resources.driving_test_512;
                    break;
            }

        }

        private void frmTestAppointment_Load(object sender, EventArgs e)
        {
            MainLableText();

            ctrlLocalLicenseInfo1.LoadInfo(LocalID);
            
            dgvAppointments.DataSource=clsTestAppointment.GetAllTestAppointmentsByLocalID(this.LocalID,(int)TestTypeID);
            
            lblRecords.Text = dgvAppointments.RowCount.ToString();
        }

        
        private void btnAddTest_Click(object sender, EventArgs e)
        {
            frmScheduleTest scheduleTest;
            //check for appointments
            if(clsTestAppointment.IsThereTestAppointmentIDByLocalLicenseID(LocalID,TestTypeID))
            {
                //Check if He Has Active Appointment
                if (clsTestAppointment.IsThereActiveTestAppointmentIDByLocalLicenseID(LocalID, TestTypeID))
                {
                    MessageBox.Show("You Can't Add Appointment because He already Has Active Appointment");
                    return;
                }
                if (clsTests.TestResultByLocalDrivingLicenseID(LocalID, TestTypeID))
                {
                    MessageBox.Show("You Can't Add Appointment because He already Passed");
                    return;
                }
                scheduleTest = new frmScheduleTest(LocalID, TestTypeID, clsApplicationType.enApplicationType.RetakeTest);
                scheduleTest.ShowDialog();
            }
            else 
            {
                 scheduleTest = new frmScheduleTest(LocalID, TestTypeID);
                scheduleTest.ShowDialog();
            }
            dgvAppointments.DataSource = clsTestAppointment.GetAllTestAppointmentsByLocalID(LocalID, (int)TestTypeID);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test = clsTests.FindTestByTestAppointmentID((int)dgvAppointments.CurrentRow.Cells[0].Value);
            frmScheduleTest EditTest;
            if (Test != null)
            {
                EditTest = new frmScheduleTest((int)dgvAppointments.CurrentRow.Cells[0].Value, (clsTestTypes.enTestType)TestTypeID, clsApplicationType.enApplicationType.RetakeTest);
                EditTest.ShowDialog();
            }
            else
            {
                EditTest = new frmScheduleTest((int)dgvAppointments.CurrentRow.Cells[0].Value, (clsTestTypes.enTestType)TestTypeID, clsApplicationType.enApplicationType.NewLocalDrivingLicense);
                EditTest.ShowDialog();
            }
            dgvAppointments.DataSource = clsTestAppointment.GetAllTestAppointmentsByLocalID(LocalID,(int)TestTypeID);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test = clsTests.FindTestByTestAppointmentID((int)dgvAppointments.CurrentRow.Cells[0].Value);
            if (Test != null)
            {
                if (Test.TestResult || !Test.TestResult)
                {
                    MessageBox.Show("You Already Take this test ");
                    return;

                }


            }
            frmTakeTest TakeTest = new frmTakeTest((int)dgvAppointments.CurrentRow.Cells[0].Value);
            TakeTest.ShowDialog();
            dgvAppointments.DataSource = clsTestAppointment.GetAllTestAppointmentsByLocalID(LocalID, (int)TestTypeID);
        }
    }
}
