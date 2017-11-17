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
    }
}
