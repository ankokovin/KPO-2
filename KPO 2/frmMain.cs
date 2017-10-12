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
    /// Перечисление инструментов
    /// </summary>
    public enum Tools {None,Pen,Star,Line,Elipse,Eraser,ScaleUp,ScaleDown}

    /// <summary>
    /// Основная форма программы
    /// </summary>
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Событие нажатия на пункт "Выход"
        /// </summary>
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Событие нажатия на пункт "Новый"
        /// </summary>
        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChild frmChild = new frmChild();
            frmChild.MdiParent = this;
            frmChild.Show();
        }


        /// <summary>
        /// Графика для изображения текущего цвета
        /// </summary>
        private Graphics ColorChangeGraphics;
        
        /// <summary>
        /// Функция обновления изображения текущего цвета
        /// </summary>
        private void UpadateColorChangeIcon()
        {
            ColorChangeGraphics.DrawRectangle(Pens.Black, 0, 0, ChangeColorButton.Image.Width, ChangeColorButton.Image.Height);
            ColorChangeGraphics.DrawRectangle(Pens.White, 1, 1, ChangeColorButton.Image.Width - 2, ChangeColorButton.Image.Height - 2);
            ColorChangeGraphics.FillRectangle(new SolidBrush(CurrentMode.Color), 2, 2, ChangeColorButton.Image.Width - 4, ChangeColorButton.Image.Height - 4);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DefaultBGColor = PenButton.BackColor;
            
            ChangeColorButton.Image = new Bitmap(ChangeColorButton.Width, ChangeColorButton.Height);
            ColorChangeGraphics = Graphics.FromImage(ChangeColorButton.Image);
            UpadateColorChangeIcon();
        }
        /// <summary>
        /// Событие нажатия на кнопку смены цвета
        /// </summary>
        private void ChangeColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            if (colorDialog1.Color != null) CurrentMode.Color = colorDialog1.Color;
            UpadateColorChangeIcon();
        }
        /// <summary>
        /// Стандартный цвет бэкграунда кнопок инструмента
        /// </summary>
        private Color DefaultBGColor;

        /// <summary>
        /// Кнопка используемого инструмента
        /// </summary>
        private ToolStripButton ActiveTool;

        /// <summary>
        /// Событие нажатия на кнопку инструмента
        /// </summary>
        /// <param name="sender">Нажатая кнопка</param>
        private void Button_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            switch (button.Name)
            {
                case "PenButton":
                    CurrentMode.tool = Tools.Pen;
                    break;
                case "LineButton":
                    CurrentMode.tool = Tools.Line;
                    break;
                case "ElipseButton":
                    CurrentMode.tool = Tools.Elipse;
                    break;
                case "StarButton":
                    CurrentMode.tool = Tools.Star;
                    break;
                case "EraserButton":
                    CurrentMode.tool = Tools.Eraser;
                    break;
                case "ScaleUpButton":
                    CurrentMode.tool = Tools.ScaleUp;
                    break;
                case "ScaleDownButton":
                    CurrentMode.tool = Tools.ScaleDown;
                    break;
                default:
                    throw new Exception("Неожиданное имя кнопки");
            }
            button.BackColor = Color.Red;
            if (ActiveTool != null) ActiveTool.BackColor = DefaultBGColor;
            ActiveTool = button;
        }
    }
}
