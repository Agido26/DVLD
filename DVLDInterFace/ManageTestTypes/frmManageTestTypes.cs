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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource=clsTestTypes.GetAllTestTypes();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 60;

            dataGridView1.Columns[1].HeaderText = "Title";
            dataGridView1.Columns[1].Width = 150;

            dataGridView1.Columns[2].HeaderText = "Description";
            dataGridView1.Columns[2].Width =450;

            dataGridView1.Columns[3].HeaderText = "Fees";
            dataGridView1.Columns[3].Width = 100;

            lblRecords.Text=dataGridView1.RowCount.ToString();
        }

        private void edirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestTypes edit = new frmEditTestTypes((clsTestTypes.enTestType)dataGridView1.CurrentRow.Cells[0].Value);
            edit.ShowDialog();
            dataGridView1.DataSource = clsTestTypes.GetAllTestTypes();
            lblRecords.Text=dataGridView1.RowCount.ToString();
        }
    }
}
