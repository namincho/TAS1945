using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas1945_mon
{
    class Cinema
    {
        public double[,] g_dbSeats = new double[60, 81];
        //public int[,] g_abyColor = new int[4800, 3];
        public int[,] g_abyColor = new int[4860, 3];

        private const int g_iPixelDefault = 10;

        private int g_iPixelSize = 10;                  //  size of seats
        private int g_iPixelSpace = 0;                  //  size of blank space

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public void Draw (Graphics g)
        {
            Int32 l_int32_color_r = 0, l_int32_color_g = 0, l_int32_color_b = 255;

            Brush   MyBrush;

            for (int i = 0; i < g_dbSeats.GetLength (0); i++)
            {
                for (int j = 0; j < g_dbSeats.GetLength (1); j++)
                {
                    if (g_dbSeats[i, j] < 0.0)      g_dbSeats[i, j] = 0.0;
                    if (g_dbSeats[i, j] > 1.0)      g_dbSeats[i, j] = 1.0;

                    l_int32_color_r = (Int32)(255.0 * Math.Sqrt (Math.Sin ((g_dbSeats[i, j] * 3.141592) / 2)));
                    l_int32_color_g = (Int32)(255.0 * g_dbSeats[i, j] * g_dbSeats[i, j]);

                    if (g_dbSeats[i, j] < 0.5)      l_int32_color_b = (Int32)(160.0 * Math.Sin(g_dbSeats[i, j] * 2.0 * 3.141592));
                    else                            l_int32_color_b = (Int32)(255.0 * (2 * (g_dbSeats[i, j] - 0.5)) * (2 * (g_dbSeats[i, j] - 0.5)));

                    if (l_int32_color_r < 0)    l_int32_color_r = 0;
                    if (l_int32_color_r > 255)  l_int32_color_r = 255;
                    if (l_int32_color_g < 0)    l_int32_color_g = 0;
                    if (l_int32_color_g > 255)  l_int32_color_g = 255;
                    if (l_int32_color_b < 0)    l_int32_color_b = 0;
                    if (l_int32_color_b > 255)  l_int32_color_b = 255;

                    g_abyColor[(i * 81) + j, 0] = l_int32_color_r;
                    g_abyColor[(i * 81) + j, 1] = l_int32_color_g;
                    g_abyColor[(i * 81) + j, 2] = l_int32_color_b;

                    MyBrush = new SolidBrush (Color.FromArgb (l_int32_color_r, l_int32_color_g, l_int32_color_b));

                    g.FillRectangle (MyBrush, j * (g_iPixelSize + g_iPixelSpace), i * (g_iPixelSize + g_iPixelSpace), g_iPixelSize, g_iPixelSize);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="b80x60"></param>
        /// <param name="iPixelSpace"></param>
        public void Draw (Graphics g, int iPixelSpace)
        {
            Int32 l_int32_color_r = 0, l_int32_color_g = 0, l_int32_color_b = 255;
            int     i, j;

            Brush   MyBrush;

            g_iPixelSpace = iPixelSpace;                        //  size of blank space
            g_iPixelSize = g_iPixelDefault - iPixelSpace;       //  size of seats

            for (i = 0; i < g_dbSeats.GetLength (0); i++)          //  y
            {
                for (j = 0; j < g_dbSeats.GetLength (1); j++)      //  x
                {
                    if (g_dbSeats[i, j] < 0.0)      g_dbSeats[i, j] = 0.0;
                    if (g_dbSeats[i, j] > 1.0)      g_dbSeats[i, j] = 1.0;

                    l_int32_color_r = (Int32)(255.0 * Math.Sqrt (Math.Sin ((g_dbSeats[i, j] * 3.141592) / 2)));
                    l_int32_color_g = (Int32)(255.0 * g_dbSeats[i, j] * g_dbSeats[i, j]);

                    if (g_dbSeats[i, j] < 0.5)      l_int32_color_b = (Int32)(160.0 * Math.Sin(g_dbSeats[i, j] * 2.0 * 3.141592));
                    else                            l_int32_color_b = (Int32)(255.0 * (2 * (g_dbSeats[i, j] - 0.5)) * (2 * (g_dbSeats[i, j] - 0.5)));

                    if (l_int32_color_r < 0)    l_int32_color_r = 0;
                    if (l_int32_color_r > 255)  l_int32_color_r = 255;
                    if (l_int32_color_g < 0)    l_int32_color_g = 0;
                    if (l_int32_color_g > 255)  l_int32_color_g = 255;
                    if (l_int32_color_b < 0)    l_int32_color_b = 0;
                    if (l_int32_color_b > 255)  l_int32_color_b = 255;

                    g_abyColor[(i * 81) + j, 0] = l_int32_color_r;
                    g_abyColor[(i * 81) + j, 1] = l_int32_color_g;
                    g_abyColor[(i * 81) + j, 2] = l_int32_color_b;

                    MyBrush = new SolidBrush (Color.FromArgb (l_int32_color_r, l_int32_color_g, l_int32_color_b));

                    g.FillRectangle (MyBrush, j * (g_iPixelSize + g_iPixelSpace), i * (g_iPixelSize + g_iPixelSpace), g_iPixelSize, g_iPixelSize);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public void Clear (Graphics g)
		{
            Brush   MyBrush;

            MyBrush = new SolidBrush (Color.FromArgb (255, 255, 255));
                                
            g.FillRectangle (MyBrush, 0, 0, 800, 600);
		}

        //  BWtoColor ?
        /*
        public void Draw(Graphics g)
        {
            Int32 l_int32_color_r = 0, l_int32_color_g = 0, l_int32_color_b = 255;

            Brush   MyBrush;

            for (int j = 0; j < seats.GetLength(1); j++)
            {
                for (int i = 2; i < seats.GetLength(0) + 2; i++)
                {
                    if (seats[i - 2, j] < 0.0) seats[i - 2, j] = 0.0;
                    if (seats[i - 2, j] > 1.0) seats[i - 2, j] = 1.0;
                    
                    l_int32_color_r = (Int32)(255.0 * Math.Sqrt(Math.Sin((seats[i - 2, j] * 3.141592) / 2)));
                    l_int32_color_g = (Int32)(255.0 * seats[i - 2, j] * seats[i - 2, j]);
                    
                    if (seats[i - 2, j] < 0.5) l_int32_color_b = (Int32)(160.0 * Math.Sin(seats[i - 2, j] * 2.0 * 3.141592));
                    else l_int32_color_b = (Int32)(255.0 * (2 * (seats[i - 2, j] - 0.5)) * (2 * (seats[i - 2, j] - 0.5)));
                    
                    if (l_int32_color_r < 0) l_int32_color_r = 0;
                    if (l_int32_color_r > 255) l_int32_color_r = 255;
                    if (l_int32_color_g < 0) l_int32_color_g = 0;
                    if (l_int32_color_g > 255) l_int32_color_g = 255;
                    if (l_int32_color_b < 0) l_int32_color_b = 0;
                    if (l_int32_color_b > 255) l_int32_color_b = 255;

                    MyBrush = new SolidBrush (Color.FromArgb(l_int32_color_r, l_int32_color_g, l_int32_color_b));

                    g.FillRectangle (MyBrush, i * (size + space), j * (size + space), size, size);
                }
            }
        }
        */
    }

    public partial class Form1 : Form
    {
        public void SetColorTabel()
        {
            Int32 l_int32_color_r = 0, l_int32_color_g = 0, l_int32_color_b = 255;

            for (int i = 0; i < 21; i++)
            {
                string tbName = "textBoxA" + i.ToString();
                TextBox tb = (TextBox)this.Controls.Find(tbName, true).FirstOrDefault();
                double backcolor = Convert.ToDouble(tb.Text);

                if (backcolor < 0.0) backcolor = 0.0;
                if (backcolor > 1.0) backcolor = 1.0;

                l_int32_color_r = (Int32)(255.0 * Math.Sqrt(Math.Sin((backcolor * 3.141592) / 2)));
                l_int32_color_g = (Int32)(255.0 * backcolor * backcolor);
                if (backcolor < 0.5) l_int32_color_b = (Int32)(160.0 * Math.Sin(backcolor * 2.0 * 3.141592));
                else l_int32_color_b = (Int32)(255.0 * (2 * (backcolor - 0.5)) * (2 * (backcolor - 0.5)));

                if (l_int32_color_r < 0) l_int32_color_r = 0;
                if (l_int32_color_r > 255) l_int32_color_r = 255;
                if (l_int32_color_g < 0) l_int32_color_g = 0;
                if (l_int32_color_g > 255) l_int32_color_g = 255;
                if (l_int32_color_b < 0) l_int32_color_b = 0;
                if (l_int32_color_b > 255) l_int32_color_b = 255;

                tbName = "textBoxC" + i.ToString();
                tb = (TextBox)this.Controls.Find(tbName, true).FirstOrDefault();
                tb.BackColor = Color.FromArgb(l_int32_color_r, l_int32_color_g, l_int32_color_b);
            }
        }
    }
}
