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
        /// <summary>
        /// Стэк, хранящий предыдующие шаги
        /// </summary>
        private Stack<Image> PrevStack;
        /// <summary>
        /// Стэк, хранящий следующий шаги
        /// </summary>
        private Stack<Image> NextStack;


        public frmChild()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Координата предыдущего положения мыши
        /// </summary>
        int old_X, old_Y;

        /// <summary>
        /// Отмена изменения
        /// </summary>
        public void Cancel()
        {
            if (PrevStack.Count != 0)
            {
                
                NextStack.Push((Image)pictureBox1.Image.Clone());
                Image image = PrevStack.Pop();
                pictureBox1.Image = image;
                graphics = Graphics.FromImage(pictureBox1.Image);
                pictureBox1.Refresh();
            }
        }
        /// <summary>
        /// Возвращение изменения
        /// </summary>
        public void Return()
        {
            if (NextStack.Count != 0)
            {
                PrevStack.Push((Image)pictureBox1.Image.Clone());
                pictureBox1.Image = NextStack.Pop();
                graphics = Graphics.FromImage(pictureBox1.Image);
                pictureBox1.Refresh();
            }
        }
        /// <summary>
        /// Временно сохранённое текущее изображение
        /// </summary>
        private Image TempImage;

        /// <summary>
        /// Событие перемещения мыши внутри изображения
        /// </summary>
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (CurrentMode.tool) {
                    case Tools.Pen: //В случае пера всё просто: рисуем прямую и обновляем координаты
                        graphics.DrawLine(CurrentMode.pen, old_X, old_Y, e.X, e.Y);
                        old_X = e.X;
                        old_Y = e.Y;
                        break;
                    case Tools.Line://В случае линии востанавливаем изображение из временного и затем рисуем прямую
                        pictureBox1.Image = (Image)TempImage.Clone();
                        graphics = Graphics.FromImage(pictureBox1.Image);
                        graphics.DrawLine(CurrentMode.pen, old_X, old_Y, e.X, e.Y);
                        break;
                }
                pictureBox1.Refresh();
            }
        }
        /// <summary>
        /// Графика рабочего изображения
        /// </summary>
        private Graphics graphics;
        /// <summary>
        /// Функция загрузки окна
        /// </summary>
        private void frmChild_Load(object sender, EventArgs e)
        {
            //Устанавливаем новое изображение
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Получаем его графику
            graphics = Graphics.FromImage(pictureBox1.Image);
            //Очищаем и обновляем
            graphics.Clear(Color.White);
            pictureBox1.Refresh();
            //Создаём стэки
            PrevStack = new Stack<Image>();
            NextStack = new Stack<Image>();
        }
        /// <summary>
        /// Функция отпуска кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmChild_MouseUp(object sender, MouseEventArgs e)
        {
            if (CurrentMode.tool == Tools.None) return;
            PrevStack.Push(TempImage);
            NextStack.Clear();
        }
        /// <summary>
        /// Функция "активации" окна
        /// </summary>
        private void frmChild_Activated(object sender, EventArgs e)
        {
            CurrentMode.ActiveChild = this;
        }

        /// <summary>
        /// Функция нажатия на кнопку мыши
        /// </summary>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (CurrentMode.tool == Tools.None) return;
            old_X = e.X;
            old_Y = e.Y;
            TempImage = (Image)pictureBox1.Image.Clone();
        }
    }
}
