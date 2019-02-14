using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace TaskSix_Paint {
    public class Circle : VShape {

       // private int R;

        public Circle(): base(new Brush(Color.Black, 1),0,0) {
            R = 0;
        }
        public Circle(Brush b, int x, int y, int _r): base(b, x, y){
            R = _r;
        }
        public override void draw(Graphics gr)
        {
            gr.DrawEllipse(brush.getPen(), (float)(x - R), (float)(y - R), (float)(R * 2), (float)(R * 2));
        }
        public override string className()
        {
            return "Circle ";
        }

        public override string toString()
        {
            return "Circle " + base.toString();
        }
        public override void save(StreamWriter sw)
        {
            sw.WriteLine(toString());
        }

        public override void load(StreamReader sr)
        {
            string[] data = sr.ReadLine().Split();
            brush.setColor(System.Drawing.ColorTranslator.FromHtml(data[0]));
            brush.setBrushW(Int32.Parse(data[1]));
            x = Int32.Parse(data[2]);
            y = Int32.Parse(data[3]);
            R = Double.Parse(data[4]);
            angle = float.Parse(data[5]);
        }
    }
}
