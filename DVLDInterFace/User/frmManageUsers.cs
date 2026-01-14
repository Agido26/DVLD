using DVLD.Login;
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

namespace DVLD.User
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private DataTable dt=clsUser.GetAllUsers();
        private void dgv()
        {
            dt.Columns[0].ColumnName="UserID";
            dt.Columns[1].ColumnName = "PersonID";
            dt.Columns[2].ColumnName = "Full Name";
            dt.Columns[3].ColumnName = "Username";
            dt.Columns[4].ColumnName = "IsActive";
            dgvUsers.DataSource = dt;
            lblRecords.Text = dt.Rows.Count.ToString();
        }     
        private void Defaultvalue()
        {
            cbFilter.SelectedIndex = 0;
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            dgv();
            Defaultvalue();
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilter.Text)
            {
                case "None":
                    cbIsActive.Visible = false;
                    txtSearch.Visible = false;
                    dt.DefaultView.RowFilter = "";
                    dgvUsers.DataSource = dt;
                    lblRecords.Text = dgvUsers.RowCount.ToString();
                    txtSearch.Text = "";
                    break;
                case "UserID":
                    txtSearch.Visible = true;
                    cbIsActive.Visible = false;
                    break;
                case "PersonID":
                    txtSearch.Visible = true;
                    cbIsActive.Visible = false;
                    break;

                case "IsActive":
                    cbIsActive.Visible = true;
                    txtSearch.Visible = false;
                    cbIsActive.SelectedIndex = 0;
                    break;

                case "Full Name":
                    txtSearch.Visible = true;
                    cbIsActive.Visible = false;
                    break;

                case "Username":
                    txtSearch.Visible = true;
                    cbIsActive.Visible = false;
                    break;
            }
        }
        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateUsers EditUser = new frmAdd_UpdateUsers((int)dgvUsers.CurrentRow.Cells[1].Value);
            EditUser.ShowDialog();
            dgvUsers.DataSource=clsUser.GetAllUsers();
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((string)cbFilter.SelectedItem == "PersonID" || (string)cbFilter.SelectedItem == "UserID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
               
            }
            
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                if (cbFilter.Text == "Username" || cbFilter.Text == "Full Name")
                {
                    dt.DefaultView.RowFilter = $"[{cbFilter.Text}] LIKE '{txtSearch.Text}%'";
                }

                else
                    dt.DefaultView.RowFilter = $"[{cbFilter.Text}] = {txtSearch.Text}";

            }
            else
                dt.DefaultView.RowFilter = "";

            dgvUsers.DataSource = dt;
            lblRecords.Text = dgvUsers.RowCount.ToString();
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.Text == "Yes")
                dt.DefaultView.RowFilter = $"[{(string)cbFilter.SelectedItem}] = true";

            else if ((string)cbIsActive.SelectedItem == "No")
                dt.DefaultView.RowFilter = $"[{(string)cbFilter.SelectedItem}] = false";

            else
                dt.DefaultView.RowFilter = "";

            dgvUsers.DataSource = dt;
            lblRecords.Text = dgvUsers.RowCount.ToString();

        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateUsers frm = new frmAdd_UpdateUsers();
            frm.ShowDialog();
            dgvUsers.DataSource=clsUser.GetAllUsers();
            lblRecords.Text = dgvUsers.RowCount.ToString();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUser UserToDelete = clsUser.FindByUserID((int)dgvUsers.CurrentRow.Cells[0].Value);
           
            if(clsGlobal.CurrentUser.UserID==UserToDelete.UserID)
            { MessageBox.Show("You Can't Delete Your account"); return;  }
            
           var Result =MessageBox.Show("Are you sure? ","Delete User",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            
            if (Result== DialogResult.OK)
            {
                if (UserToDelete.DeleteUser())
                {
                    MessageBox.Show("Deleted Succefully");
                    dgvUsers.DataSource = clsUser.GetAllUsers();
                }
                else
                    MessageBox.Show("You Can't Delet this Person because there data linked to it");
            }
           
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails frmUserDetails=new frmShowUserDetails((int)dgvUsers.CurrentRow.Cells[1].Value);
            frmUserDetails.ShowDialog();
        }

        private void tmsChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[1].Value);
            frmChangePassword.ShowDialog();
        
        }
    }
}