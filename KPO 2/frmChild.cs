﻿using System;
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
        /// <summary>
        /// Множитель увеличения
        /// </summary>
        private static int Magn = 5;
        /// <summary>
        /// Генератор случайных чисел, используемый в форме
        /// </summary>
        private static Random random = new Random();
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
                    case Tools.Eraser://для ластика - прорисовываем белые круги
                        graphics.FillEllipse(Brushes.White, e.X - CurrentMode.Width, e.Y - CurrentMode.Width, 2 * CurrentMode.Width, 2 * CurrentMode.Width);
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
        /// <summary>
        /// Функция эффекта №1 - инверсия???
        /// </summary>
        public void Effect1()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = bitmap;
            Bitmap tempbmp = new Bitmap(pictureBox1.Image);
            int dispX = 1, dispY = 1, red, green, blue;
            for (int i = 0; i < tempbmp.Height - 1; i++)
            {
                for (int j = 0; j < tempbmp.Width - 1; j++)
                {
                    Color pixel1 = tempbmp.GetPixel(j, i);
                    Color pixel2 = tempbmp.GetPixel(j + dispX, i + dispY);
                    red = Math.Min(Math.Abs(pixel1.R - pixel2.R) + 128, 255);
                    green = Math.Min(Math.Abs(pixel1.G - pixel2.G) + 128, 255);
                    blue = Math.Min(Math.Abs(pixel1.B - pixel2.B) + 128, 255);
                    bitmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
                if (i % 10 == 0)
                {
                    pictureBox1.Invalidate();
                    pictureBox1.Refresh();
                    Text = (100 * i / (pictureBox1.Image.Height - 2)).ToString() + "%";
                }
                pictureBox1.Refresh();
            }
        }
        /// <summary>
        /// Функция эффекта 2 - усиление зелёного?
        /// </summary>
        public void Effect2()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = bitmap;
            Bitmap tempbmp = new Bitmap(pictureBox1.Image);
            int DX = 1, DY = 1;
            int red, blue, green;
            for (int i = DX; i < tempbmp.Height - DX; i++)
            {
                for (int j = DY; j < tempbmp.Width - DY; j++)
                {
                    red = (int)(tempbmp.GetPixel(j, i).R + 0.5 * 
                        (tempbmp.GetPixel(j, i).R - tempbmp.GetPixel(j - DX, i - DY).R));
                    green = (int)(tempbmp.GetPixel(j, i).G + 0.7 *
                        (tempbmp.GetPixel(j, i).G - tempbmp.GetPixel(j - DX, i - DY).G));
                    blue = (int)(tempbmp.GetPixel(j, i).B + 0.5 *
                        (tempbmp.GetPixel(j, i).B - tempbmp.GetPixel(j - DX, i - DY).B));
                }
                if (i % 10 == 0)
                {
                    pictureBox1.Invalidate();
                    Text = (100 * i / (tempbmp.Height - 2)).ToString() + "%";
                    pictureBox1.Refresh();
                }
            }
            pictureBox1.Refresh();
        }
        /// <summary>
        /// Функция эффекта 3  - "размазывание"??
        /// </summary>
        public void Effect3()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = bitmap;
            Bitmap tempbmp = new Bitmap(pictureBox1.Image);
            int DX = 1, DY = 1;
            int red, blue, green;
            for (int i = DX; i < tempbmp.Height - DX; i++)
            {
                for (int j = DY; j < tempbmp.Width - DY; j++)
                {
                    red = (tempbmp.GetPixel(j - 1, i - 1).R +
                        tempbmp.GetPixel(j - 1, i).R +
                        tempbmp.GetPixel(j - 1, i + 1).R +
                        tempbmp.GetPixel(j, i - 1).R +
                        tempbmp.GetPixel(j, i).R +
                        tempbmp.GetPixel(j, i + 1).R +
                        tempbmp.GetPixel(j + 1, i - 1).R +
                        tempbmp.GetPixel(j + 1, i).R +
                        tempbmp.GetPixel(j + 1, i + 1).R) / 9;
                    green = (tempbmp.GetPixel(j - 1, i - 1).G +
                        tempbmp.GetPixel(j - 1, i).G +
                        tempbmp.GetPixel(j - 1, i + 1).G +
                        tempbmp.GetPixel(j, i - 1).G +
                        tempbmp.GetPixel(j, i).G +
                        tempbmp.GetPixel(j, i + 1).G +
                        tempbmp.GetPixel(j + 1, i - 1).G +
                        tempbmp.GetPixel(j + 1, i).G +
                        tempbmp.GetPixel(j + 1, i + 1).G) / 9;
                    blue = (tempbmp.GetPixel(j - 1, i - 1).B +
                        tempbmp.GetPixel(j - 1, i).B +
                        tempbmp.GetPixel(j - 1, i + 1).B +
                        tempbmp.GetPixel(j, i - 1).B +
                        tempbmp.GetPixel(j, i).B +
                        tempbmp.GetPixel(j, i + 1).B +
                        tempbmp.GetPixel(j + 1, i - 1).B +
                        tempbmp.GetPixel(j + 1, i).B +
                        tempbmp.GetPixel(j + 1, i + 1).B) / 9;
                    red = Math.Min(Math.Max(red, 0), 255);
                    green = Math.Min(Math.Max(green, 0), 255);
                    blue = Math.Min(Math.Max(blue, 0), 255);
                    bitmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
                if (i % 10 == 0)
                {
                    pictureBox1.Invalidate();
                    Text = (100 * i / (pictureBox1.Height - 2)).ToString() + "%";
                    pictureBox1.Refresh();
                }
            }
            pictureBox1.Refresh();
        }
        /// <summary>
        /// Функция эффекта 4 - возвращение в нормальный режим просмотра
        /// </summary>
        public void Effect4()
        {
            pictureBox1.Width = pictureBox1.Image.Width;
            pictureBox1.Height = pictureBox1.Image.Height;
        }
        /// <summary>
        /// Функция эффекта 5 - отдаление
        /// </summary>
        public void Effect5()
        {
            pictureBox1.Width /= 2;
            pictureBox1.Height /= 2;
        }
        /// <summary>
        /// Функция эффекта 6 - приближение
        /// </summary>
        public void Effect6()
        {
            pictureBox1.Width *= 2;
            pictureBox1.Height *= 2;
        }
        /// <summary>
        /// Функция эффекта 7 - блюр??
        /// </summary>
        public void Effect7()
        {
            Bitmap bmap = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = bmap;
            Bitmap tempbmp = new Bitmap(pictureBox1.Image);
            int DX, DY, red, green, blue;
            for (int i = 3; i < bmap.Height - 2; i++)
            {
                for (int j=3; j < bmap.Width - 2; j++)
                {
                    DX = random.Next(5) - 2;
                    DY = random.Next(5) - 2;
                    red = tempbmp.GetPixel(j + DX, i + DY).R;
                    green = tempbmp.GetPixel(j + DX, i + DY).G;
                    blue = tempbmp.GetPixel(j + DX, i + DY).B;
                    bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
                if (i % 10 == 0)
                {
                    pictureBox1.Invalidate();
                    pictureBox1.Refresh();
                    Text = (100 * i / (bmap.Height - 2)).ToString() + "%";
                }
            }
            pictureBox1.Refresh();
        }
        /// <summary>
        /// Функция эффекта 8 - поворот на 270 (кривой, надо фиксить)
        /// </summary>
        public void Effect8()
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Width = pictureBox1.Height * pictureBox1.Image.Width / pictureBox1.Image.Height;
        }
        /// <summary>
        /// Функция эффекта 9 - поворот на 90 (кривой, надо фиксить)
        /// </summary>
        public void Effect9()
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Width = pictureBox1.Height * pictureBox1.Image.Width / pictureBox1.Image.Height;
        }
        /// <summary>
        /// Функция эффекта 10 - отражение по вертикали
        /// </summary>
        public void Effect10()
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Refresh();
        }
        /// <summary>
        /// Функция эффекта 11 - отражение по горизонтали
        /// </summary>
        public void Effect11()
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Refresh();
        }
        #endregion Функции эффектов
    }
}
