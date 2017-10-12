using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPO_2
{
    public partial class frmChild : Form
    {
        public frmChild()
        {
            InitializeComponent();
        }


        int old_X, old_Y;

        

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (CurrentMode.tool) {
                    case Tools.Pen:
                        graphics.DrawLine(CurrentMode.pen, old_X, old_Y, e.X, e.Y);
                        pictureBox1.Refresh();
                        old_X = e.X;
                        old_Y = e.Y;
                        break;
                }
            }
        }

        private Graphics graphics;

        private void frmChild_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);
            pictureBox1.Refresh();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            old_X = e.X;
            old_Y = e.Y;
        }
    }
}
