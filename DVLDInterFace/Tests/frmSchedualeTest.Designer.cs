namespace DVLD.Tests
{
    partial class SchedualeTest
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
            this.ctrlScheduleTets1 = new DVLD.Tests.Controls.ctrlScheduleTets();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlScheduleTets1
            // 
            this.ctrlScheduleTets1.Location = new System.Drawing.Point(12, 12);
            this.ctrlScheduleTets1.Name = "ctrlScheduleTets1";
            this.ctrlScheduleTets1.Size = new System.Drawing.Size(413, 576);
            this.ctrlScheduleTets1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(120, 594);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 29);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SchedualeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 628);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlScheduleTets1);
            this.Name = "SchedualeTest";
            this.Text = "SchedualeTest";
            this.Load += new System.EventHandler(this.SchedualeTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlScheduleTets ctrlScheduleTets1;
        private System.Windows.Forms.Button btnClose;
    }
}