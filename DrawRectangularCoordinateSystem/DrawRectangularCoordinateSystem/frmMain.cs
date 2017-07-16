using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawRectangularCoordinateSystem
{
    public partial class frmMain : Form
    {
        private GraphPainter m_graphPainter = new GraphPainter();
        public frmMain()
        {
            InitializeComponent();

            using (Graphics g = this.CreateGraphics())
            {
                m_graphPainter.InitGraphPositions(g, this.ClientSize);
            }

            this.DoubleBuffered = true;
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            m_graphPainter.DrawCoordinate(e.Graphics, this.ClientSize);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                m_graphPainter.InitGraphPositions(g, this.ClientSize);
            }
            this.Refresh();
        }
    }
}
