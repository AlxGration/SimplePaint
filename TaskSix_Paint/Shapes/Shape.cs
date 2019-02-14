using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

/**
 *     АБСТАРКТНЫЙ 
 *   КЛАСС - РОДИТЕЛЬ 
 *        ДЛЯ
 *     ВСЕХ ФИГУР
 * */
namespace TaskSix_Paint {
    public abstract class Shape {//: Observer

        protected static int NUM = 0;   // для нумерации фигуры в TreeView
        protected int thisNUM = 0;

        public abstract void draw(Graphics gr);
        public abstract void move(int _dx, int _dy);    // MoveCommand
        public abstract void changeSize(int k);
        public abstract bool collisionEnter(int x, int y);
        public abstract void doAction(char action);
        public abstract void rotation(float k);

        public abstract void save(StreamWriter sw);
        public abstract void load(StreamReader sr);

        protected abstract void notifyXYchanged();
        public Brush brush;

        public virtual void processNode(TreeNodeCollection _nodeCollection){}

        public virtual string className()
        {
            return "Shape ";
        }
        ~Shape()
        {
            brush = null;
        }
        public string shapeName()
        {
            return className() + thisNUM;
        }

        public virtual void hide(Graphics gr)
        {
            brush.hide();
            draw(gr);
        }
        public virtual void show(Graphics gr)
        {
            brush.show();
            draw(gr);
        }

        public virtual string toString(){
            int w = (int)brush.getPen().Width;
            if (brush.isSelect()) {
                brush.select();
                w = (int)brush.getPen().Width;
                brush.select();
            } 
            
            return colorToHex(brush.getPen().Color) + " " +w;
        }
        private string colorToHex(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
    }
}
