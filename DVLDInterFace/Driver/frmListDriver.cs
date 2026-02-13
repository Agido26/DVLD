using DVLD.Driver;
using DVLD.People;
using DVLD_Buisness;
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

namespace DVLD.License.Driver
{
    public partial class frmListDriver : Form 
    {
        clsDriver driver;
        DataTable Data;
        public frmListDriver()
        {
            InitializeComponent();
        }

        void LoadDataTable()
        {
            Data = clsDriver.GetAllDrivers();
            dataGridView1.DataSource = Data;

           
            dataGridView1.Columns[0].Width = 100;

            //dataGridView1.Columns[4].
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 200 ;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;


            
            lblRecords.Text = dataGridView1.RowCount.ToString();

        }
        void FillComboBox()
        {
            cbFilter.Items.Add("None");
            cbFilter.Items.Add(Data.Columns[0].ColumnName);//Driver ID.
            cbFilter.Items.Add(Data.Columns[1].ColumnName);//Person ID.
            cbFilter.Items.Add(Data.Columns[2].ColumnName);//National No.
            cbFilter.Items.Add(Data.Columns[3].ColumnName);//Full Name.
        }
        private void frmListDriver_Load(object sender, EventArgs e)
        {
            LoadDataTable();
            FillComboBox();
            cbFilter.SelectedIndex = 0;
           
            cbFilter_SelectedIndexChanged(null, null);

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilter.Text)
            {
                case "None":
                    txtSearchBar.Visible = false;
                   
                    break;
                case "L.D.L ApplicationID":
                    txtSearchBar.Visible = true;
                  
                    break;
                case "Status":
                   
                    txtSearchBar.Visible = false;
                    break;
                default:
                 
                    txtSearchBar.Visible = true;
                    break;
            }
            Data.DefaultView.RowFilter = ""; //restet the filter
            txtSearchBar.Text = "";//Reset text box in case are there any char  
            lblRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void txtSearchBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "DriverID"|| cbFilter.Text == "PersonID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBar.Text != "")
            {
                if (cbFilter.Text == "DriverID" || cbFilter.Text == "PersonID")
                {

                    Data.DefaultView.RowFilter = $"[{cbFilter.Text}] = {txtSearchBar.Text}";
                }

                else { Data.DefaultView.RowFilter = $"[{cbFilter.Text}] LIKE '{txtSearchBar.Text}%'"; }


            }
            else
                Data.DefaultView.RowFilter = "";

            dataGridView1.DataSource = Data;
            lblRecords.Text = dataGridView1.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 0)
            {
                return;
            }
            frmShowPersonInfo PersonInfo = new frmShowPersonInfo(driver.PersonID);
            PersonInfo.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.RowCount <= 0)
            {
                return;
            }
            driver = clsDriver.Find((int)dataGridView1.CurrentRow.Cells[0].Value);




        }

      

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 0)
            {
                return;
            }
            frmLicenseHistory history = new frmLicenseHistory(driver.PersonID);
            history.ShowDialog();
        }
    }
}
