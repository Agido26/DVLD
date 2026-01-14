using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmFindPerson : Form
    {

        public delegate void DataBackEvent(object sender, int personID);
        public event DataBackEvent Dataaback;
        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dataaback?.Invoke(this, ctrlFilterPeople1.PersonID);
            this.Close();
        }
    }
}
