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

namespace DVLD.Driver.ctrl
{
    public partial class ctrlDriverInfoWithFilter : UserControl
    {
        public event Action<int> OnLicenseSelected;
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if(handler!=null)
            {
                handler(LicenseID);
            }
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled { get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        private int _LicenseID = -1;

        public int LicenseID { get {return ctrlDriverLicenseInfo1.LicenseID; } }
        public clsLicenses SelectedLicenseInfo { get { return ctrlDriverLicenseInfo1.SelectedLicenseInfo; } }
        public ctrlDriverInfoWithFilter()
        {
            InitializeComponent();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            if(e.KeyChar==(char)13)
            {
                btnFind.PerformClick();
            }

        }

      
        public void LoadData(int LicenseID)
        {
            txtFilter.Text = LicenseID.ToString();
            ctrlDriverLicenseInfo1.LoadData(LicenseID);
            if(ctrlDriverLicenseInfo1.SelectedLicenseInfo==null)
            {
                return;
            }
            _LicenseID = ctrlDriverLicenseInfo1.LicenseID;
            if(OnLicenseSelected!=null && FilterEnabled)
            {
                OnLicenseSelected(_LicenseID);
            }
        }

        private void ctrlDriverInfoWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFilter.Text == "")
            {
                return;
            }
            
            _LicenseID = int.Parse(txtFilter.Text);
            if(clsLicenses.Find(_LicenseID)==null)
            {
              
                
            }
            LoadData(_LicenseID);
        }
    }
}
