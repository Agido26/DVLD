
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

namespace DVLD.Tests
{
    public partial class frmTestAppointments : Form
    {
        int LocalID;
        clsTestAppointment TestAppointment;

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
            
            dgvAppointments.DataSource=clsTestAppointment.GetApplicationTestAppointmentPerTestType(this.LocalID,(int)TestTypeID);
            
            lblRecords.Text = dgvAppointments.RowCount.ToString();

        }

        
        private void btnAddTest_Click(object sender, EventArgs e)
        {

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalLicenseID(LocalID);
            if (localDrivingLicenseApplication.IsThereActiveTestAppointment((int)TestTypeID))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            //---
            clsTests LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(TestTypeID);

            if (LastTest == null)
            {
                SchedualeTest frm1 = new SchedualeTest(LocalID, TestTypeID);
                frm1.ShowDialog();
                frmTestAppointment_Load(null, null);
                return;
            }

            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SchedualeTest frm2 = new SchedualeTest
                (LastTest.TestAppointment.LocalDrivingLicenseID, TestTypeID);
            frm2.ShowDialog();
            frmTestAppointment_Load(null, null);
            //---

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblRecords.Text) > 0)
            {
                int TestAppointment = (int)dgvAppointments.CurrentRow.Cells[0].Value;
                SchedualeTest EditTest = new SchedualeTest(LocalID, TestTypeID, TestAppointment);
                EditTest.ShowDialog();
            }
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

    }

}
