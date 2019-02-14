using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TaskSix_Paint {
    public class FactoryShape {
        
        public Shape createShape(int x, int y, string shape)
        {
            switch (shape) {

                case "Circle":
                    // (Brush, x, y , n)
                    return new Circle(new Brush(Form1.curColor, Form1.brush_w), x, y, Form1.STD_SHAPE_SIZE);

                case "Polygon":
                    // (Brush, x, y , n)
                    return new Polygon(new Brush(Form1.curColor, Form1.brush_w), x, y, Form1.starVertexCount);
               
                case "Star":
                    if (Form1.starVertexCount>4 && Form1.starVertexCount%2==1 )
                        return new RegularStar(new Brush(Form1.curColor, Form1.brush_w), x, y, Form1.starVertexCount);
                    else return null;
                default:
                    return null;
            }
        }

        // используется для загрузки хранилища из файла
        public Shape createShape(string shape)
        {
            switch (shape) {

                case "Circle":
                    return new Circle();

                case "Polygon":
                    return new Polygon();

                case "RegularStar":
                    return new RegularStar();
                case "ShapeGroup":
                    return new ShapeGroup();
                default:
                    return null;
            }
        }

    }
}
