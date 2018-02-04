using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawRectangularCoordinateSystem2st
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        public int YAxesCount
        {
            get
            {
                return Convert.ToInt32(nudAxeCount.Value);
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("YAxesCount：" + value);
                }
                nudAxeCount.Value = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
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
