using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawRectangularCoordinateSystem3st
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        public int LeftYAxesCount
        {
            get
            {
                return Convert.ToInt32(nudAxeCountL.Value);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("YAxesCountL：" + value);
                }
                nudAxeCountL.Value = value;
            }
        }

        public int RightYAxesCount
        {
            get
            {
                return Convert.ToInt32(nudAxeCountR.Value);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("YAxesCountR：" + value);
                }
                nudAxeCountR.Value = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(nudAxeCountL.Value) + Convert.ToInt32(nudAxeCountR.Value)) < 1)
            {
                MessageBox.Show("左边和右边的Y轴数量之和必须大于等于1");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
