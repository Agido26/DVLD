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

namespace DVLD.ManageTestTypes
{
    public partial class frmEditTestTypes : Form
    {
        clsTestTypes.enTestType _ID;
        clsTestTypes testType;
        public frmEditTestTypes(clsTestTypes.enTestType ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {
             testType=clsTestTypes.Find(_ID);

            if (testType == null) { MessageBox.Show("Something went wrong"); return; }

            lblID.Text=_ID.ToString();
            txtFees.Text=testType.Fees.ToString();
            txtTitle.Text = testType.Title;
            txtDescription.Text=testType.Description;



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            testType.Title = txtTitle.Text;
            testType.Description = txtDescription.Text;
            testType.Fees=decimal.Parse(txtFees.Text);

            if (testType.Update())
            { MessageBox.Show("Done"); }

            else MessageBox.Show("Something went wrong");
        
        }
    }
}
