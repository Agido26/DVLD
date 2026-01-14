namespace DVLD.Applications.LocalDrivingLicense
{
    partial class frmLocalDrivingLicenseApplicationInfo
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
            this.ctrlLocalLicenseInfo1 = new DVLD.LocalDrivingLicense.ctrl.ctrlLocalLicenseInfo();
            this.SuspendLayout();
            // 
            // ctrlLocalLicenseInfo1
            // 
            this.ctrlLocalLicenseInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlLocalLicenseInfo1.Location = new System.Drawing.Point(12, 12);
            this.ctrlLocalLicenseInfo1.Name = "ctrlLocalLicenseInfo1";
            this.ctrlLocalLicenseInfo1.Size = new System.Drawing.Size(716, 393);
            this.ctrlLocalLicenseInfo1.TabIndex = 0;
            // 
            // frmLocalDrivingLicenseApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 415);
            this.Controls.Add(this.ctrlLocalLicenseInfo1);
            this.Name = "frmLocalDrivingLicenseApplicationInfo";
            this.Text = "frmLocalDrivingLicenseApplicationInfo";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplicationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DVLD.LocalDrivingLicense.ctrl.ctrlLocalLicenseInfo ctrlLocalLicenseInfo1;
    }
}