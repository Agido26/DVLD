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

namespace DVLD.People.People_Controls
{
    public partial class controlPersonIfo : UserControl
    {
        private clsPeople _person;
        public clsPeople Person { get { return _person; } }
        public controlPersonIfo()
        {
            InitializeComponent();
        }

        public void LoadPersonData(int PersonID)
        {
            _person=clsPeople.Find(PersonID);
            if (_person == null)
            {
                ResetPersonInfo();
                MessageBox.Show($"There is no person with ID {PersonID} ");
                return;
            }
            Fill();
        }
        public void LoadPersonData(string NationalNo)
        {
            _person = clsPeople.Find(NationalNo);
            if (_person == null)
            {
                ResetPersonInfo();
                MessageBox.Show($"There is no person with ID {NationalNo} ");
                return;
            }
            Fill();
        }

        public void Fill()
        {
            this.lblName.Text = _person.First_Name+" "+_person.Second_Name + " " + _person.Third_Name + " " + _person.Last_Name;
            this.lblNationaNO.Text = _person.NationalNo;
            this.PersonID.Text = _person.PersonID.ToString();
            lblGendor.Text = _person.Gendor == 0 ? "Male" : "Female";
            this.lblEmail.Text = _person.Email;
            this.lblAddress.Text = _person.Address;
            this.lblDateOfBirth.Text=_person.DateOfBirth.ToString();
            this.lblPhone.Text = _person.Phone;
            this.lblCountry.Text =clsCountries.Find (_person.CountryID).Name;
               
            if (string.IsNullOrEmpty(_person.Image_Path))
            { pbPhoto.Image = Properties.Resources.Male_512; }
            else
            { pbPhoto.ImageLocation = _person.Image_Path; }
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdd_Update_People frmUpdate_People = new frmAdd_Update_People(this._person.PersonID);
          
            frmUpdate_People.DataBack += frmAdd_Update_Data;
            frmUpdate_People.ShowDialog();
           
        }

        private void frmAdd_Update_Data(object sender, int ID)
        {
            LoadPersonData(ID);
        }
        public void ResetPersonInfo()
        {
            this.lblName.Text = "[???]";
            this.lblNationaNO.Text = "[???]";
            this.PersonID.Text = "[???]";
            lblGendor.Text = "[???]";
            this.lblEmail.Text = "[???]";
            this.lblAddress.Text = "[???]";
            this.lblDateOfBirth.Text = "[???]";
            this.lblPhone.Text = "[???]";
            this.lblCountry.Text = "[???]";
        }

    }
}