using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace OverJoyedWINFORM
{
    class ScreenDrawer
    {

        Pen penA;
        Rectangle centerRect;

        /*
         * Init Train of thought
         * Procedural or User-Defined
         * Color Palette
         * Width
         * Opacity
         */

        public void InitDrawing()
        {
            penA = new Pen(Brushes.Azure);
            penA.Width = 8.0f;
            centerRect = new Rectangle();
            centerRect.X = 1920 / 2; //Replace 1920 and 1080 with variables
            centerRect.Y = 1080 / 2;
            centerRect.Width = 200;
            centerRect.Height = 200;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(penA, centerRect);
        }

        /*
         *public void GetSetup(setupParams){
         * 
         * }
         */
    }
}
