using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TaskSix_Paint {
    public class Brush {

        private Pen pen;
        private Color color;
        private Color hidenColor;
        private int brush_w, temp_w;
        public static short selected_w = 10;

        public Brush(Color c, int width)
        {
            pen = new Pen(c, selected_w);
            temp_w = width;
            brush_w = selected_w;
            color = c;
            hidenColor = Form1.backgroundColor ;
        }
        
        public Pen getPen()
        {
            return pen;
        }
        public void setColor(Color c)
        {
            color = c;
            if (pen != null) { pen.Color = color; } 
            else { pen = new Pen(color, brush_w); }
        }
        public void setBrushW(int w)
        {
            if (isSelect()) temp_w = w;
            else brush_w = w;

            if (pen != null) { pen.Width = brush_w; } 
            else { pen = new Pen(color, brush_w); }
        }

        public void select()
        {
            if (brush_w != selected_w) {
                temp_w = brush_w;
                brush_w = selected_w;
            } else
                brush_w = temp_w;
            pen.Width = brush_w;
        }

        public bool isSelect()
        {
            return brush_w == selected_w;
        }

        public void hide()
        {
            hidenColor = color;
            color = Form1.backgroundColor;

            setColor(color);
        }
        public void show()
        {
            color = hidenColor;
            setColor(color);
        }
        ~Brush()
        {
            if (pen != null) pen.Dispose();
            color = default(Color);
            hidenColor = default(Color);
        }
    }
}
