using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmDataGridWithFilter : Form
    {
        public frmDataGridWithFilter()
        {
            InitializeComponent();
        }

       protected void FillComboBox(string[] Names)
        {
            foreach (string Name in Names)
            {
                cbFilter.Items.Add(Name);
            }

        }

        protected void FillDataGridView(DataTable Data)
        {
            dataGridView1.DataSource = Data;
            lblRecords.Text = dataGridView1.RowCount.ToString();
        }



    }
}
