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

        private List<Bitmap> WidthLook;
        
        private void UpdateWidthLook()
        {
            throw new NotImplementedException();
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
        private void UpdateColorIcon()
        {
            ColorChangeGraphics.DrawRectangle(Pens.Black, 0, 0, ChangeColorButton.Image.Width, ChangeColorButton.Image.Height);
            ColorChangeGraphics.DrawRectangle(Pens.White, 1, 1, ChangeColorButton.Image.Width - 2, ChangeColorButton.Image.Height - 2);
            ColorChangeGraphics.FillRectangle(new SolidBrush(CurrentMode.Color), 2, 2, ChangeColorButton.Image.Width - 4, ChangeColorButton.Image.Height - 4);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Устанавливаем цвет бэкграунда кнопки инструмента по-умолчананию
            DefaultBGColor = PenButton.BackColor;
            //Устанавливаем активную кнопку - без инструмента
            ActiveTool = NoToolButton;
            //Окрашиваем активную кнопку
            NoToolButton.BackColor = Color.Red;
            //Создаём изображение на кнопке изменения цвета
            ChangeColorButton.Image = new Bitmap(ChangeColorButton.Width, ChangeColorButton.Height);
            //Получаем графику этого изображения
            ColorChangeGraphics = Graphics.FromImage(ChangeColorButton.Image);
            //Обнавляем цвет икноки цвета
            UpdateColorIcon();
        }
        /// <summary>
        /// Событие нажатия на кнопку смены цвета
        /// </summary>
        private void ChangeColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            if (colorDialog1.Color != null) CurrentMode.Color = colorDialog1.Color;
            UpdateColorIcon();
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
                case "NoToolButton":
                    CurrentMode.tool = Tools.None;
                    break;
                case "PenButton":
                    CurrentMode.tool = Tools.Pen;
                    break;
                case "LineButton":
                    CurrentMode.tool = Tools.Line;
                    break;
                case "EllipseButton":
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
        /// <summary>
        /// Функция нажатия кнопки "Назад"
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            CurrentMode.ActiveChild.Cancel();
        }
        /// <summary>
        /// Функция нажатия кнопки "Вперёд"
        /// </summary>
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            CurrentMode.ActiveChild.Return();
        }

        private void FunctionButtonClick(object sender, EventArgs e)
        {
            if (CurrentMode.ActiveChild == null) return;
            ToolStripMenuItem Button = sender as ToolStripMenuItem;
            switch (Button.Name)
            {
                case "эффект1ToolStripMenuItem":
                    CurrentMode.ActiveChild.Effect1();
                    break;
                case "эффект2ToolStripMenuItem":
                    CurrentMode.ActiveChild.Effect2();
                    break;
                case "эффект3ToolStripMenuItem":
                    CurrentMode.ActiveChild.Effect3();
                    break;
                case "эффект4ToolStripMenuItem":
                    CurrentMode.ActiveChild.Effect4();
                    break;
                case "эффект5ToolStripMenuItem":
                    CurrentMode.ActiveChild.Effect5();
                    break;
                case "эффект6ToolStripMenuItem":
                    CurrentMode.ActiveChild.Effect6();
                    break;
                case "эффект7ToolStripMenuItem":
                    CurrentMode.ActiveChild.Effect7();
                    break;
                case "эффект8ToolStripMenuItem":
                    CurrentMode.ActiveChild.Effect8();
                    break;
                case "эффект9ToolStripMenuItem":
                    CurrentMode.ActiveChild.Effect9();
                    break;
                case "эффект10ToolStripMenuItem":
                    CurrentMode.ActiveChild.Effect10();
                    break;
                case "эффект11ToolStripMenuItem":
                    CurrentMode.ActiveChild.Effect11();
                    break;
                default:
                    throw new Exception("Неизвестный пункт меню");
            }
        }
    }
}
