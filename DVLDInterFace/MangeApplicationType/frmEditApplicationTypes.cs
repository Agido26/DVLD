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

namespace DVLD.MangeApplicationType
{
    public partial class frmEditApplicationTypes : Form
    {
        int _ID;
        clsApplicationType _type;
        public frmEditApplicationTypes(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            _type.Fees=decimal.Parse(txtFees.Text);
            _type.Title=txtTitle.Text;
            if(_type.UpdateApplicationType(_ID))
            {
                MessageBox.Show("Saved Succefully");
            }
            else { MessageBox.Show("Something went wrong"); }
          


        }

        private void frmEditApplicationTypes_Load(object sender, EventArgs e)
        {
             _type = clsApplicationType.Find(_ID);
            if (_type == null)
            {
                MessageBox.Show("Types isn't find");
                this.Close();
                return;
            }
            lblID.Text=_ID.ToString();
            txtFees.Text=_type.Fees.ToString();
            txtTitle.Text = _type.Title;
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
