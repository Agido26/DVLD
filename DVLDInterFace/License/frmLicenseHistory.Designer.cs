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
            this.tabLocalLicense = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabInternational = new System.Windows.Forms.TabPage();
            this.gbDriverLicenses = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLocalDriver = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInternationalLicense = new System.Windows.Forms.DataGridView();
            this.tabLocalLicense.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabInternational.SuspendLayout();
            this.gbDriverLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicense)).BeginInit();
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
            // tabLocalLicense
            // 
            this.tabLocalLicense.Controls.Add(this.tabPage1);
            this.tabLocalLicense.Controls.Add(this.tabInternational);
            this.tabLocalLicense.Location = new System.Drawing.Point(6, 27);
            this.tabLocalLicense.Name = "tabLocalLicense";
            this.tabLocalLicense.SelectedIndex = 0;
            this.tabLocalLicense.Size = new System.Drawing.Size(716, 171);
            this.tabLocalLicense.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dgvLocalDriver);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(708, 145);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabInternational
            // 
            this.tabInternational.Controls.Add(this.dgvInternationalLicense);
            this.tabInternational.Controls.Add(this.label1);
            this.tabInternational.Location = new System.Drawing.Point(4, 22);
            this.tabInternational.Name = "tabInternational";
            this.tabInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tabInternational.Size = new System.Drawing.Size(708, 145);
            this.tabInternational.TabIndex = 1;
            this.tabInternational.Text = "International";
            this.tabInternational.UseVisualStyleBackColor = true;
            // 
            // gbDriverLicenses
            // 
            this.gbDriverLicenses.Controls.Add(this.tabLocalLicense);
            this.gbDriverLicenses.Location = new System.Drawing.Point(12, 413);
            this.gbDriverLicenses.Name = "gbDriverLicenses";
            this.gbDriverLicenses.Size = new System.Drawing.Size(730, 204);
            this.gbDriverLicenses.TabIndex = 2;
            this.gbDriverLicenses.TabStop = false;
            this.gbDriverLicenses.Text = "Driver Licenses";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "International License History";
            // 
            // dgvLocalDriver
            // 
            this.dgvLocalDriver.AllowUserToAddRows = false;
            this.dgvLocalDriver.AllowUserToDeleteRows = false;
            this.dgvLocalDriver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDriver.Location = new System.Drawing.Point(3, 28);
            this.dgvLocalDriver.Name = "dgvLocalDriver";
            this.dgvLocalDriver.ReadOnly = true;
            this.dgvLocalDriver.Size = new System.Drawing.Size(696, 114);
            this.dgvLocalDriver.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Local License History";
            // 
            // dgvInternationalLicense
            // 
            this.dgvInternationalLicense.AllowUserToAddRows = false;
            this.dgvInternationalLicense.AllowUserToDeleteRows = false;
            this.dgvInternationalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicense.Location = new System.Drawing.Point(6, 25);
            this.dgvInternationalLicense.Name = "dgvInternationalLicense";
            this.dgvInternationalLicense.ReadOnly = true;
            this.dgvInternationalLicense.Size = new System.Drawing.Size(696, 114);
            this.dgvInternationalLicense.TabIndex = 2;
            // 
            // frmLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 630);
            this.Controls.Add(this.ctrlCardInfoWithFilter1);
            this.Controls.Add(this.gbDriverLicenses);
            this.Name = "frmLicenseHistory";
            this.Text = "frmLicenseHistory";
            this.Load += new System.EventHandler(this.frmLicenseHistory_Load);
            this.tabLocalLicense.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabInternational.ResumeLayout(false);
            this.tabInternational.PerformLayout();
            this.gbDriverLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private People.Controls.ctrlCardInfoWithFilter ctrlCardInfoWithFilter1;
        private System.Windows.Forms.TabControl tabLocalLicense;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabInternational;
        private System.Windows.Forms.GroupBox gbDriverLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocalDriver;
        private System.Windows.Forms.DataGridView dgvInternationalLicense;
    }
}