using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.People
{
    public partial class frmManagePeople : Form
    {

        private DataView Data=clsPeople.GetAllPeople().DefaultView;
        private string[] columnNames = clsPeople.GetAllPeople().Columns.Cast<DataColumn>()
                                       .Select(x => x.ColumnName)
                                       .ToArray();
        public frmManagePeople()
        {
            InitializeComponent();
            ctrlShowPeopleWithFilter1.FillDataGridView(Data);
            ctrlShowPeopleWithFilter1.FillCheckBox(columnNames);
        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void btnAddPeople_Click(object sender, EventArgs e)
        {
            frmAdd_Update_People frmAdd_Person = new frmAdd_Update_People();
            frmAdd_Person.ShowDialog();
            Data = clsPeople.GetAllPeople().DefaultView;
            ctrlShowPeopleWithFilter1.FillDataGridView(Data);
        }

        private void cmsAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAdd_Update_People frmAdd_Person = new frmAdd_Update_People();
            frmAdd_Person.ShowDialog();
            Data = clsPeople.GetAllPeople().DefaultView;
            ctrlShowPeopleWithFilter1.FillDataGridView(Data);
        }
        
        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ctrlShowPeopleWithFilter1.Persn_ID = ctrlShowPeopleWithFilter1.getClickedPersonID();
           frmAdd_Update_People frmUpdate_Person = new frmAdd_Update_People(ctrlShowPeopleWithFilter1.Persn_ID);
           frmUpdate_Person.ShowDialog();
            Data=clsPeople.GetAllPeople().DefaultView;
            ctrlShowPeopleWithFilter1.FillDataGridView(Data);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(clsPeople.Delete_Person_By_ID(ctrlShowPeopleWithFilter1.getClickedPersonID()))
            {
                MessageBox.Show("Deleted Succefully");
                Data = clsPeople.GetAllPeople().DefaultView;
                ctrlShowPeopleWithFilter1.FillDataGridView(Data);
                
            }
            else { MessageBox.Show($"Can't Delete this person with ID ={ctrlShowPeopleWithFilter1.getClickedPersonID()}, because there data linked to it");
            this.Close();}

        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frmShow_Person = new frmShowPersonInfo(ctrlShowPeopleWithFilter1.getClickedPersonID());
            frmShow_Person.ShowDialog();
            Data=clsPeople.GetAllPeople().DefaultView;
            ctrlShowPeopleWithFilter1.FillDataGridView(Data);

        }
    }
}
