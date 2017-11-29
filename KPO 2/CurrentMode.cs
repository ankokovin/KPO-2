using System.Drawing;
using System;

namespace KPO_2
{
    /// <summary>
    /// Статический класс, характеризующий текущее состояние программы
    /// </summary>
    public static class CurrentMode
    {
        /// <summary>
        /// Установка начального состояния программы
        /// </summary>
        static CurrentMode()
        {
            curWidth = 0;
            color = Color.Black;
            UpdatePen();
        }
        /// <summary>
        /// Индекс текущей ширины
        /// <para>Указывает на массив <see cref="WidthOptions"/></para>
        /// <para>Используется в <see cref="Width"/></para>
        /// </summary>
        public static  int curWidth;
        /// <summary>
        /// Функция изменения индекса текущей ширины
        /// <para>Изменяет значение <see cref="curWidth"/></para>
        /// </summary>
        /// <param name="newWidth">Но</param>
        static public void ChangeWidth(int newWidth)
        {
            if (curWidth < 0 || curWidth >= WidthOptions.Length)
            {
                throw new ArgumentException("Неожиданное значение индекса ширины");
            }
            curWidth = newWidth;
            UpdatePen();
        }
        /// <summary>
        /// Текущий цвет
        /// </summary>
        static Color color;
        /// <summary>
        /// Текущий цвет
        /// </summary>
        static public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                UpdatePen();   
            }
        }
        /// <summary>
        /// Текущая ширина пера
        /// </summary>
        static public float Width
        {
            get
            {
                return WidthOptions[curWidth];
            }
        }
        /// <summary>
        /// Функция пересоздания пера
        /// </summary>
        static private void UpdatePen()
        {
            pen = new Pen(color, Width);
        }
        /// <summary>
        /// Текущее перо
        /// </summary>
        static public Pen pen;
        /// <summary>
        /// Текущий инструмент
        /// </summary>
        static public Tools tool;
        /// <summary>
        /// Текущее активное окно
        /// </summary>
        public static frmChild ActiveChild;
        /// <summary>
        /// Варианты значений ширины (захардкодены).
        /// <para>Используется в свойстве <see cref="Width"/></para>
        /// <para>Индекс текущей ширины хранится в <see cref="curWidth"/></para>
        /// </summary>
        public static float[] WidthOptions = { 1,2,2.5F,3,3.5F,4};
        /// <summary>
        /// Счётчик для хранения количенства открытых "новых файлов"
        /// </summary>
        private static int newFilesCounter = 0;
        /// <summary>
        /// Свойство для получения количества открытых "новых файлов" 
        /// <para>Получает значение из <see cref="newFilesCounter"/></para>
        /// </summary>
        public static int NewFilesOpened
        {
            get
            {
                return newFilesCounter;
            }
        }
        /// <summary>
        /// Функция увеличения счётчика количества открытых "новых файлов"
        /// <para>Инкрементирует <see cref="newFilesCounter"/></para>
        /// </summary>
        public static void NewFilesCounterInc() => ++newFilesCounter;

        /// <summary>
        /// Количество концов звезды
        /// </summary>
        static int starNumber = 2;
        
        /// <summary>
        /// Свойство количество концов звезды
        /// <para>Именяет и выдаёт <see cref="starNumber"/></para>
        /// </summary>
        public static int StarNumber { get=>starNumber;
            set {  //при изменении - удаляем массив преподсчёта
                startstar = null;
                starNumber = value;
            }
        }
        
        /// <summary>
        /// Векторы для построения звезды
        /// </summary>
        static PointF[] startstar;
        
        /// <summary>
        /// Свойство получения вектора для построения звезды
        /// </summary>
        public static PointF[] GetStartStar
        {
            get
            {//Если уже сохранёны векторы - просто вывести
                if (startstar != null) return startstar;
                //Получаемый массив векторов
                PointF[] result = new PointF[StarNumber * 2];
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
                        result[i].Y = (float)(-r1 * Math.Sin(u));
                    }
                    else //иначе по внутренней
                    {
                        result[i].X = (float)(r2 * Math.Cos(u));
                        result[i].Y = (float)(-r2 * Math.Sin(u));
                    }
                    u += du;
                }
                startstar = result;
                return startstar;
            }
        }
    }
}
