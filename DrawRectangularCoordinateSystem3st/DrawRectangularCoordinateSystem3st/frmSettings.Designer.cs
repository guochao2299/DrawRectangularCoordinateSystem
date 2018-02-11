namespace DrawRectangularCoordinateSystem3st
{
    partial class frmSettings
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudAxeCountL = new System.Windows.Forms.NumericUpDown();
            this.nudAxeCountR = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAxeCountL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAxeCountR)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(261, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 26);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确    定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(261, 44);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取    消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "左边Y轴数量：";
            // 
            // nudAxeCountL
            // 
            this.nudAxeCountL.Location = new System.Drawing.Point(110, 17);
            this.nudAxeCountL.Name = "nudAxeCountL";
            this.nudAxeCountL.Size = new System.Drawing.Size(85, 21);
            this.nudAxeCountL.TabIndex = 0;
            this.nudAxeCountL.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudAxeCountR
            // 
            this.nudAxeCountR.Location = new System.Drawing.Point(110, 48);
            this.nudAxeCountR.Name = "nudAxeCountR";
            this.nudAxeCountR.Size = new System.Drawing.Size(85, 21);
            this.nudAxeCountR.TabIndex = 3;
            this.nudAxeCountR.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "右边Y轴数量：";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 93);
            this.Controls.Add(this.nudAxeCountR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudAxeCountL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "坐标轴设置";
            ((System.ComponentModel.ISupportInitialize)(this.nudAxeCountL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAxeCountR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudAxeCountL;
        private System.Windows.Forms.NumericUpDown nudAxeCountR;
        private System.Windows.Forms.Label label2;
    }
}