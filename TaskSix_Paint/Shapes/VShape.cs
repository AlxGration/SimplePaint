using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

/**
 *          КЛАСС - РОДИТЕЛЬ 
 *                ДЛЯ
 *           ОБЪЕМНЫХ ФИГУР
 *    
 *    (наследник базового класса - фигура)
 * */

namespace TaskSix_Paint {
    public class VShape : Shape{

        private Point center;
        public int minShapeSize = 25;
        public float angle = -0.3f;
        public double R = Form1.STD_SHAPE_SIZE;  // радиус описанной окружности
       // public bool isObserver = false;

        public  VShape()
        {
            center = new Point(0,0);
            thisNUM = NUM++;
        }
        public VShape(Brush b, int x, int y)
        {
            brush = b;
            center = new Point(x, y);
            thisNUM = NUM++;
        }
        public int x {
            get { return center.x; }
            set { center.x = value; }
        }
        public int y {
            get { return center.y; }
            set { center.y = value; }
        }

        public override void draw(Graphics gr){
            //реализуется в наследниках
        }
        public override void processNode(TreeNodeCollection _nodeCollection)
        {
            TreeNode n = new TreeNode(shapeName());
            _nodeCollection.Add(n);
        }

        public override void move(int _dx, int _dy)
        {
            if ((x + R + _dx < Form1.WINDOW_WIDTH) && 
                (x - R + _dx > 145) && 
                (y + R + _dy < Form1.WINDOW_HEIGHT) && 
                (y - R + _dy > 30)) {
                x += _dx;
                y += _dy;
            }
            notifyXYchanged();
        }
        public bool canMove(int _dx, int _dy)
        {
            if ((x + R + _dx < Form1.WINDOW_WIDTH) &&
                (x - R + _dx > 145) &&
                (y + R + _dy < Form1.WINDOW_HEIGHT) &&
                (y - R + _dy > 30)) {
                return true;
            }
            return false;
        }

        public override void changeSize(int k) {
            // реализуется в наследниках
            if (k > 0) {
                if (x + R + k < Form1.WINDOW_WIDTH && y + R + k < Form1.WINDOW_HEIGHT &&
                    x - R  - k> 145 && y - R - k > 30) { // shape must be INTO Form
                    R += k;
                }
            } else {
                if (R > minShapeSize) {    // shape mustn't be too small
                    R += k;    //-- = +
                }
            }
        }

        protected override void notifyXYchanged() {
            // реализуется в наследниках
        }

        public override bool collisionEnter(int _x, int _y)
        {
            // + реализуется в наследниках
            if (x + R >= _x && y + R >= _y &&
                x - R <= _x && y - R <= _y) {
                return true;
            }
            return false;
        }

        public override void rotation(float k)
        {
            angle += k;
            notifyXYchanged();
        }
        public override void doAction(char action)
        {
            if (action == Form1.CH_BRUSHW_COLOR){ 
                brush.setColor(Form1.curColor);
                brush.setBrushW(Form1.brush_w); 
            }
        }

        public override string toString()
        {
            return base.toString()+" "+ center.x+" "+center.y+" "+ R+" "+angle;
        }

        public override void save(StreamWriter sw)
        {
            // реализуется в наследниках
        }

        public override void load(StreamReader sr)
        {
            // реализуется в наследниках
        }

        ~VShape()
        {
            center = null;
        }
    }
}
