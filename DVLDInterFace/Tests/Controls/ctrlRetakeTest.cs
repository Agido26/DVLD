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

namespace DVLD.Tests
{
    public partial class ctrlRetakeTest : UserControl
    {

        int RetakAppid;
        public int ReTakeAppID{ get { return ReTakeAppID; }set { lblAppID.Text = value.ToString();ReTakeAppID = value; } }
        int TotalFee;
        public int TotalFees {  get{ return TotalFee; } set { lblTotalFees.Text = value.ToString(); TotalFee = value; } }
        int retakefee;
        public int RetakeFees { get { return retakefee; } set { lblRetakeFees.Text = value.ToString();retakefee = value; } }
        public ctrlRetakeTest()
        {
            InitializeComponent();
            
        }
        public void DefaultValue()
        {
            lblTotalFees.Text = "0";
            lblRetakeFees.Text = "0";
            lblAppID.Text = "[N/A]";
        }
       
        public bool Enable { get { return groupBox1.Enabled; } set {  groupBox1.Enabled = value; } }


    }
}
