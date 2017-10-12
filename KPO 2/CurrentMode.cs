using System.Drawing;

namespace KPO_2
{
    public static class CurrentMode
    {
        static CurrentMode()
        {
            width = 1;
            color = Color.Black;
            UpdatePen();
        }

        static private float width;
        static Color color;
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
        static private void UpdatePen()
        {
            pen = new Pen(color, width);
        }
        static public Pen pen;
        static public Tools tool;
    }
}
