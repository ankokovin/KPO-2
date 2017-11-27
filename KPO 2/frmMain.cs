using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        /// <summary>
        /// Список отображений ширины
        /// </summary>
        private List<Bitmap> WidthLook;
        /// <summary>
        /// Функция обновления <see cref="WidthLook"/>
        /// </summary>
        private void UpdateWidthLook()
        {
            //очищаем список
            WidthLook.Clear();
            //для каждой опции ширины
            for (int i = 0; i < CurrentMode.WidthOptions.Length; i++)
            {   //создаём ручку
                Pen pen = new Pen(CurrentMode.Color, CurrentMode.WidthOptions[i]);
                //создаём изображение
                Bitmap bitmap = new Bitmap(pbPenWidthImage.Width, pbPenWidthImage.Height);
                //создаём его графику
                Graphics graphics = Graphics.FromImage(bitmap);
                //по середине изображения рисуем горизонтальную линию
                graphics.DrawLine(pen, 0, bitmap.Height / 2, bitmap.Width, bitmap.Height / 2);
                //добавляем полученное изображение в список
                WidthLook.Add(bitmap);
            }
            //обновляем отображение 
            UpdatePenWidthImage();
        }
        /// <summary>
        /// Функция обновления отображения текущей ширины на <see cref="pbPenWidthImage"/>
        /// <para>Используется изображение из <see cref="WidthLook"/>, соответствуещее текущей ширине</para>
        /// </summary>
        private void UpdatePenWidthImage()
        {
            //Изображения пикчербокса присвоим соответствующее изображение из списка
            pbPenWidthImage.Image = WidthLook[CurrentMode.curWidth];
            //Обновим пикчербокс
            pbPenWidthImage.Update();
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
            CurrentMode.NewFilesCounterInc();
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
        /// <summary>
        /// Функция обработки события загрузки окна <see cref="frmMain"/>
        /// </summary>
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
            //Создаём список отображения ширины
            WidthLook = new List<Bitmap>(CurrentMode.WidthOptions.Length);
            //Обновляем этот список
            UpdateWidthLook();
            //Заполняем домейн ширин
            foreach (float x in CurrentMode.WidthOptions) 
                {
                    domainPenWidth.Items.Add(x);
                }
            domainPenWidth.SelectedIndex = 0;
        }
        /// <summary>
        /// Событие нажатия на кнопку смены цвета
        /// </summary>
        private void ChangeColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            if (colorDialog1.Color != null) CurrentMode.Color = colorDialog1.Color;
            UpdateColorIcon();
            UpdateWidthLook();
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
        /// Функция нажатия на кнопку инструмента
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
        /// <summary>
        /// Функция обработки события нажатия на кнопку функции
        /// </summary>
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
        /// <summary>
        /// Функция обработки события изменения <see cref="domainPenWidth"/>
        /// </summary>
        private void domainPenWidth_TextChanged(object sender, EventArgs e)
        {
            //Изменяем текущую ширину на выбранную
            CurrentMode.ChangeWidth(domainPenWidth.SelectedIndex);
            //Обновляем отображение текущей ширины
            UpdatePenWidthImage();
        }
        /// <summary>
        /// Функция обработки события открытия файла
        /// </summary>
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream stream =  openFileDialog1.OpenFile() as FileStream;
                Bitmap bitmap = new Bitmap(stream);
                frmChild frmChild = new frmChild(bitmap);
                frmChild.MdiParent = this;
                frmChild.FileName = openFileDialog1.FileName;
                frmChild.Text = frmChild.FileName;
                frmChild.Show();
            }
            
        }
        /// <summary>
        /// Функция обработки события нажатия на кнопку "сохранить"
        /// <see cref="сохранитьToolStripMenuItem"/>
        /// </summary>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {   //если новый файл - то по тому же сценарию, как в "сохранить как..."
            if (CurrentMode.ActiveChild.GetNewFile)
            {
                сохранитьКакToolStripMenuItem_Click(sender, e);
            }else
            {   //иначе просто сохраняем
                CurrentMode.ActiveChild.FormImage.Save(CurrentMode.ActiveChild.FileName,ImageFormat.Png);
            }
        }
        
        /// <summary>
        /// Функция обработки события открытия меню <see cref="файлToolStripMenuItem"/>
        /// </summary>
        private void файлToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {   //если не открыто ни одно окно, то блокируем кнопки сохранения
            if (CurrentMode.ActiveChild == null)
            {
                сохранитьToolStripMenuItem.Enabled = false;
                сохранитьКакToolStripMenuItem.Enabled = false;
            }//иначе разблокируем их
            else
            {
                сохранитьToolStripMenuItem.Enabled = true;
                сохранитьКакToolStripMenuItem.Enabled = true;
            }
        }
        /// <summary>
        /// Функция обработки события нажатия на кнопку "сохранить как"
        /// <see cref="сохранитьКакToolStripMenuItem"/>
        /// </summary>
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OneFileSaveDialog.FileName = CurrentMode.ActiveChild.FileName;
            if (OneFileSaveDialog.ShowDialog() == DialogResult.OK)
            {
                CurrentMode.ActiveChild.SetNewFileName(OneFileSaveDialog.FileName);
                CurrentMode.ActiveChild.FormImage.Save(OneFileSaveDialog.FileName, ImageFormat.Png);
            }
        }
    }
}
