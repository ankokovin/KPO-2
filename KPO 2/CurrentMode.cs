using System.Drawing;

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
            width = 1;
            color = Color.Black;
            UpdatePen();
        }
        /// <summary>
        /// Текущая ширина пера
        /// </summary>
        static private float width;
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
                return width;
            }
            set
            {
                width = value;
                UpdatePen();
            }
        }
        /// <summary>
        /// Функция пересоздания пера
        /// </summary>
        static private void UpdatePen()
        {
            pen = new Pen(color, width);
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
    }
}
