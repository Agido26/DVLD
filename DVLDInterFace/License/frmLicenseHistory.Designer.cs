namespace DVLD.License
{
    partial class frmLicenseHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlCardInfoWithFilter1 = new DVLD.People.Controls.ctrlCardInfoWithFilter();
            this.ctrlDriverLicenses1 = new DVLD.License.Driver.ctrl.ctrlDriverLicenses();
            this.SuspendLayout();
            // 
            // ctrlCardInfoWithFilter1
            // 
            this.ctrlCardInfoWithFilter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlCardInfoWithFilter1.FilterEnable = true;
            this.ctrlCardInfoWithFilter1.Location = new System.Drawing.Point(12, 35);
            this.ctrlCardInfoWithFilter1.Name = "ctrlCardInfoWithFilter1";
            this.ctrlCardInfoWithFilter1.PersonID = 0;
            this.ctrlCardInfoWithFilter1.Size = new System.Drawing.Size(716, 372);
            this.ctrlCardInfoWithFilter1.TabIndex = 0;
            // 
            // ctrlDriverLicenses1
            // 
            this.ctrlDriverLicenses1.Location = new System.Drawing.Point(-2, 390);
            this.ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            this.ctrlDriverLicenses1.Size = new System.Drawing.Size(730, 239);
            this.ctrlDriverLicenses1.TabIndex = 1;
            // 
            // frmLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 630);
            this.Controls.Add(this.ctrlDriverLicenses1);
            this.Controls.Add(this.ctrlCardInfoWithFilter1);
            this.Name = "frmLicenseHistory";
            this.Text = "frmLicenseHistory";
            this.Load += new System.EventHandler(this.frmLicenseHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private People.Controls.ctrlCardInfoWithFilter ctrlCardInfoWithFilter1;
        private Driver.ctrl.ctrlDriverLicenses ctrlDriverLicenses1;
    }
}