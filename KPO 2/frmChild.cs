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
    /// <summary>
    /// Дочерняя форма программы
    /// </summary>
    public partial class frmChild : Form
    {
        public frmChild()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Координата предыдущего положения мыши
        /// </summary>
        int old_X, old_Y;

        
        /// <summary>
        /// Событие перемещения мыши внутри изображения
        /// </summary>
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
        /// <summary>
        /// Графика рабочего изображения
        /// </summary>
        private Graphics graphics;
        
        private void frmChild_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);
            pictureBox1.Refresh();
        }
        /// <summary>
        /// Функция нажатия на кнопку
        /// </summary>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            old_X = e.X;
            old_Y = e.Y;
        }
    }
}
