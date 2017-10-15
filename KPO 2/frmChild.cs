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
        #region Поля
        /// <summary>
        /// Стэк, хранящий предыдующие шаги
        /// </summary>
        private Stack<Image> PrevStack;
        /// <summary>
        /// Стэк, хранящий следующий шаги
        /// </summary>
        private Stack<Image> NextStack;
         /// <summary>
        /// Координата предыдущего положения мыши
        /// </summary>
        int old_X, old_Y;
        /// <summary>
        /// Временно сохранённое текущее изображение
        /// </summary>
        private Image TempImage;
        /// <summary>
        /// Векторы для построения звезды
        /// </summary>
        static PointF[] startstar;
        /// <summary>
        /// Количество концов звезды
        /// </summary>
        static  int StarNumber = 5;
        /// <summary>
        /// Свойство получения вектора для построения звезды
        /// </summary>
        static PointF[] GetStartStar
        {
            get
            {//Если уже сохранёны векторы - просто вывести
                if (startstar != null) return startstar;
                //Получаемый массив векторов
                PointF[] result = new PointF[StarNumber*2];
                //Начальный угол
                double u = Math.PI / 2;
                //Изменение угла
                double du = Math.PI / StarNumber;
                //Радиус внешний
                double r1 = 1;
                //Радиус внутренний - формула вычисления из википедии
                double r2 = Math.Cos(Math.PI / 5 * 2) / Math.Cos(Math.PI / 5) * r1;
                for (int i = 0; i < result.Length; i++)
                {
                    if (i % 2 == 0)//Если чётно - по внешней окр
                    {
                        result[i].X = (float)(r1 * Math.Cos(u));
                        result[i].Y = (float)(- r1 * Math.Sin(u));
                    }
                    else //иначе по внутренней
                    {
                        result[i].X = (float)(r2 * Math.Cos(u));
                        result[i].Y = (float)(- r2 * Math.Sin(u));
                    }
                    u += du;
                }
                startstar = result;
                return startstar;
            }
        }     
        /// <summary>
        /// Графика рабочего изображения
        /// </summary>
        private Graphics graphics;
        private static int Magn = 5;
        #endregion Поля

        #region Функции инструментов
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
        /// Получение массива координат вершин звезды
        /// </summary>
        /// <param name="x">X первой точки</param>
        /// <param name="y">Y первой точки</param>
        /// <param name="x1">X второй точки</param>
        /// <param name="y1">Y второй точки</param>
        /// <returns>Массив координат вершин звезды</returns>
        private Point[] GetStarPoints(int x, int y,int x1, int y1)
        {
            //Получаем векторы для построения звезды
            PointF[] vec = GetStartStar;
            Point[] result = new Point[StarNumber*2];
            //Вычисляем координаты центра звезды
            int cx = Math.Abs(x + x1) / 2, cy = Math.Abs(y + y1) / 2;
            //Вычисляем коэффициенты увеличения координат
            double divertionx = Math.Abs(x - x1)/2;
            double divertiony = Math.Abs(y - y1)/2;
            for (int i = 0; i < result.Length; i++)
            {
                //Каждая координата вектора умножается на коэф и прибавляется центр
                result[i].X = (int)Math.Round(vec[i].X * divertionx) + cx;
                result[i].Y = (int)Math.Round(vec[i].Y * divertiony) + cy;
            }
            return result;
        }
        /// <summary>
        /// Событие перемещения мыши внутри изображения
        /// </summary>
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (CurrentMode.tool) {
                    case Tools.Pen: //В случае пера всё просто: рисуем прямую и 
                        //обновляем координаты
                        graphics.DrawLine(CurrentMode.pen, old_X, old_Y, e.X, e.Y);
                        old_X = e.X;
                        old_Y = e.Y;
                        break;
                    case Tools.Line://В случае линии востанавливаем изображение из 
                        //временного и затем рисуем прямую
                        pictureBox1.Image = (Image)TempImage.Clone();
                        graphics = Graphics.FromImage(pictureBox1.Image);
                        graphics.DrawLine(CurrentMode.pen, old_X, old_Y, e.X, e.Y);
                        break;
                    case Tools.Elipse://Аналогично линии: востанавливаем изображение из
                        //временного и затем рисуем овал
                        pictureBox1.Image = (Image)TempImage.Clone();
                        graphics = Graphics.FromImage(pictureBox1.Image);
                        graphics.DrawEllipse(CurrentMode.pen,Math.Min(old_X,e.X),Math.Min(old_Y,e.Y),Math.Abs(old_X-e.X),Math.Abs(old_Y-e.Y));
                        break;
                    case Tools.Star://Аналогично линии: востанавливаем изображение из
                        //временного и затем рисуем звезду (как многоугольник)
                        pictureBox1.Image = (Image)TempImage.Clone();
                        graphics = Graphics.FromImage(pictureBox1.Image);
                        graphics.DrawPolygon(CurrentMode.pen, GetStarPoints(old_X,old_Y,e.X,e.Y));
                        break;
                }
                pictureBox1.Refresh();
            }
        }
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
            if (CurrentMode.tool == Tools.ScaleUp)
            {   //Создаём масштабированное изображение
                Bitmap bitmap = new Bitmap(pictureBox1.Image, new Size(pictureBox1.Image.Width * Magn, pictureBox1.Image.Height * Magn));
                //Меняем размеры пикчербокса
                pictureBox1.Height *= Magn;
                pictureBox1.Width *= Magn;
                //Меняем изображение
                pictureBox1.Image = bitmap;
                //Обновляем графику и пикчербокс
                graphics = Graphics.FromImage(pictureBox1.Image);
                pictureBox1.Refresh();
            }
            if (CurrentMode.tool == Tools.ScaleDown)
            {
                //Создаём масштабированное изображение
                Bitmap bitmap = new Bitmap(pictureBox1.Image, new Size(pictureBox1.Image.Width / Magn, pictureBox1.Image.Height / Magn));
                //Меняем размеры пикчербокса
                pictureBox1.Height /= Magn;
                pictureBox1.Width /= Magn;
                //Меняем изображение
                pictureBox1.Image = bitmap;
                //Обновляем графику и пикчербокс
                graphics = Graphics.FromImage(pictureBox1.Image);
                pictureBox1.Refresh();
            }   
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
        #endregion Функции инструментов

        #region Функции эффектов
        public void Effect1()
        {
            throw new NotImplementedException();
        }
        public void Effect2()
        {
            throw new NotImplementedException();
        }
        public void Effect3()
        {
            throw new NotImplementedException();
        }
        public void Effect4()
        {
            throw new NotImplementedException();
        }
        public void Effect5()
        {
            throw new NotImplementedException();
        }
        public void Effect6()
        {
            throw new NotImplementedException();
        }
        public void Effect7()
        {
            throw new NotImplementedException();
        }
        public void Effect8()
        {
            throw new NotImplementedException();
        }
        public void Effect9()
        {
            throw new NotImplementedException();
        }
        public void Effect10()
        {
            throw new NotImplementedException();
        }
        public void Effect11()
        {
            throw new NotImplementedException();
        }
        #endregion Функции эффектов
    }
}
