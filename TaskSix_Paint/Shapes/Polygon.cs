using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;

namespace TaskSix_Paint {
    public class Polygon : VShape {
        
        private PointF[] points; // вершины
        private int countVertex;
                            //R;  // радуус описаной окружности
      
        public Polygon(): base(new Brush(Color.Black, 1),0,0) {
            countVertex = 0;
        }

        public Polygon(Brush b, int x, int y, int _countVertex): base(b, x, y){
            
            countVertex = _countVertex;
            R *= 2;
            polygonCreate();

        }

        public void setVertex(int count)
        {
            countVertex = count;
        }

        public override void changeSize(int k)
        {
            base.changeSize(k);
            notifyXYchanged();
        }

        public override void draw(Graphics gr)
        {
            gr.DrawPolygon(brush.getPen(), points);
        }
        protected override void notifyXYchanged()
        {
            for (int i = 0; i < countVertex; i++) {
                points[i].X = (float)(x + R * Math.Cos(angle + (2 * Math.PI * i) / countVertex));
                points[i].Y = (float)(y + R * Math.Sin(angle + (2 * Math.PI * i) / countVertex));

            }
        }

        public void polygonCreate()
        {
            points = new PointF[countVertex];

            // polygon creating
            for (int i = 0; i < countVertex; i++) {
                points[i] = new PointF((float)(x + R * Math.Cos(angle + (2 * Math.PI * i) / countVertex)),
                                       (float)(y + R * Math.Sin(angle + (2 * Math.PI * i) / countVertex)));

            }
        }

        public override string className()
        {
            return "Polygon ";
        }

        public override string toString()
        {
            return "Polygon " + base.toString() + " " + countVertex;
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
            countVertex = Int32.Parse(data[6]);
            polygonCreate();
        }
        ~Polygon()
        {
            for(int i = 0; i < countVertex; i++) {
                points[i] = default(PointF);
            }
            points = null;
        }
    }
}
