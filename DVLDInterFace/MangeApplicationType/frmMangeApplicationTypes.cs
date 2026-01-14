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
    public partial class frmMangeApplicationTypes : Form
    {
        public frmMangeApplicationTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void frmMangeApplicationTypes_Load(object sender, EventArgs e)
        {
            dgvApplicationType.DataSource= clsApplicationType.GetAllApplicationType();
            if (dgvApplicationType.RowCount > 0)
            {
                dgvApplicationType.Columns[0].HeaderText = "ID";
                dgvApplicationType.Columns[0].Width = 100;

                dgvApplicationType.Columns[1].HeaderText = "Title";
                dgvApplicationType.Columns[1].Width = 250;

                dgvApplicationType.Columns[2].HeaderText = "Fees";
                dgvApplicationType.Columns[2].Width = 100;
            }
            lblRecords.Text=dgvApplicationType.RowCount.ToString();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationTypes edit = new frmEditApplicationTypes((int)dgvApplicationType.CurrentRow.Cells[0].Value);
            edit.ShowDialog();
            dgvApplicationType.DataSource=clsApplicationType.GetAllApplicationType();
            lblRecords.Text = dgvApplicationType.RowCount.ToString();
        }
    }
}
