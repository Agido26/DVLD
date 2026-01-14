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

namespace DVLD.People.Controls
{
    public partial class ctrlCardInfoWithFilter : UserControl
    {
        public bool FilterEnable { get { return groupBox1.Enabled; } set { groupBox1.Enabled = value; } }
        private clsPeople _person;
        private int _PersonID;
        public int PersonID { get { return _PersonID; } set {  _PersonID = value; } }
        public clsPeople PersonInfo { get { return _person; }  }

        public ctrlCardInfoWithFilter()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd_Update_People AddPerson=new frmAdd_Update_People();
            AddPerson.ShowDialog();
        }

        void LoadPersonData()
        {
            if ((string)cbFilter.SelectedItem=="PersonID" )
            {
                _person = clsPeople.Find(int.Parse(tbSearch.Text));
            }
            else
                _person = clsPeople.Find(tbSearch.Text);

        }

        public void LoadPersonData(int PersonID)
        {
            _PersonID = PersonID;
            controlPersonIfo1.LoadPersonData(PersonID);
            _person = controlPersonIfo1.Person;
            tbSearch.Text = controlPersonIfo1.Person.PersonID.ToString();
            cbFilter.SelectedIndex = 0;
            FilterEnable = false;
        }
        public void LoadPersonData(string NationalNo)
        {
            _PersonID = PersonID;
            controlPersonIfo1.LoadPersonData(NationalNo);
            _person = controlPersonIfo1.Person;
            tbSearch.Text = controlPersonIfo1.Person.NationalNo;
            cbFilter.SelectedIndex = 1;
            FilterEnable = false;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text == "")
            {
                controlPersonIfo1.ResetPersonInfo();
                return;
            }
            LoadPersonData();
            if(_person==null)
            {
                controlPersonIfo1.ResetPersonInfo();
                MessageBox.Show("No person is Found");
            }
            else
               { controlPersonIfo1.LoadPersonData(_person.PersonID); PersonID = _person.PersonID; }
        }

        private void ctrlCardInfoWithFilter_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((string)cbFilter.SelectedItem == "PersonID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
        }

        public void ResetDefautValue()
        {
            controlPersonIfo1.ResetPersonInfo();
            cbFilter.SelectedIndex = 0;
            tbSearch.Text = "";
        }
       
    }
}
