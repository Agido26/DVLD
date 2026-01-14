namespace DVLD.User
{
    partial class frmShowUserDetails
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
            this.controlPersonIfo1 = new DVLD.People.People_Controls.controlPersonIfo();
            this.ctrlUserLoginInfo1 = new DVLD.Login.ctrlUserLoginInfo();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // controlPersonIfo1
            // 
            this.controlPersonIfo1.Location = new System.Drawing.Point(12, 23);
            this.controlPersonIfo1.Name = "controlPersonIfo1";
            this.controlPersonIfo1.Size = new System.Drawing.Size(735, 289);
            this.controlPersonIfo1.TabIndex = 0;
            // 
            // ctrlUserLoginInfo1
            // 
            this.ctrlUserLoginInfo1.Location = new System.Drawing.Point(12, 308);
            this.ctrlUserLoginInfo1.Name = "ctrlUserLoginInfo1";
            this.ctrlUserLoginInfo1.Size = new System.Drawing.Size(756, 95);
            this.ctrlUserLoginInfo1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(659, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmShowUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlUserLoginInfo1);
            this.Controls.Add(this.controlPersonIfo1);
            this.Name = "frmShowUserDetails";
            this.Text = "frmShowUserDetails";
            this.Load += new System.EventHandler(this.frmShowUserDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private People.People_Controls.controlPersonIfo controlPersonIfo1;
        private Login.ctrlUserLoginInfo ctrlUserLoginInfo1;
        private System.Windows.Forms.Button button1;
    }
}