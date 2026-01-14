using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People.People_Controls
{
    public partial class ctrlShowPeopleWithFilter : UserControl
    {
        DataView forfilter;
        DataView Datav;
        public ctrlShowPeopleWithFilter()
        {
            InitializeComponent();
        }
        private int Person_ID;
        public int Persn_ID {
            get { return Person_ID; }
            set { Person_ID = value; }
        }
        public int getClickedPersonID() {return (int)dgvShowPeople.CurrentRow.Cells[0].Value; }
        private void FilterDataBY(string FilterBy,string SearchFor)
        {
           
            if (FilterBy == "PersonID")
            {
                forfilter.RowFilter = $"{FilterBy} = {SearchFor}";
                dgvShowPeople.DataSource = forfilter;
                return;
            }
            else
            {
                forfilter.RowFilter = $"{FilterBy} Like '{SearchFor}%'";
                dgvShowPeople.DataSource = forfilter;
            }
        }

        private bool IsthereChar(string Text)
        {
            if(int.TryParse(Text,out int x))
            {
                return false;
            }
            return true;
        }

        public void FillDataGridView(DataView Data)
        {
            forfilter= Data;
            Datav= Data;
            dgvShowPeople.DataSource = Data;
            lbRecordNumber.Text=dgvShowPeople.RowCount.ToString();
        }

        public void FillCheckBox(string[] Data)
        {
            foreach (string col in Data)
            {
                cbFilter.Items.Add(col);
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbFilter.SelectedItem == "None") { tbSearchBar.Visible = false; }

            else
            {
                tbSearchBar.Visible = true;
            }
            
        }

        private void tbSearchBar_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbSearchBar.Text))
            {
                forfilter.RowFilter = $"";
                dgvShowPeople.DataSource = forfilter;
                return;
            }
         
            if (tbSearchBar.Text != "")
            {
                if ((string)cbFilter.SelectedItem == "PersonID" && IsthereChar(tbSearchBar.Text))
                {
                    MessageBox.Show("you can only use numbers");
                    tbSearchBar.Text = "";
                }
                else
                    FilterDataBY((string)cbFilter.SelectedItem, tbSearchBar.Text);
            }
        }
    }
}
