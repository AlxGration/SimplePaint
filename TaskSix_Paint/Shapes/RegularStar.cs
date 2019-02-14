using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace TaskSix_Paint
{
    public class RegularStar: VShape{

        /**
         *  КЛАСС ПРАВИЛЬНОЙ ЗВЕЗДЫ
         */

        private PointF[] points, starPoints; // вершины
        private int countVertex;  
        private double koef;
                            //R;  // радуус описаной окружности
      
        public RegularStar(): base(new Brush(Color.Black, 1),0,0) {
        }

        public RegularStar(Brush b, int x, int y, int _countVertex) : base(b, x, y) {
            R *= 2;
            countVertex = _countVertex;
            starCreate();
        }

        public override void changeSize(int k)
        {
            base.changeSize(k);
            notifyXYchanged();
        }

        public override void draw(Graphics gr)
        {
            gr.DrawPolygon(brush.getPen(), starPoints.ToArray());
        }
        

        protected override void notifyXYchanged()
        {
            
            for (int i = 0; i < countVertex; i++) {
                koef = (2 * Math.PI*i) / countVertex;
                points[i].X = (float)(x + R * Math.Cos(angle + koef));
                points[i].Y = (float)(y + R * Math.Sin(angle + koef));
            }
            int k = countVertex / 2, j = k, v = 1;
            starPoints[0].X = points[0].X;
            starPoints[0].Y = points[0].Y;
            while (j != 0) {
                starPoints[v].X = points[j].X;
                starPoints[v].Y = points[j].Y;
                j = (j + k) % countVertex;
                ++v;
            }
        }
        public override string className()
        {
            return "RegularStar ";
        }

        public override string toString()
        {
            return "RegularStar "+base.toString() + " " + countVertex;
        }
        public override void save(StreamWriter sw)
        {
            sw.WriteLine(toString());
        }
        public override void load(StreamReader sr)
        {
            string []data = sr.ReadLine().Split();
            brush.setColor(System.Drawing.ColorTranslator.FromHtml(data[0]));
            brush.setBrushW(Int32.Parse(data[1]));
            x = Int32.Parse(data[2]);
            y = Int32.Parse(data[3]);
            R = Double.Parse(data[4]);
            angle = float.Parse(data[5]);
            countVertex = Int32.Parse(data[6]);

            starCreate();
        }

        public void setVertex(int count)
        {
            countVertex = count;
        }

        public void starCreate()
        {
            points = new PointF[countVertex];
            starPoints = new PointF[countVertex];
            koef = (2 * Math.PI) / countVertex;

            // polygon creating
            for (int i = 0; i < countVertex; i++) {
                koef = (2 * Math.PI*i) / countVertex;
                points[i].X = (float)(x + R * Math.Cos(angle + koef));
                points[i].Y = (float)(y + R * Math.Sin(angle + koef));

            }

            int k = countVertex / 2, j = k, v = 1;
            starPoints[0].X = points[0].X;
            starPoints[0].Y = points[0].Y;
            while (j != 0) {
                starPoints[v].X = points[j].X;
                starPoints[v].Y = points[j].Y;
                j = (j + k) % countVertex;
                ++v;
            }
        }

        ~RegularStar()
        {
            for (int i = 0; i < countVertex; i++) {
                points[i] = default(PointF);
                starPoints[i] = default(PointF);
            }
            points = null;
            starPoints = null;
        }
    }
}
