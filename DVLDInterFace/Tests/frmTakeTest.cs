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
        clsTestTypes.enTestType _TestTypeID= clsTestTypes.enTestType.VisionTest;
        int _TestID=-1;
        clsTests _Test;
        public frmTakeTest(int TestAppointmentID,clsTestTypes.enTestType testTypesID)
        {
            InitializeComponent();
            this.TestAppointmentID= TestAppointmentID;
            _TestTypeID= testTypesID;
         
        }
       
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this Test", "Save Test", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _Test.TestAppointmentID = TestAppointmentID;

                _Test.TestResult = rdPass.Checked;//return true if he pass or false if failed
                _Test.Notes = txtNote.Text.Trim();
                _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (_Test.Save())
                {  
                    MessageBox.Show("Done"); 
                }
                else { MessageBox.Show("Faild"); }
            }
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlSchdeuledTest1.TestTypeID = _TestTypeID;
            ctrlSchdeuledTest1.LoadData(TestAppointmentID);
            if (ctrlSchdeuledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
            int _TestID = ctrlSchdeuledTest1.TestID;
            if (_TestID != -1)
            {
                _Test = clsTests.FindTestByID(_TestID);
                if (_Test.TestResult)
                    rdPass.Checked = true;
                else
                    rdFail.Checked = true;

                txtNote.Text = _Test.Notes;
                label1.Visible = true;
                rdPass.Enabled = false;
                rdFail.Enabled = false;

            }
            else
                _Test = new clsTests();

        }
    }
}
