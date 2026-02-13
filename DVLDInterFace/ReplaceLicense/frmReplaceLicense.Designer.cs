namespace DVLD.ReplaceLicense
{
    partial class frmReplaceLicense
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
            this.ctrlDriverInfoWithFilter1 = new DVLD.Driver.ctrl.ctrlDriverInfoWithFilter();
            this.lblMain = new System.Windows.Forms.Label();
            this.gbReplaceFor = new System.Windows.Forms.GroupBox();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.rbDamged = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.LRAppID = new System.Windows.Forms.Label();
            this.lblReLicID = new System.Windows.Forms.Label();
            this.lblOldLicID = new System.Windows.Forms.Label();
            this.lblCreatedBY = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.llblShowLicHis = new System.Windows.Forms.LinkLabel();
            this.llblShowLicInfo = new System.Windows.Forms.LinkLabel();
            this.gbReplaceFor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlDriverInfoWithFilter1
            // 
            this.ctrlDriverInfoWithFilter1.FilterEnabled = true;
            this.ctrlDriverInfoWithFilter1.Location = new System.Drawing.Point(12, 50);
            this.ctrlDriverInfoWithFilter1.Name = "ctrlDriverInfoWithFilter1";
            this.ctrlDriverInfoWithFilter1.Size = new System.Drawing.Size(703, 437);
            this.ctrlDriverInfoWithFilter1.TabIndex = 0;
            this.ctrlDriverInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlDriverInfoWithFilter1_OnLicenseSelected);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.ForeColor = System.Drawing.Color.Red;
            this.lblMain.Location = new System.Drawing.Point(207, 14);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(389, 33);
            this.lblMain.TabIndex = 1;
            this.lblMain.Text = "Replacement for Damged License";
            // 
            // gbReplaceFor
            // 
            this.gbReplaceFor.Controls.Add(this.rbLost);
            this.gbReplaceFor.Controls.Add(this.rbDamged);
            this.gbReplaceFor.Location = new System.Drawing.Point(535, 62);
            this.gbReplaceFor.Name = "gbReplaceFor";
            this.gbReplaceFor.Size = new System.Drawing.Size(166, 102);
            this.gbReplaceFor.TabIndex = 2;
            this.gbReplaceFor.TabStop = false;
            this.gbReplaceFor.Text = "Replacment for";
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Location = new System.Drawing.Point(19, 53);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(85, 17);
            this.rbLost.TabIndex = 1;
            this.rbLost.TabStop = true;
            this.rbLost.Text = "Lost License";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.rbLost_CheckedChanged);
            // 
            // rbDamged
            // 
            this.rbDamged.AutoSize = true;
            this.rbDamged.Location = new System.Drawing.Point(19, 30);
            this.rbDamged.Name = "rbDamged";
            this.rbDamged.Size = new System.Drawing.Size(105, 17);
            this.rbDamged.TabIndex = 0;
            this.rbDamged.TabStop = true;
            this.rbDamged.Text = "Damged License";
            this.rbDamged.UseVisualStyleBackColor = true;
            this.rbDamged.CheckedChanged += new System.EventHandler(this.rbDamged_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAppFees);
            this.groupBox1.Controls.Add(this.lblAppDate);
            this.groupBox1.Controls.Add(this.LRAppID);
            this.groupBox1.Controls.Add(this.lblReLicID);
            this.groupBox1.Controls.Add(this.lblOldLicID);
            this.groupBox1.Controls.Add(this.lblCreatedBY);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(22, 483);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 124);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application info for License Replacement ";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.Location = new System.Drawing.Point(127, 91);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(43, 13);
            this.lblAppFees.TabIndex = 11;
            this.lblAppFees.Text = "[????]";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(127, 64);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(43, 13);
            this.lblAppDate.TabIndex = 10;
            this.lblAppDate.Text = "[????]";
            // 
            // LRAppID
            // 
            this.LRAppID.AutoSize = true;
            this.LRAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LRAppID.Location = new System.Drawing.Point(127, 30);
            this.LRAppID.Name = "LRAppID";
            this.LRAppID.Size = new System.Drawing.Size(43, 13);
            this.LRAppID.TabIndex = 9;
            this.LRAppID.Text = "[????]";
            // 
            // lblReLicID
            // 
            this.lblReLicID.AutoSize = true;
            this.lblReLicID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReLicID.Location = new System.Drawing.Point(510, 30);
            this.lblReLicID.Name = "lblReLicID";
            this.lblReLicID.Size = new System.Drawing.Size(43, 13);
            this.lblReLicID.TabIndex = 8;
            this.lblReLicID.Text = "[????]";
            // 
            // lblOldLicID
            // 
            this.lblOldLicID.AutoSize = true;
            this.lblOldLicID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicID.Location = new System.Drawing.Point(510, 64);
            this.lblOldLicID.Name = "lblOldLicID";
            this.lblOldLicID.Size = new System.Drawing.Size(43, 13);
            this.lblOldLicID.TabIndex = 7;
            this.lblOldLicID.Text = "[????]";
            // 
            // lblCreatedBY
            // 
            this.lblCreatedBY.AutoSize = true;
            this.lblCreatedBY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBY.Location = new System.Drawing.Point(510, 91);
            this.lblCreatedBY.Name = "lblCreatedBY";
            this.lblCreatedBY.Size = new System.Drawing.Size(43, 13);
            this.lblCreatedBY.TabIndex = 6;
            this.lblCreatedBY.Text = "[????]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Application Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Application Fees:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(358, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Replaced License ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(358, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Created By:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(358, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Old License ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "L,R.Application ID:";
            // 
            // btnIssue
            // 
            this.btnIssue.Location = new System.Drawing.Point(572, 613);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(129, 35);
            this.btnIssue.TabIndex = 4;
            this.btnIssue.Text = "Issue Replacment";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(485, 613);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // llblShowLicHis
            // 
            this.llblShowLicHis.AutoSize = true;
            this.llblShowLicHis.Enabled = false;
            this.llblShowLicHis.Location = new System.Drawing.Point(22, 620);
            this.llblShowLicHis.Name = "llblShowLicHis";
            this.llblShowLicHis.Size = new System.Drawing.Size(109, 13);
            this.llblShowLicHis.TabIndex = 26;
            this.llblShowLicHis.TabStop = true;
            this.llblShowLicHis.Text = "Show License History";
            this.llblShowLicHis.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicHis_LinkClicked);
            // 
            // llblShowLicInfo
            // 
            this.llblShowLicInfo.AutoSize = true;
            this.llblShowLicInfo.Enabled = false;
            this.llblShowLicInfo.Location = new System.Drawing.Point(149, 620);
            this.llblShowLicInfo.Name = "llblShowLicInfo";
            this.llblShowLicInfo.Size = new System.Drawing.Size(118, 13);
            this.llblShowLicInfo.TabIndex = 25;
            this.llblShowLicInfo.TabStop = true;
            this.llblShowLicInfo.Text = "Show new License Info";
            this.llblShowLicInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicInfo_LinkClicked);
            // 
            // frmReplaceLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 649);
            this.Controls.Add(this.llblShowLicHis);
            this.Controls.Add(this.llblShowLicInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbReplaceFor);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.ctrlDriverInfoWithFilter1);
            this.Name = "frmReplaceLicense";
            this.Text = "frmReplaceLicense";
            this.Load += new System.EventHandler(this.frmReplaceLicense_Load);
            this.gbReplaceFor.ResumeLayout(false);
            this.gbReplaceFor.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Driver.ctrl.ctrlDriverInfoWithFilter ctrlDriverInfoWithFilter1;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.GroupBox gbReplaceFor;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.RadioButton rbDamged;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label LRAppID;
        private System.Windows.Forms.Label lblReLicID;
        private System.Windows.Forms.Label lblOldLicID;
        private System.Windows.Forms.Label lblCreatedBY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llblShowLicHis;
        private System.Windows.Forms.LinkLabel llblShowLicInfo;
    }
}