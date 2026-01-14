namespace DVLD.LocalDrivingLicense
{
    partial class frmAdd_UpdateLocalDrivingLicense
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
            this.lblMain = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagePerson = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlCardInfoWithFilter1 = new DVLD.People.Controls.ctrlCardInfoWithFilter();
            this.tabPageApplication = new System.Windows.Forms.TabPage();
            this.cbLinceseClasses = new System.Windows.Forms.ComboBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPagePerson.SuspendLayout();
            this.tabPageApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.ForeColor = System.Drawing.Color.Red;
            this.lblMain.Location = new System.Drawing.Point(169, 32);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(452, 33);
            this.lblMain.TabIndex = 0;
            this.lblMain.Text = "New Local Dreiving License Application";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPagePerson);
            this.tabControl1.Controls.Add(this.tabPageApplication);
            this.tabControl1.Location = new System.Drawing.Point(12, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 432);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPagePerson
            // 
            this.tabPagePerson.Controls.Add(this.btnNext);
            this.tabPagePerson.Controls.Add(this.ctrlCardInfoWithFilter1);
            this.tabPagePerson.Location = new System.Drawing.Point(4, 22);
            this.tabPagePerson.Name = "tabPagePerson";
            this.tabPagePerson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePerson.Size = new System.Drawing.Size(768, 406);
            this.tabPagePerson.TabIndex = 0;
            this.tabPagePerson.Text = "Person Info";
            this.tabPagePerson.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(651, 377);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(89, 29);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlCardInfoWithFilter1
            // 
            this.ctrlCardInfoWithFilter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlCardInfoWithFilter1.Location = new System.Drawing.Point(3, -12);
            this.ctrlCardInfoWithFilter1.Name = "ctrlCardInfoWithFilter1";
            this.ctrlCardInfoWithFilter1.PersonID = 0;
            this.ctrlCardInfoWithFilter1.Size = new System.Drawing.Size(716, 383);
            this.ctrlCardInfoWithFilter1.TabIndex = 0;
            // 
            // tabPageApplication
            // 
            this.tabPageApplication.Controls.Add(this.cbLinceseClasses);
            this.tabPageApplication.Controls.Add(this.lblCreatedBy);
            this.tabPageApplication.Controls.Add(this.lblID);
            this.tabPageApplication.Controls.Add(this.lblDate);
            this.tabPageApplication.Controls.Add(this.lblFees);
            this.tabPageApplication.Controls.Add(this.label6);
            this.tabPageApplication.Controls.Add(this.label5);
            this.tabPageApplication.Controls.Add(this.label4);
            this.tabPageApplication.Controls.Add(this.label3);
            this.tabPageApplication.Controls.Add(this.label2);
            this.tabPageApplication.Location = new System.Drawing.Point(4, 22);
            this.tabPageApplication.Name = "tabPageApplication";
            this.tabPageApplication.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageApplication.Size = new System.Drawing.Size(768, 406);
            this.tabPageApplication.TabIndex = 1;
            this.tabPageApplication.Text = "Application Info";
            this.tabPageApplication.UseVisualStyleBackColor = true;
            // 
            // cbLinceseClasses
            // 
            this.cbLinceseClasses.FormattingEnabled = true;
            this.cbLinceseClasses.Location = new System.Drawing.Point(174, 177);
            this.cbLinceseClasses.Name = "cbLinceseClasses";
            this.cbLinceseClasses.Size = new System.Drawing.Size(201, 21);
            this.cbLinceseClasses.TabIndex = 9;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(173, 257);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(37, 19);
            this.lblCreatedBy.TabIndex = 8;
            this.lblCreatedBy.Text = "????";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(201, 97);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(37, 19);
            this.lblID.TabIndex = 7;
            this.lblID.Text = "????";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(203, 137);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 19);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "????";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.Location = new System.Drawing.Point(200, 217);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(37, 19);
            this.lblFees.TabIndex = 5;
            this.lblFees.Text = "????";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(66, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Created By: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(66, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Application Fees: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "License Class: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Application Date: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "D.L Application ID: ";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(600, 509);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 29);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(695, 509);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 29);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 550);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblMain);
            this.Name = "frmLocalDrivingLicense";
            this.Text = "frmLocalDrivingLicense";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicense_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPagePerson.ResumeLayout(false);
            this.tabPageApplication.ResumeLayout(false);
            this.tabPageApplication.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagePerson;
        private People.Controls.ctrlCardInfoWithFilter ctrlCardInfoWithFilter1;
        private System.Windows.Forms.TabPage tabPageApplication;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLinceseClasses;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblFees;
    }
}