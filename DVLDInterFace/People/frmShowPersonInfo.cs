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

namespace DVLD.People
{
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            ctrlShow1.LoadPersonData(NationalNo);

        }
        public frmShowPersonInfo(int ID)
        {
            InitializeComponent();
            ctrlShow1.LoadPersonData(ID);
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
