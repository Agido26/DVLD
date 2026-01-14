using DVLD.Properties;
using DVLD_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmAdd_Update_People : Form
    {
        public delegate void DataBackEvent(object sender, int PersonID);
        public event DataBackEvent DataBack;

        enum enGundor { enMale=0,enFemale=1}
       
        enum enMode { enAdd=0,enUpdate=1}
        enMode _Mode = enMode.enAdd;
        clsPeople _person;
        int _PersonID = -1;

        public frmAdd_Update_People()
        {
            InitializeComponent();
           
            _Mode= enMode.enAdd;
        }
        public frmAdd_Update_People( int PersonID)
        {
            InitializeComponent();
            
             _PersonID=PersonID;
            _Mode = enMode.enUpdate;
                        
        }

        public void LoadData()
        {
            _person=clsPeople.Find(_PersonID);
            if (_person == null) { 
                MessageBox.Show($"There no person with{_PersonID}");
                this.Close();
                return;
            }
            lblPersonID.Text = _person.PersonID.ToString();
            tbFirst.Text = _person.First_Name;
            tbSecond.Text = _person.Second_Name;
            tbThird.Text = _person.Third_Name;
            tbLast.Text = _person.Last_Name;
            tbNationalNo.Text = _person.NationalNo;
           

            if (_person.Gendor == 0)
                rbMale.Checked = true;
            else rbFemale.Checked = true;


            if (string.IsNullOrEmpty(_person.Image_Path) )
            {
                if (rbFemale.Checked)
                {
                    pbPhoto.Image = Properties.Resources.Female_512;

                }
                else
                {
                    pbPhoto.Image = Properties.Resources.Male_512;
                }
                llRemove.Visible = false;
            }
            else
               { pbPhoto.ImageLocation = _person.Image_Path; llRemove.Visible = true; }

            tbPhone.Text = _person.Phone;
            tbAddress.Text = _person.Address;
            dtpDateOfBirth.Value = _person.DateOfBirth;
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountries.Find(_person.CountryID).Name);
            tbEmail.Text = _person.Email;

           
        }

        public void _FillCombo(DataTable Data, string Column_Name, string Column_ID)
        {
            cbCountry.DataSource = Data;
            cbCountry.DisplayMember = Column_Name;
            cbCountry.ValueMember = Column_ID;
        }


        private void _ResetDefaultValue()
        {
            _FillCombo(clsCountries.GetAllCountries(), "CountryName", "CountryID");

            if(_Mode==enMode.enAdd)
            {
                _person=new clsPeople();
                label1.Text = "Add New Person";
            }
            else
            {
                label1.Text = "Update Person Info";
            }


            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            tbFirst.Text = "";
            tbSecond.Text = "";
            tbThird.Text = "";
            tbLast.Text = "";
            tbNationalNo.Text = "";
            tbPhone.Text = "";
            tbEmail.Text = "";
            tbAddress.Text = "";

           cbCountry.SelectedIndex= cbCountry.FindString("Sudan");

            llRemove.Visible = false;
        }

        private void frmAdd_Update_People_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if(_Mode==enMode.enUpdate)
                LoadData();

        }

        string PersonPicture;
        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPhoto.ImageLocation = null;

            if(rbFemale.Checked)
                pbPhoto.Image = Properties.Resources.Female_512;
            else
                pbPhoto.Image = Properties.Resources.Male_512;

            llRemove.Visible = false;
        }
    

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filter = "File Image|*.png;*.jpg;*.jpeg;.gif";

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = filter;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PersonPicture = openFileDialog1.FileName;
                pbPhoto.ImageLocation = PersonPicture;
                llRemove.Visible = true;
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPhoto.ImageLocation == null)
                pbPhoto.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {   
            if (pbPhoto.ImageLocation == null)
                pbPhoto.Image = Resources.Female_512;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateChilder())
            { MessageBox.Show("fix what is wrong");
                return;
            }
            _Change_ImageLocation();

            _person.First_Name=tbFirst.Text.Trim();
            _person.Second_Name=tbSecond.Text.Trim();
            _person.Third_Name=tbThird.Text.Trim();
            _person.Last_Name=tbLast.Text.Trim();
            _person.Image_Path = pbPhoto.ImageLocation;
            _person.DateOfBirth=dtpDateOfBirth.Value;
            _person.Email=tbEmail.Text.Trim();
            _person.Address=tbAddress.Text.Trim();
            _person.NationalNo=tbNationalNo.Text.Trim();
            _person.Phone=tbPhone.Text.Trim();
            _person.CountryID=clsCountries.Find(cbCountry.Text).ID;
            if (rbMale.Checked)
                _person.Gendor = (byte)enGundor.enMale;
            else
            {
                _person.Gendor = (byte)enGundor.enFemale;
            }

            if (_person.Save())
            {
                lblPersonID.Text = _person.PersonID.ToString();
                label1.Text = "Update Person";
                _Mode=enMode.enUpdate;

                MessageBox.Show("Data Saved Succefully", "Saved", MessageBoxButtons.OK);

                DataBack?.Invoke(this,_PersonID);
            }
            else { MessageBox.Show("Something wrong"); }

        }

        private void _Change_ImageLocation()
        {
            if (_person.Image_Path!=pbPhoto.ImageLocation)
            {
                if(!string.IsNullOrEmpty(_person.Image_Path))
                {
                    try { File.Delete(this._person.Image_Path); }
                    catch(Exception e) { Console.WriteLine(e); }
                }
                if (pbPhoto.ImageLocation != null)
                {
                    string newPath = clsUtil.ChangeImageLoctationToProjectLocation(pbPhoto.ImageLocation);
                    pbPhoto.ImageLocation = newPath;
                }

            }
            
            
        }

        private bool ValidateChilder()
        {
            foreach (Control c in this.Controls)
            {
                if(c is Guna2TextBox && c!=tbEmail && c != tbThird)
                {
                    if(c.Text=="")
                    {
                        errorProvider1.SetError(c,"Cant be empty");
                        return false;
                    }
                }


            }
            return true;
        }
        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {if (tbEmail.Text.Trim() == "")
                return;

            if (clsValidate.ValidateEmail(tbEmail.Text))
            {
                errorProvider1.SetError((Guna2TextBox)sender, "");

            }
            else
            {
                errorProvider1.SetError((Guna2TextBox)sender, "Email Fromat should end with \"@gmail.com\"");
            }

        }

       
        private void textbox_Validating(object sender, CancelEventArgs e)
        {
            Guna2TextBox temp = (Guna2TextBox)sender;
            if (string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "the filed is required");
            }
            else
            {
                errorProvider1.SetError(temp, null);

            }
        }

        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbNationalNo.Text.Trim()))
            {
                e.Cancel=true;
                errorProvider1.SetError(tbNationalNo, "This filed is required");
                return;
            }
            else
                errorProvider1.SetError(tbNationalNo, null);

            if(tbNationalNo.Text.Trim()!=_person.NationalNo&& clsPeople.IsPersonExsist(tbNationalNo.Text))
            { 
                e.Cancel=true;
                errorProvider1.SetError(tbNationalNo, "this NationalNo is used for other person");
            }
            else
                errorProvider1.SetError(tbNationalNo, null);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
