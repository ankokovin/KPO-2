using System;
using System.Collections.Generic;
using System.IO;
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
        /// Конструктор при новом изображении
        /// </summary>
        public frmChild()
        {
            InitializeComponent();
            NewFile = true;
            FileName = "Изображение" + CurrentMode.NewFilesOpened;
            Text = FileName;
        }

        /// <summary>
        /// Конструктор при открытии изображения
        /// </summary>
        /// <param name="image">Открываемое изображение</param>
        public frmChild(Image image)
        {
            InitializeComponent();
            NewFile = false;
            TempImage = image;
        }

        #region Поля
        #region Работа с файлами
        /// <summary>
        /// Является ли создающееся изображение новым
        /// </summary>
        private bool NewFile;
        /// <summary>
        /// Свойство получения <see cref="NewFile"/>
        /// </summary>
        public bool GetNewFile { get => NewFile; }
        /// <summary>
        /// Имя файла текущего изображения
        /// </summary>
        public string FileName;
        #endregion Работа с файлами
        #region Рисование

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
        /// Графика рабочего изображения
        /// </summary>
        private Graphics graphics;
        
        /// <summary>
        /// Множитель увеличения
        /// </summary>
        private static int Magn = 2;

        #endregion Рисование
        /// <summary>
        /// Были ли изменения
        /// </summary>
        private bool _wasChanged = false;
        /// <summary>
        /// Свойство были ли изменения
        /// </summary>
        public bool WasChanged { get { return _wasChanged; } set
            {
                if (value) _wasChanged = true;
            }
            }

        /// <summary>
        /// Генератор случайных чисел, используемый в форме
        /// </summary>
        private static Random random = new Random();
        
        /// <summary>
        /// Свойство текущего изображения
        /// <para>Выводит свойство Image от <see cref="pictureBox1"/></para>
        /// </summary>
        public Image FormImage
        {
            get
            {
                return pictureBox1.Image;
            }
        }
        #endregion Поля

        #region Функции

        /// <summary>
        /// Функция по установлению нового имени файла
        /// <para>Устанавливает <see cref="FileName"/></para>
        /// <para>Устанавливает <see cref="NewFile"/> как <see cref="false"/></para>
        /// </summary>
        /// <param name="_FileName">Новое имя файла</param>
        public void SetNewFileName(string _FileName)
        {
            FileName = _FileName;
            Text = FileName;
            NewFile = false;
        }

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
                _wasChanged = PrevStack.Count != 0;
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
                WasChanged = true;
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
            PointF[] vec = CurrentMode.GetStartStar;
            Point[] result = new Point[CurrentMode.StarNumber*2];
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
            if (NewFile)
            {
                //Устанавливаем новое изображение
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                //Получаем его графику
                graphics = Graphics.FromImage(pictureBox1.Image);
                //Очищаем и обновляем
                graphics.Clear(Color.White);
            }
            else
            {   //Устанавливаем размеры пикчербокса и устанавливаем изображение
                pictureBox1.Width = TempImage.Width;
                pictureBox1.Height = TempImage.Height;
                pictureBox1.Image = TempImage;
                //получаем графику
                graphics = Graphics.FromImage(pictureBox1.Image);
            }
            //обновим пикчербокс
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
            WasChanged = true;
        }
        
        #endregion Функции инструментов

        #region Функции эффектов

        /// <summary>
        /// Функция эффекта №1 - инверсия???
        /// </summary>
        public void Effect1()
        {
            Save_n_Push_Prev();
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
            Text = FileName;

        }
        
        /// <summary>
        /// Функция эффекта 2 - усиление зелёного?
        /// </summary>
        public void Effect2()
        {
            Save_n_Push_Prev();
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
            Text = FileName;
        }

        /// <summary>
        /// Функция эффекта 3  - "размазывание"??
        /// </summary>
        public void Effect3()
        {
            Save_n_Push_Prev();
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
            Text = FileName;
        }

        /// <summary>
        /// Функция эффекта 4 - возвращение в нормальный режим просмотра
        /// </summary>
        public void Effect4()
        {
            Save_n_Push_Prev();
            pictureBox1.Width = pictureBox1.Image.Width;
            pictureBox1.Height = pictureBox1.Image.Height;
        }

        /// <summary>
        /// Функция эффекта 5 - отдаление
        /// </summary>
        public void Effect5()
        {
            Save_n_Push_Prev();
            pictureBox1.Width /= 2;
            pictureBox1.Height /= 2;
        }

        /// <summary>
        /// Функция эффекта 6 - приближение
        /// </summary>
        public void Effect6()
        {
            Save_n_Push_Prev();
            pictureBox1.Width *= 2;
            pictureBox1.Height *= 2;
        }

        /// <summary>
        /// Функция эффекта 7 - блюр??
        /// </summary>
        public void Effect7()
        {
            Save_n_Push_Prev();
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
            Text = FileName;
        }

        /// <summary>
        /// Функция эффекта 8 - поворот на 270
        /// </summary>
        public void Effect8()
        {
            Save_n_Push_Prev();
            int tw = pictureBox1.Width, th = pictureBox1.Height;
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Height = tw;
            pictureBox1.Width = th;
            pictureBox1.Update();
        }

        /// <summary>
        /// Функция эффекта 9 - поворот на 90 
        /// </summary>
        public void Effect9()
        {
            Save_n_Push_Prev();
            int tw = pictureBox1.Width, th = pictureBox1.Height;
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Height = tw;
            pictureBox1.Width = th;
            pictureBox1.Update();
        }


        /// <summary>
        /// Функция эффекта 10 - отражение по вертикали
        /// </summary>
        public void Effect10()
        {
            Save_n_Push_Prev();
            pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Функция эффекта 11 - отражение по горизонтали
        /// </summary>
        public void Effect11()
        {
            Save_n_Push_Prev();
            pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Refresh();
        }

        #endregion Функции эффектов

        /// <summary>
        /// Функция добавления текущего изображения перед изменением
        /// <para>Помещает изображение в <see cref="PrevStack"/></para>
        /// <para>Очищает <see cref="NextStack"/></para>
        /// <para>Использовать только в функциях эффекта</para>
        /// </summary>
        void Save_n_Push_Prev()
        {
            WasChanged = true;
            TempImage = (Image)pictureBox1.Image.Clone();
            PrevStack.Push(TempImage);
            NextStack.Clear();
        }


        #endregion Функции
    }
}

