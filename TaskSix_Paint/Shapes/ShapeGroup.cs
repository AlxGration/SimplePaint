using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TaskSix_Paint {
    public class ShapeGroup :VShape{

        int w, h;
        int x2, y2;
  

        private Iterator<Shape> iter;

        public Container<Shape> children;

        public ShapeGroup()
        {
            children = new Container<Shape>();
            iter = children.iterator();
            brush = new Brush(Color.Black, 3);
            brush.getPen().DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            w = 0; h = 0;
            x = Int32.MaxValue; y = Int32.MaxValue;
            x2 = 0; y2 = 0;

        }
        public override string className()
        {
            return "ShapeGroup ";
        }
        public void addShape(VShape sh)
        {
            children.Add(sh);
            calcWH(sh);
        }
        public override void processNode(TreeNodeCollection _nodeCollection)
        {
            TreeNode n = new TreeNode(shapeName());
            for(iter.begin(); !iter.EOL(); iter.next()) {
                iter.getVal().processNode(n.Nodes);
            }

            _nodeCollection.Add(n);
        }
        public override void draw(Graphics gr)
        {
            if (brush.isSelect()) gr.DrawRectangle(brush.getPen(), x, y, w, h);
            for(iter.begin(); !iter.EOL(); iter.next()) {
              
                iter.getVal().draw(gr);
            }
        }
        public override void move(int _dx, int _dy)
        {
            if ((x + w + _dx < Form1.WINDOW_WIDTH) &&
                (x + _dx > 145) &&
                (y + h + _dy < Form1.WINDOW_HEIGHT) &&
                (y + _dy > 30)) {

                x += _dx;
                y += _dy;
                for (iter.begin(); !iter.EOL(); iter.next()) {
                    iter.getVal().move(_dx, _dy);
                }
            }
         
        }
        public override void changeSize(int k)
        {
            if ((x + w < Form1.WINDOW_WIDTH) && (x + w  + k < Form1.WINDOW_WIDTH) &&
               (x - k > 145) &&
               (y + h < Form1.WINDOW_HEIGHT) && (y + h + k < Form1.WINDOW_HEIGHT) &&
               (y - k > 30)) {

                x = Int32.MaxValue; y = Int32.MaxValue;
                x2 = 0; y2 = 0;

                for (iter.begin(); !iter.EOL(); iter.next()) {
                    iter.getVal().changeSize(k);
                    calcWH((VShape)iter.getVal());
                }
            }
        }
        public override void hide(Graphics gr)
        {
            brush.hide();
            for (iter.begin(); !iter.EOL(); iter.next()) {
                iter.getVal().hide(gr);
            }
            draw(gr);
        }
        public override void show(Graphics gr)
        {
            brush.show();
            for (iter.begin(); !iter.EOL(); iter.next()) {
                iter.getVal().show(gr);
            }
            draw(gr);
        }
        public override bool collisionEnter(int _x, int _y)
        {
            if (x <= _x && y <= _y &&           //  L & U check
                x + w >= _x && y + h >= _y) {   //  R & D check

                return true;
            }
            return false;
        }

        public void calcWH(VShape sh)
        {
            if (sh.className() == "ShapeGroup ")
            {
                ShapeGroup shape = (ShapeGroup)sh;
                if (x > shape.x)
                {
                    x = shape.x;
                    if (x2 == 0) x2 = shape.x + shape.w;
                }
                else if (shape.x + shape.w > x2) x2 = shape.x + shape.w;

                if (y > shape.y)
                {
                    y = shape.y;
                    if (y2 == 0) y2 = shape.y + shape.h;
                }
                else if (shape.y + shape.h > y2) y2 = shape.y + shape.h;
            }
            else
            {
                if (sh.x - sh.R <= x)
                {  // start x = maxVal
                    x = (int)(sh.x - sh.R);
                    if (x2 == 0) x2 = (int)(sh.x + sh.R);
                }
                else
                {
                    if (sh.x + sh.R > x2)
                    {
                        x2 = (int)(sh.x + sh.R);
                    }
                }
                if (sh.y - sh.R < y)
                {
                    y = (int)(sh.y - sh.R);
                    if (y2 == 0) y2 = (int)(sh.y + sh.R);
                }
                else
                {
                    if (sh.y + sh.R > y2)
                    {
                        y2 = (int)(sh.y + sh.R);
                    }
                }
            }
            w = (x2 - x);
            h = (y2 - y);
        }

        public override void rotation(float k)
        {
            for (iter.begin(); !iter.EOL(); iter.next()) 
                iter.getVal().rotation(k);
            
        }

        public override string toString()
        {
            return "ShapeGroup "+children.Count()+" "+base.toString();
        }
        public override void save(StreamWriter sw)
        {
            sw.WriteLine(toString());
            for (iter.begin(); !iter.EOL(); iter.next()) {
                iter.getVal().save(sw);
            }
        }

        public override void load(StreamReader sr)
        {
            string[] data = sr.ReadLine().Split();
            int n = Int32.Parse(data[0]);

            brush.setColor(System.Drawing.ColorTranslator.FromHtml(data[1]));
            brush.setBrushW(Int32.Parse(data[2]));
            x = Int32.Parse(data[3]);
            y = Int32.Parse(data[4]);
            R = Double.Parse(data[5]);
            angle = float.Parse(data[6]);

    
            FactoryShape factory = new FactoryShape();
            string className = "";
            char ch = (char)sr.Read();
            for (int i = 0; i < n; i++) {
                while (ch != ' ') {
                    className += ch;
                    ch = (char)sr.Read();
                }

                Shape shape = factory.createShape(className);
                shape.load(sr);
                if (shape.brush.isSelect()) shape.brush.select();
                calcWH((VShape)shape);
                className = "";
                if (i < n-1) ch = (char)sr.Read();
               children.Add(shape);
            }

        }

        ~ShapeGroup()
        {
            children.Clear();
        }
    }
}
