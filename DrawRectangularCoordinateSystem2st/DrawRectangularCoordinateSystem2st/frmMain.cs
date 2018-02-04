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
    public partial class frmMain : Form
    {
        private GraphPainter m_graphPainter = new GraphPainter(3);
        public frmMain()
        {
            InitializeComponent();      

            this.DoubleBuffered = true;

            UpdateAxeGraph();
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            m_graphPainter.DrawCoordinate(e.Graphics, this.ClientSize);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            UpdateAxeGraph();
        }

        private void UpdateAxeGraph()
        {
            using (Graphics g = this.CreateGraphics())
            {
                m_graphPainter.InitGraphPositions(g, this.ClientSize);
            }
            this.Refresh();
        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.YAxesCount = m_graphPainter.YAxeCount;
            if (settings.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                m_graphPainter.YAxeCount=settings.YAxesCount;

                UpdateAxeGraph();
            }
        }
    }
}
