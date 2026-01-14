namespace DVLD.User
{
    partial class frmAdd_UpdateUsers
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PersonInfoPage = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlCardInfoWithFilter2 = new DVLD.People.Controls.ctrlCardInfoWithFilter();
            this.LoginPage = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFormStatus = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.PersonInfoPage.SuspendLayout();
            this.LoginPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PersonInfoPage);
            this.tabControl1.Controls.Add(this.LoginPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(757, 457);
            this.tabControl1.TabIndex = 1;
            // 
            // PersonInfoPage
            // 
            this.PersonInfoPage.Controls.Add(this.btnNext);
            this.PersonInfoPage.Controls.Add(this.ctrlCardInfoWithFilter2);
            this.PersonInfoPage.Location = new System.Drawing.Point(4, 22);
            this.PersonInfoPage.Name = "PersonInfoPage";
            this.PersonInfoPage.Padding = new System.Windows.Forms.Padding(3);
            this.PersonInfoPage.Size = new System.Drawing.Size(749, 431);
            this.PersonInfoPage.TabIndex = 1;
            this.PersonInfoPage.Text = "Person Info";
            this.PersonInfoPage.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(596, 384);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(109, 34);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // ctrlCardInfoWithFilter2
            // 
            this.ctrlCardInfoWithFilter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlCardInfoWithFilter2.Location = new System.Drawing.Point(-4, 12);
            this.ctrlCardInfoWithFilter2.Name = "ctrlCardInfoWithFilter2";
            this.ctrlCardInfoWithFilter2.PersonID = 0;
            this.ctrlCardInfoWithFilter2.Size = new System.Drawing.Size(742, 366);
            this.ctrlCardInfoWithFilter2.TabIndex = 2;
            // 
            // LoginPage
            // 
            this.LoginPage.Controls.Add(this.checkBox1);
            this.LoginPage.Controls.Add(this.txtPassword);
            this.LoginPage.Controls.Add(this.txtConfirmPassword);
            this.LoginPage.Controls.Add(this.txtUsername);
            this.LoginPage.Controls.Add(this.lblUserID);
            this.LoginPage.Controls.Add(this.label5);
            this.LoginPage.Controls.Add(this.label4);
            this.LoginPage.Controls.Add(this.label3);
            this.LoginPage.Controls.Add(this.label2);
            this.LoginPage.Location = new System.Drawing.Point(4, 22);
            this.LoginPage.Name = "LoginPage";
            this.LoginPage.Padding = new System.Windows.Forms.Padding(3);
            this.LoginPage.Size = new System.Drawing.Size(749, 431);
            this.LoginPage.TabIndex = 0;
            this.LoginPage.Text = "LoginInfo";
            this.LoginPage.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(201, 232);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(100, 30);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "IsActive";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(201, 148);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(144, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.textbox_Validating);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(201, 191);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(144, 20);
            this.txtConfirmPassword.TabIndex = 6;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.textbox_Validating);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(201, 110);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(144, 20);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.textbox_Validating);
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(214, 68);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(52, 26);
            this.lblUserID.TabIndex = 4;
            this.lblUserID.Text = "????";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 26);
            this.label5.TabIndex = 3;
            this.label5.Text = "Confirm Password: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(83, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Username: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(113, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "UserID: ";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(492, 499);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 34);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(619, 499);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 34);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFormStatus
            // 
            this.lblFormStatus.AutoSize = true;
            this.lblFormStatus.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormStatus.ForeColor = System.Drawing.Color.Red;
            this.lblFormStatus.Location = new System.Drawing.Point(322, 15);
            this.lblFormStatus.Name = "lblFormStatus";
            this.lblFormStatus.Size = new System.Drawing.Size(157, 29);
            this.lblFormStatus.TabIndex = 4;
            this.lblFormStatus.Text = "Add New User";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAdd_UpdateUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(795, 545);
            this.Controls.Add(this.lblFormStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAdd_UpdateUsers";
            this.Text = "frmAdd_UpdateUsers";
            this.Load += new System.EventHandler(this.frmAdd_UpdateUsers_Load);
            this.tabControl1.ResumeLayout(false);
            this.PersonInfoPage.ResumeLayout(false);
            this.LoginPage.ResumeLayout(false);
            this.LoginPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PersonInfoPage;
        private System.Windows.Forms.TabPage LoginPage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFormStatus;
        private System.Windows.Forms.Button btnNext;
        private People.Controls.ctrlCardInfoWithFilter ctrlCardInfoWithFilter2;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}